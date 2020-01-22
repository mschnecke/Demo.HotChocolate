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

	/// <inheritdoc />
	public class UserRepository : IUserRepository
	{
		private readonly UserDbContext dbContext;

		public UserRepository(UserDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		/// <inheritdoc />
		public IQueryable<User> Find()
		{
			return null;
		}

		/// <inheritdoc />
		public void AddRange(IEnumerable<User> users)
		{
			this.dbContext.Users.AddRange(users.Select(x => x.ToEntity()));
		}
	}
}
