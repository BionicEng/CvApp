using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class FilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "UsersTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "LanguagesTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "KnownProgramsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "JobInformationsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "EducationsTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "filePath",
                table: "CertificatesTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "filePath",
                table: "UsersTable");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "LanguagesTable");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "KnownProgramsTable");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "JobInformationsTable");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "EducationsTable");

            migrationBuilder.DropColumn(
                name: "filePath",
                table: "CertificatesTable");
        }
    }
}
