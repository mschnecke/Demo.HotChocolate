// ----------------------------------------------------------------------------------------
//  <copyright file="MappingProfile.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data.Mapping
{
	using AutoMapper;
	using Demo.HotChocolate.Server.Data.Models;
	using Demo.HotChocolate.Server.Domain.Models;

	internal class MappingProfile : Profile
	{
		public MappingProfile()
		{
			this.CreateMap<User,UserDbo>()
				.ReverseMap();

			this.CreateMap<Gender,GenderDbo>()
				.ReverseMap();
		}
	}
}
