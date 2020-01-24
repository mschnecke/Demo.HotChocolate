// ----------------------------------------------------------------------------------------
//  <copyright file="UserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Demo.HotChocolate.Server.Data.Mapping;
	using Demo.HotChocolate.Server.Data.Models;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.Domain.Models;
	using GreenDonut;

	/// <inheritdoc />
	public class UserRepository : IUserRepository
	{
		private readonly UserDbContext dbContext;

		public UserRepository(UserDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		/// <inheritdoc />
		public IQueryable<User> GetUsers()
		{
			return this.dbContext
				.Users
				.Select(x => x.ToModel());
		}

		/// <inheritdoc />
		public IQueryable<User> GetUser(Guid id)
		{
			return this.dbContext.Users.Where(x => x.Id == id).Select(x => x.ToModel());
		}

		/// <inheritdoc />
		public void AddUsers(IEnumerable<User> users)
		{
			this.dbContext.Users.AddRange(users.Select(x => x.ToEntity()));
			this.dbContext.SaveChanges();
		}

		public void AddUser(User user)
		{
			this.dbContext.Users.Add(user.ToEntity());
			this.dbContext.SaveChanges();
		}

		/// <inheritdoc />
		public IQueryable<User> GetUsers(Expression<Func<User, bool>> expression)
		{
			var mappedExpression = MappingExtensions.Mapper.Map<Expression<Func<UserDbo, bool>>>(expression);
			return this.dbContext.Users.Where(mappedExpression).Select(x => x.ToModel());
		}

		public IQueryable<User> GetUsers(string name)
		{
			return this.dbContext.Users.Where(x => x.FirstName.Equals(name)).Select(x => x.ToModel());
		}

		public IReadOnlyList<User> GetUsers(IReadOnlyList<string> keys)
		{
			return this.GetUsers(x => keys.Contains(x.Id.ToString())).Select(x => x).ToList();
		}

		public void Clear()
		{
			this.dbContext.Users.RemoveRange(this.dbContext.Users);
			this.dbContext.SaveChanges();
		}
	}
}
