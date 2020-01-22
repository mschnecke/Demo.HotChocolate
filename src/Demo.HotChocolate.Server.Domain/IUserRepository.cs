using System;
// ----------------------------------------------------------------------------------------
//  <copyright file="IUserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Domain
{
	using System.Collections.Generic;
	using System.Linq;
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
		IQueryable<User> GetAllUsers();

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
