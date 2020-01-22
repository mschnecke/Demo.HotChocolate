using System.Diagnostics;
using System.Linq.Expressions;
using System.Linq;
using System;
using System.IO;
using Demo.HotChocolate.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace Demo.HotChocolate.Server.Data.Tests
{
	public class UserRepositoryTest
	{
		private UserDbContext dbContext;
		private UserRepository repository;
		private readonly ITestOutputHelper output_;
		public UserRepositoryTest(ITestOutputHelper output)
		{
			output_ = output;
			var path = "MyDatabase.db";
			MoveOldDBFile(path);

			var builder = new DbContextOptionsBuilder<UserDbContext>();
			builder.UseSqlite(
				$"Filename={path}",
				options => options.MigrationsAssembly(Contants.MigrationsAssembly)
			);

			dbContext = new UserDbContext(builder.Options);
			dbContext.Database.Migrate();

			repository = new UserRepository(dbContext);
		}

		[Fact]
		public void Test1()
		{
			repository.Clear();

			var user = new User();
			user.Id = Guid.NewGuid();
			user.Email = $"{user.Id.ToString()}@thinprint.de";
			user.FirstName = "Name";
			user.LastName = "Name2";
			user.BirthDate = DateTime.Now.Subtract(TimeSpan.FromDays(365));

			repository.AddUser(user);
			Assert.Equal(user.Email, repository.GetUser(user.Id).ToList().ElementAt(0).Email);
			Assert.All(repository.GetUsers(user.FirstName), x => x.Email.Equals(user.Email));
			Assert.Equal(
				1,
				repository.GetUsers(
					x => x.BirthDate < DateTime.UtcNow.AddDays(-100)
				).Count()
			);
		}

		[Fact]
		public void Test2()
		{
			repository.Clear();

			var expected = new User();
			expected.BirthDate = DateTime.Now;
			expected.Email = "sgdhjgd@sgehs.fr";
			expected.FirstName = "First";
			expected.LastName = "Last";
			expected.Gender = Gender.Female;
			expected.ZipCode = 12345;

			repository.AddUser(expected);
		}

		static void MoveOldDBFile(String path)
		{
			try
			{
				File.Copy(path, $"{path}.old", true);
				File.Delete(path);
			}
			catch (IOException e) { }
		}
	}
}