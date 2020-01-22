// ----------------------------------------------------------------------------------------
//  <copyright file="IUserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Domain
{
	using System.Linq;
	using System.Threading.Tasks;
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
	}
}
