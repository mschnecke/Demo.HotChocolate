// ----------------------------------------------------------------------------------------
//  <copyright file="UserRepository.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data
{
	using System.Linq;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.Domain.Models;

	/// <inheritdoc />
	public class UserRepository : IUserRepository
	{
		/// <inheritdoc />
		public IQueryable<User> Find()
		{
			return null;
		}
	}
}
