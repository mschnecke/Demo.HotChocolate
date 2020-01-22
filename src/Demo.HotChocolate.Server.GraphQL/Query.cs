// ----------------------------------------------------------------------------------------
//  <copyright file="Query.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL
{
	using System.Collections.Generic;
	using System.Linq;
	using AutoMapper.QueryableExtensions;
	using Demo.HotChocolate.Server.Domain;
	using Demo.HotChocolate.Server.GraphQL.Mapping;
	using Demo.HotChocolate.Server.Transport;
	using global::HotChocolate;

	public class Query
	{
		public IEnumerable<UserDto> GetUsers([Service] IUserRepository repository)
		{
			return repository
				.Find()
				.ProjectTo<UserDto>(MappingExtensions.Mapper.ConfigurationProvider)
				.ToList();
		}
	}
}
