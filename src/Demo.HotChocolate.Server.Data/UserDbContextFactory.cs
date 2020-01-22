// ----------------------------------------------------------------------------------------
//  <copyright file="UserDbContextFactory.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data
{
	using System.Reflection;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Design;

	internal static class Contants
	{
		// "DataSource=:memory:"
		// "Filename=MyDatabase.db"
		internal static string ConnectionString = "DataSource=:memory:";

		internal static string MigrationsAssembly =
			typeof(UserDbContext).GetTypeInfo().Assembly.GetName().Name;
	}

	// dotnet ef migrations add CreateInitSchema -o ./Migrations --startup-project ..\Demo.HotChocolate.Server\Demo.HotChocolate.Server.csproj
	internal class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
	{
		UserDbContext IDesignTimeDbContextFactory<UserDbContext>.CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<UserDbContext>();
			builder.UseSqlite(Contants.ConnectionString,
				options => options.MigrationsAssembly(Contants.MigrationsAssembly));
			return new UserDbContext(builder.Options);
		}
	}
}
