// ----------------------------------------------------------------------------------------
//  <copyright file="Startup.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.AspNetCore.SpaServices.AngularCli;
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
			services.ConfigureDatabase("Filename=MyDatabase.db");

			services.AddCors();

			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration => {
				                           configuration.RootPath = "ClientApp/dist";
			                           });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

			app.UseCors(builder => {
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

			app.UseSpa(spa => {
				           // To learn more about options for serving an Angular SPA from ASP.NET Core,
				           // see https://go.microsoft.com/fwlink/?linkid=864501

				           spa.Options.SourcePath = "ClientApp";

				           if (env.IsDevelopment())
				           {
					           spa.UseAngularCliServer("start");
				           }
			           });
		}
	}
}
