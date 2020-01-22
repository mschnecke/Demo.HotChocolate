﻿// ----------------------------------------------------------------------------------------
//  <copyright file="UserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

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
	using AutoMapper;
	using AutoMapper.Extensions.ExpressionMapping;
	using AutoMapper.QueryableExtensions;
	using Demo.HotChocolate.Server.Data.Mapping;
	using Demo.HotChocolate.Server.Data.Models;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.Domain.Models;

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

		/*
				/// <inheritdoc />
				public IQueryable<User> GetUsers(Expression<Func<User, bool>> func)
				{
					var func_ = MappingExtensions.Mapper.Map<Expression<Func<UserDbo, bool>>>(func);
					return dbContext.Users.Where(func_).Select(x => x.ToModel());
				}*/

		/// <inheritdoc />
		public IQueryable<User> GetUsers(Expression<Func<User, bool>> expression)
		{
			var mappedExpression = MappingExtensions.Mapper.Map<Expression<Func<UserDbo, bool>>>(expression);

			// return this.dbContext.Users.UseAsDataSource(configuration).For<User>().Where(mappedExpression).AsQueryable();

			return this.dbContext.Users.Where(mappedExpression).Select(x => x.ToModel());
		}

		public void AddUser(User user)
		{
			this.dbContext.Users.Add(user.ToEntity());
			this.dbContext.SaveChanges();
		}

		/// <inheritdoc />
		public IQueryable<User> GetUsers(string name)
		{
			return this.dbContext.Users.Where(x => x.FirstName.Equals(name)).Select(x => x.ToModel());
		}

		public void Clear()
		{
			this.dbContext.Users.RemoveRange(this.dbContext.Users);
			this.dbContext.SaveChanges();
		}
	}
}
