// ----------------------------------------------------------------------------------------
//  <copyright file="UserListType.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL.Types
{
	using Demo.HotChocolate.Server.Transport;
	using global::HotChocolate.Types;

	public class UserListType : ObjectType<ListResultDto<UserDto>>
	{
		/// <inheritdoc />
		protected override void Configure(IObjectTypeDescriptor<ListResultDto<UserDto>> descriptor)
		{
			base.Configure(descriptor);

			descriptor.Field(f => f.Data).Type<ListType<UserType>>();
			descriptor.Field(f => f.TotalCount).Type<IntType>();
		}
	}
}
