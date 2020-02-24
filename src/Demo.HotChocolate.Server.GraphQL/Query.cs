namespace Demo.HotChocolate.Server.GraphQL
{
	using System;
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
		[UseFiltering]
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

		[GraphQLDescription("Get the user by ID.")]
		public UserDto GetUser(Guid id, [Service] IUserRepository repository)
		{
			return repository
				.GetUsers()
				.Select(x => x.ToTransport())
				.FirstOrDefault(x => x.Id == id);
		}
	}
}
