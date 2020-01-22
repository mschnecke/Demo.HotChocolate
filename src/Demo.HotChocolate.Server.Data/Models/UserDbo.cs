// ----------------------------------------------------------------------------------------
//  <copyright file="UserDbo.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Data.Models
{
	using System;

	internal class UserDbo
	{
		
		public DateTime BirthDate { get; set; }

		
		public string Email { get; set; }

		
		public string FirstName { get; set; }

		
		public GenderDbo Gender { get; set; }

		
		public Guid Id { get; set; } = Guid.NewGuid();

		
		public bool IsMale { get; set; }

		
		public string LastName { get; set; } = string.Empty;

		
		public int ZipCode { get; set; }
	}
}
