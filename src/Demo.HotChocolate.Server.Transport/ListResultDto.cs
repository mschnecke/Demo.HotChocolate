// ----------------------------------------------------------------------------------------
//  <copyright file="ListResultDto.cs" company="pisum.net">
//     Copyright (c) 2020, pisum.net. All rights reserved.
//  </copyright>
// ----------------------------------------------------------------------------------------

namespace Demo.HotChocolate.Server.Transport
{
	using System.Collections.Generic;

	/// <summary>
	/// The list result.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ListResultDto<T>
	{
		/// <summary>
		/// The data collection.
		/// </summary>
		public IEnumerable<T> Data { get; set; }

		/// <summary>
		/// The total count.
		/// </summary>
		public int TotalCount { get; set; }
	}
}
