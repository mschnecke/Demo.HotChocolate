namespace Demo.HotChocolate.Server.Data.Migrations
{
	using System;
	using Microsoft.EntityFrameworkCore.Migrations;

	public partial class CreateInitSchema : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				"Users",
				table => new {
					             Id = table.Column<Guid>(),
					             BirthDate = table.Column<DateTime>(),
					             Email = table.Column<string>(nullable: true),
					             FirstName = table.Column<string>(nullable: true),
					             Gender = table.Column<int>(),
					             IsMale = table.Column<bool>(),
					             LastName = table.Column<string>(nullable: true),
					             ZipCode = table.Column<int>()
				             },
				constraints: table => {
					             table.PrimaryKey("PK_Users", x => x.Id);
				             });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				"Users");
		}
	}
}
