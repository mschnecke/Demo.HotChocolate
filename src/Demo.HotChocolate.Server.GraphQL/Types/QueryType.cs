// ----------------------------------------------------------------------------------------
//  <copyright file="QueryType.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL.Types
{
	using Demo.HotChocolate.Server.GraphQL.Resolver;
	using global::HotChocolate.Types;

	public class QueryType : ObjectType
	{
		/// <inheritdoc />
		protected override void Configure(IObjectTypeDescriptor descriptor)
		{
			base.Configure(descriptor);
			descriptor.Name("Query");

			descriptor
				.Field<UserResolver>(x => x.GetUsers(default, default))
				.Name("users")
				.Type<ListType<NonNullType<UserType>>>()
				.Argument("skip", x => x.Type<IntType>())
				.Argument("take", x => x.Type<IntType>())
				.UseFiltering()
				.UseSorting()
				;
		}
	}
}
