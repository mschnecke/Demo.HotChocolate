namespace Demo.HotChocolate.Server.Data
{
	using Demo.HotChocolate.Server.Data.Models;
	using Microsoft.EntityFrameworkCore;

	public class UserDbContext : DbContext
	{
		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{
		}

		public DbSet<UserDbo> Users { get; set; }
	}
}
