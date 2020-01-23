// ----------------------------------------------------------------------------------------
//  <copyright file="UserResolver.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL.Resolver
{
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

		public ListResultDto<UserDto> GetUsers(int? skip, int? take)
		{
			var query = this.repository
				.GetUsers();

			var list = new ListResultDto<UserDto>();
			list.TotalCount = query.Count();

			if (skip.HasValue)
			{
				query = query.Skip(skip.Value);
			}

			if (take.HasValue)
			{
				query = query.Take(take.Value);
			}

			list.Data = query
				.Select(x => x.ToTransport())
				.ToList();

			return list;
		}
	}
}
