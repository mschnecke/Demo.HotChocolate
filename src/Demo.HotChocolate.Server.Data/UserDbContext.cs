// ----------------------------------------------------------------------------------------
//  <copyright file="UserDbContext.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data
{
	using Demo.HotChocolate.Server.Data.Models;
	using Microsoft.EntityFrameworkCore;

	internal class UserDbContext : DbContext
	{
		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{
		}

		public DbSet<UserDbo> Users { get; set; }
	}
}
