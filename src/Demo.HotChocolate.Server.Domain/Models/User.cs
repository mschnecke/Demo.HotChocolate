﻿// ----------------------------------------------------------------------------------------
//  <copyright file="User.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Domain.Models
{
	using System;
	using System.Linq;
	using global::HotChocolate;
	using global::HotChocolate.Types;

	/// <summary>
	/// The user.
	/// </summary>
	public class User : ObjectType<User>
	{

		protected override void Configure(IObjectTypeDescriptor<User> descriptor)
		{
			descriptor.AsNode()
				.IdField(t => t.Id)
				.NodeResolver(async (ctx, id) =>
					ctx.Service<IUserRepository>().GetUser(id).ToList().ElementAt(0));
		}
		/// <summary>
		/// Gets or sets the birth date.
		/// </summary>
		/// <value>
		/// The birth date.
		/// </value>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>
		/// The email.
		/// </value>
		public string Email { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		/// <value>
		/// The first name.
		/// </value>
		public string FirstName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		public Gender Gender { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Gets or sets a value indicating whether this user is male or not.
		/// </summary>
		/// <value>
		///   <c>true</c> if this user is male; otherwise, <c>false</c>.
		/// </value>
		public bool IsMale { get; set; }

		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		/// <value>
		/// The last name.
		/// </value>
		public string LastName { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the zip code.
		/// </summary>
		/// <value>
		/// The zip code.
		/// </value>
		public int ZipCode { get; set; }
	}
}
