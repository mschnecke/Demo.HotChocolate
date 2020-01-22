using System.Linq.Expressions;
using System;
// ----------------------------------------------------------------------------------------
//  <copyright file="UserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data
{
	using System.Collections.Generic;
	using System.Linq;
	using Demo.HotChocolate.Server.Data.Mapping;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.Domain.Models;
	using Models;

	/// <inheritdoc />
	public class UserRepository : IUserRepository
	{
		private readonly UserDbContext dbContext_;

		public UserRepository(UserDbContext dbContext)
		{
			dbContext_ = dbContext;
		}

		/// <inheritdoc />
		public IQueryable<User> GetAllUsers()
		{
			return dbContext_.Users.Select(x => x.ToModel());
		}

		/// <inheritdoc />
		public IQueryable<User> GetUser(Guid id)
		{

			return dbContext_.Users.Where(x => x.Id == id).Select(x => x.ToModel());
		}

		/// <inheritdoc />
		public IQueryable<User> GetUsers(String name_)
		{
			return dbContext_.Users.Where(x => x.FirstName.Equals(name_)).Select(x => x.ToModel());
		}

		/// <inheritdoc />
		public IQueryable<User> GetUsers(Expression<Func<User, bool>> func)
		{
			var func_ = MappingExtensions.Mapper.Map<Expression<Func<UserDbo, bool>>>(func);
			return dbContext_.Users.Where(func_).Select(x => x.ToModel());
		}

		public void TestMapping()
		{
			MappingExtensions.Mapper.Map<User>(new UserDbo());
			MappingExtensions.Mapper.Map<UserDbo>(new User());
			try { MappingExtensions.Mapper.Map<Expression<Func<UserDbo, bool>>>((Expression<Func<User, bool>>)(x => true)); } catch (Exception e) { }
			try { MappingExtensions.Mapper.Map<Expression<Func<User, bool>>>((Expression<Func<UserDbo, bool>>)(x => true)); } catch (Exception e) { }
		}

		/// <inheritdoc />
		public void AddUsers(IEnumerable<User> users)
		{
			dbContext_.Users.AddRange(users.Select(x => x.ToEntity()));
			dbContext_.SaveChanges();
		}

		/// <inheritdoc />
		public void AddUser(User user)
		{
			dbContext_.Users.Add(user.ToEntity());
			dbContext_.SaveChanges();
		}

		public void Clear()
		{
			dbContext_.Users.RemoveRange(dbContext_.Users);
			dbContext_.SaveChanges();
		}
	}
}
