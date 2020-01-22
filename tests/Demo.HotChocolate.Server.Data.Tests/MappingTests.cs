// ----------------------------------------------------------------------------------------
//  <copyright file="MappingTests.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data.Tests
{
	using System;
	using AutoMapper;
	using Demo.HotChocolate.Server.Data.Mapping;
	using Demo.HotChocolate.Server.Domain.Models;
	using FluentAssertions;
	using Xunit;

	public class MappingTests
	{
		public MappingTests()
		{
			this.mapper =
				new MapperConfiguration(cfg => {
					                        cfg.AddProfile<MappingProfile>();
				                        })
					.CreateMapper();
		}

		private readonly IMapper mapper;

		[Fact]
		public void ShouldAssertConfigurationIsValid()
		{
			this.mapper?.ConfigurationProvider.AssertConfigurationIsValid();
		}

		[Fact]
		public void SimpleUserMappingShouldNotAssert()
		{
			// arrange
			var expected = new User();
			expected.BirthDate = DateTime.Now;
			expected.Email = "sgdhjgd@sgehs.fr";
			expected.FirstName = "First";
			expected.LastName = "Last";
			expected.Gender = Gender.Female;
			expected.ZipCode = 12345;

			// act
			var entity = expected.ToEntity();
			var result = entity.ToModel();

			// assert
			result.BirthDate.Should().Be(expected.BirthDate);
			result.Email.Should().Be(expected.Email);
			result.FirstName.Should().Be(expected.FirstName);
			result.LastName.Should().Be(expected.LastName);
			result.Gender.Should().Be(expected.Gender);
			result.ZipCode.Should().Be(expected.ZipCode);
		}
	}
}
