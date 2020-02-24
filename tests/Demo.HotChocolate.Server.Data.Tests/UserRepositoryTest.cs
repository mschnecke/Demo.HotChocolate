namespace Demo.HotChocolate.Server.Data.Tests
{
	using System;
	using System.IO;
	using System.Linq;
	using Demo.HotChocolate.Server.Domain.Models;
	using FluentAssertions;
	using Microsoft.EntityFrameworkCore;
	using Xunit;
	using Xunit.Abstractions;

	public class UserRepositoryTest
	{
		public UserRepositoryTest(ITestOutputHelper output)
		{
			this.output_ = output;
			var path = "MyDatabase.db";
			MoveOldDBFile(path);

			var builder = new DbContextOptionsBuilder<UserDbContext>();
			builder.UseSqlite(
				$"Filename={path}",
				options => options.MigrationsAssembly(Contants.MigrationsAssembly)
			);

			this.dbContext = new UserDbContext(builder.Options);
			this.dbContext.Database.Migrate();

			this.repository = new UserRepository(this.dbContext);
		}

		private readonly UserDbContext dbContext;

		private readonly UserRepository repository;

		private readonly ITestOutputHelper output_;

		private static void MoveOldDBFile(string path)
		{
			try
			{
				File.Copy(path, $"{path}.old", true);
				File.Delete(path);
			}
			catch (IOException e)
			{
			}
		}

		[Fact]
		public void Test1()
		{
			this.repository.Clear();

			var user = new User();
			user.Id = Guid.NewGuid();
			user.Email = $"{user.Id.ToString()}@thinprint.de";
			user.FirstName = "Name";
			user.LastName = "Name2";
			user.BirthDate = DateTime.Now.Subtract(TimeSpan.FromDays(365));

			this.repository.AddUser(user);
			Assert.Equal(user.Email, this.repository.GetUser(user.Id).ToList().ElementAt(0).Email);
			Assert.All(this.repository.GetUsers(user.FirstName), x => x.Email.Equals(user.Email));

			Assert.Equal(
				1,
				this.repository.GetUsers(
					x => x.BirthDate < DateTime.UtcNow.AddDays(-100)
				).Count()
			);
		}

		[Fact]
		public void Test2()
		{
			this.repository.Clear();

			var expected = new User();
			expected.BirthDate = DateTime.Now;
			expected.Email = "sgdhjgd@sgehs.fr";
			expected.FirstName = "First";
			expected.LastName = "Last";
			expected.Gender = Gender.Female;
			expected.ZipCode = 12345;

			this.repository.AddUser(expected);

			var bla = this.repository.GetUsers(x => x.Email == expected.Email);

			var user = bla.FirstOrDefault();

			user.Email.Should().BeEquivalentTo(expected.Email);
		}
	}
}
