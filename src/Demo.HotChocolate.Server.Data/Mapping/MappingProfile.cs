namespace Demo.HotChocolate.Server.Data.Mapping
{
	using AutoMapper;
	using Demo.HotChocolate.Server.Data.Models;
	using Demo.HotChocolate.Server.Domain.Models;

	internal class MappingProfile : Profile
	{
		public MappingProfile()
		{
			this.CreateMap<User, UserDbo>()
				.ReverseMap();

			this.CreateMap<Gender, GenderDbo>()
				.ReverseMap();
		}
	}
}
