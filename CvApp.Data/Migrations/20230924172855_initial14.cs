using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramLınk",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinLink",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkypeLınk",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "UsersTable");

            migrationBuilder.DropColumn(
                name: "InstagramLınk",
                table: "UsersTable");

            migrationBuilder.DropColumn(
                name: "LinkedinLink",
                table: "UsersTable");

            migrationBuilder.DropColumn(
                name: "SkypeLınk",
                table: "UsersTable");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "UsersTable");
        }
    }
}
