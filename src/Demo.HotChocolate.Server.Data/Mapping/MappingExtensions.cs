// ----------------------------------------------------------------------------------------
//  <copyright file="MappingExtensions.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Demo.HotChocolate.Server.Data.Tests")]

namespace Demo.HotChocolate.Server.Data.Mapping
{
	using AutoMapper;
	using AutoMapper.Extensions.ExpressionMapping;
	using Demo.HotChocolate.Server.Data.Models;
	using Demo.HotChocolate.Server.Domain.Models;

	internal static class MappingExtensions
	{

		internal static IMapper Mapper { get; }
		static MappingExtensions()
		{
			Mapper = new MapperConfiguration(cfg => {
				                                 cfg.AddExpressionMapping();
				                                 cfg.AddProfile<MappingProfile>();
			                                 })
				.CreateMapper();
		}

		public static User ToModel(this UserDbo entity)
		{
			return entity == null ? null : Mapper.Map<User>(entity);
		}

		public static UserDbo ToEntity(this User model)
		{
			return model == null ? null : Mapper.Map<UserDbo>(model);
		}
	}
}
