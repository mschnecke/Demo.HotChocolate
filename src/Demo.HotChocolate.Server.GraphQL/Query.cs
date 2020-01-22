// ----------------------------------------------------------------------------------------
//  <copyright file="Query.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL
{
	using System.Collections.Generic;
	using System.Linq;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.GraphQL.Mapping;
	using Demo.HotChocolate.Server.Transport;
	using global::HotChocolate;
	using global::HotChocolate.Types;

	public class Query
	{
		[UseFiltering]
		public IEnumerable<UserDto> GetUsers([Service] IUserRepository repository)
		{
			return repository
				.GetUsers()
				.Select(x => x.ToTransport())
				.ToList();
		}
	}
}
