namespace Demo.HotChocolate.Server.GraphQL.Mapping
{
	using AutoMapper;
	using Demo.HotChocolate.Server.Data.Models;
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

			this.CreateMap<UserDbo, UserDto>()
				.ReverseMap();

			this.CreateMap<GenderDbo, GenderDto>()
				.ReverseMap();
		}
	}
}
