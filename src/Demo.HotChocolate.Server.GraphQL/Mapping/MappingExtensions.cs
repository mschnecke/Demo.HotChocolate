// ----------------------------------------------------------------------------------------
//  <copyright file="MappingExtensions.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Demo.HotChocolate.Server.GraphQL.Tests")]

namespace Demo.HotChocolate.Server.GraphQL.Mapping
{
	using AutoMapper;
	using Demo.HotChocolate.Server.Domain.Models;
	using Demo.HotChocolate.Server.Transport;

	internal static class MappingExtensions
	{
		static MappingExtensions()
		{
			Mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>())
				.CreateMapper();
		}

		internal static IMapper Mapper { get; }

		public static User ToModel(this UserDto dto)
		{
			return dto == null ? null : Mapper.Map<User>(dto);
		}

		public static UserDto ToTransport(this User model)
		{
			return model == null ? null : Mapper.Map<UserDto>(model);
		}
	}
}
