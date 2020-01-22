// ----------------------------------------------------------------------------------------
//  <copyright file="MappingProfile.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL.Mapping
{
	using AutoMapper;
	using Demo.HotChocolate.Server.Domain.Models;
	using Demo.HotChocolate.Server.Transport;

	internal class MappingProfile : Profile
	{
		public MappingProfile()
		{
			this.CreateMap<User, UserDto>()
				.ReverseMap();

			this.CreateMap<Gender, GenderDto>()
				.ReverseMap();
		}
	}
}
