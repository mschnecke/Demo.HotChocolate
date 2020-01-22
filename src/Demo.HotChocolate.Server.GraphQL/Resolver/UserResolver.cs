// ----------------------------------------------------------------------------------------
//  <copyright file="UserResolver.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL.Resolver
{
	using System.Collections.Generic;
	using System.Linq;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.GraphQL.Mapping;
	using Demo.HotChocolate.Server.Transport;

	public class UserResolver
	{
		private readonly IUserRepository repository;

		public UserResolver(IUserRepository repository)
		{
			this.repository = repository;
		}

		public IEnumerable<UserDto> GetUsers(int? skip, int? take)
		{
			var query = this.repository
				.GetUsers();

			if (skip.HasValue)
			{
				query = query.Skip(skip.Value);
			}

			if (take.HasValue)
			{
				query = query.Take(take.Value);
			}

			return query
				.Select(x => x.ToTransport())
				.ToList();
		}
	}
}
