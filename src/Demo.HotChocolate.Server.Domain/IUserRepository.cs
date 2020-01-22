// ----------------------------------------------------------------------------------------
//  <copyright file="IUserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------


// ----------------------------------------------------------------------------------------
//  <copyright file="IUserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Domain
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Demo.HotChocolate.Server.Domain.Models;

	/// <summary>
	/// The user repository.
	/// </summary>
	public interface IUserRepository
	{
		/// <summary>
		/// Get all users.
		/// </summary>
		/// <returns></returns>
		IQueryable<User> GetUsers();

		/// <summary>
		/// Gets the users.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		IQueryable<User> GetUsers(Expression<Func<User, bool>> expression);

		/// <summary>
		/// Get a single user.
		/// </summary>
		/// <returns></returns>
		IQueryable<User> GetUser(Guid id);

		/// <summary>
		/// Adds the range of users.
		/// </summary>
		/// <param name="users">The users.</param>
		void AddUsers(IEnumerable<User> users);

		/// <summary>
		/// Adds an user.
		/// </summary>
		/// <param name="user">The user.</param>
		void AddUser(User user);
	}
}
