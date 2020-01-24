// ----------------------------------------------------------------------------------------
//  <copyright file="Startup.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server
{
	using System;
	using Bogus;
	using Bogus.DataSets;
	using Demo.HotChocolate.Server.Data;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.Domain.Models;
	using Demo.HotChocolate.Server.Extensions;
	using global::HotChocolate;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.SpaServices.AngularCli;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Internal;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;
	using Microsoft.Extensions.Hosting;

	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var path = "MyDatabase.db";
			services.ConfigureDatabase($"Filename={path}");
			services.AddTransient<IUserRepository, UserRepository>();

			services.ConfigureGraphQL();

			services.AddDataLoaderRegistry();

			services.AddCors();
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "ClientApp/dist";
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			try
			{
				lifetime.ApplicationStarted.Register(() =>
				{
					PopulateData(app);
				});
			}
			catch (Exception)
			{
			}

			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin();
				builder.AllowAnyHeader();
				builder.AllowAnyMethod();
			});

			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();
			app.UseCustomGraphQL();

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer("start");
				}
			});
		}

		private static void PopulateData(IApplicationBuilder app)
		{
			try
			{
				using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
				var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
				dbContext.Database.Migrate();
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
			}

			try
			{
				var userRepository = app.ApplicationServices.GetRequiredService<IUserRepository>();

				if (userRepository.GetUsers().Any())
				{
					return;
				}

				var faker = new Faker<User>()
						.RuleFor(o => o.IsMale, f => f.Person.Gender == Name.Gender.Male)
						.RuleFor(o => o.Gender, f => f.Person.Gender.ToModel())
						.RuleFor(o => o.ZipCode,
							f => f.Random.Int(1000, 9999))
						.RuleFor(o => o.FirstName,
							f => f.Name.FirstName())
						.RuleFor(o => o.LastName,
							f => f.Name.LastName())
						.RuleFor(o => o.Email, f => f.Internet.Email())
						.RuleFor(o => o.Id, f => f.Random.Guid())
						.RuleFor(o => o.BirthDate,
							f => f.Date.Between(
								new DateTime(1965, 1, 1),
								new DateTime(2006, 1, 1)))
					;

				var users = faker.Generate(10);
				userRepository.AddUsers(users);
			}
			catch (Exception exception)
			{
				Console.WriteLine(exception);
			}
		}
	}
}
