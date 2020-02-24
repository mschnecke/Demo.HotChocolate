namespace Demo.HotChocolate.Server.Extensions
{
	using Bogus.DataSets;
	using Demo.HotChocolate.Server.Domain.Models;

	internal static class SeedDataExtensions
	{
		public static Gender ToModel(this Name.Gender bogus)
		{
			switch (bogus)
			{
				case Name.Gender.Male:
					return Gender.Male;
				case Name.Gender.Female:
					return Gender.Female;
				default:
					return Gender.Male;
			}
		}
	}
}
