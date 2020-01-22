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
		/// Finds in all users.
		/// </summary>
		/// <returns></returns>
		IQueryable<User> Find();

		/// <summary>
		/// Adds the range of users.
		/// </summary>
		/// <param name="users">The users.</param>
		void AddRange(IEnumerable<User> users);
	}
}
