// ----------------------------------------------------------------------------------------
//  <copyright file="UserType.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.GraphQL.Types
{
	using Demo.HotChocolate.Server.Transport;
	using global::HotChocolate.Types;

	public class UserType : ObjectType<UserDto>
	{
	}
}
