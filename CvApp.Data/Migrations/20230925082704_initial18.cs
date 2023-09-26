using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UsersTable",
                columns: new[] { "UserId", "Adress", "BirtDay", "CreatedAt", "Email", "FacebookLink", "FirstName", "Gender", "Hobies", "InstagramLınk", "LastName", "LinkedinLink", "Location", "MSwasDone", "Password", "PasswordConfirm", "PersonId", "PhoneNumber", "Roles", "SkypeLınk", "TwitterLink", "UK", "UserCount", "UserDescription", "UserName", "fileName", "filePath" },
                values: new object[] { 1, "Sample Address", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 25, 11, 27, 4, 609, DateTimeKind.Local).AddTicks(7796), "john@example.com", "https://facebook.com/johndoe", "John", "Male", "Sample Hobbies", "https://instagram.com/johndoe", "Doe", "https://linkedin.com/johndoe", "Sample Location", true, "123456", "", 1, "1234567890", "User", "https://skype.com/johndoe", "https://twitter.com/johndoe", "", null, "Sample description", "johndoe", "1684652602676.jpg@", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersTable",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
