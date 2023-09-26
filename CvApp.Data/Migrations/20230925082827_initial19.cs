using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReferancesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferanceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferanceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferanceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferancesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferancesTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "UsersTable",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 25, 11, 28, 27, 661, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.CreateIndex(
                name: "IX_ReferancesTable_PersonId",
                table: "ReferancesTable",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReferancesTable");

            migrationBuilder.UpdateData(
                table: "UsersTable",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 9, 25, 11, 27, 4, 609, DateTimeKind.Local).AddTicks(7796));
        }
    }
}
