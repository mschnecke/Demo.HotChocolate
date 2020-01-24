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
	using global::HotChocolate.Types.Relay;

	public class Query
	{
		[UsePaging]
		//[UseFiltering]
		[UseSorting]
		[GraphQLDescription("Get the users.")]
		public ICollection<UserDto> GetUsers([Service] IUserRepository repository)
		{
			return repository
					.GetUsers()
					.Select(x => x.ToTransport())
					.ToList()
				;
		}

		//[UsePaging]
		////[UseFiltering]
		//[UseSorting]
		//[GraphQLDescription("Get the users.")]
		//public ICollection<UserDto> GetUsers([Service] UserDbContext dbContext)
		//{
		//	return dbContext
		//			.Users
		//			.Select(x => x.ToTransport())
		//			.ToList()
		//		;
		//}
	}
}
