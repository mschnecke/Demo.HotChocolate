﻿namespace Demo.HotChocolate.Server.Data.Migrations
{
	using System;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Infrastructure;

	[DbContext(typeof(UserDbContext))]
	internal class UserDbContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "3.1.1");

			modelBuilder.Entity("Demo.HotChocolate.Server.Data.Models.UserDbo",
				b => {
					b.Property<Guid>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("TEXT");

					b.Property<DateTime>("BirthDate")
						.HasColumnType("TEXT");

					b.Property<string>("Email")
						.HasColumnType("TEXT");

					b.Property<string>("FirstName")
						.HasColumnType("TEXT");

					b.Property<int>("Gender")
						.HasColumnType("INTEGER");

					b.Property<bool>("IsMale")
						.HasColumnType("INTEGER");

					b.Property<string>("LastName")
						.HasColumnType("TEXT");

					b.Property<int>("ZipCode")
						.HasColumnType("INTEGER");

					b.HasKey("Id");

					b.ToTable("Users");
				});
#pragma warning restore 612, 618
		}
	}
}
