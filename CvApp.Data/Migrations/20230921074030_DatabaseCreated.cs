using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CertificatesTable",
                columns: table => new
                {
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CertificateCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificatesTable", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_CertificatesTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EducationsTable",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FacultyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EducationDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EducationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeNote = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PersonEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsTable", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_EducationsTable_PersonsTable_PersonEntityId",
                        column: x => x.PersonEntityId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobInformationsTable",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsContinue = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    WorkingMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanySector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyCreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInformationsTable", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobInformationsTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnownProgramsTable",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProgramDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownProgramsTable", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_KnownProgramsTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguagesTable",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LanguageDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LanguageLevel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LanguageCount = table.Column<int>(type: "int", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesTable", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_LanguagesTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PasswordConfirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserCount = table.Column<int>(type: "int", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirtDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UK = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MSwasDone = table.Column<bool>(type: "bit", nullable: false),
                    Hobies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UsersTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonsTable",
                column: "Id",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_CertificatesTable_PersonId",
                table: "CertificatesTable",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsTable_PersonEntityId",
                table: "EducationsTable",
                column: "PersonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobInformationsTable_PersonId",
                table: "JobInformationsTable",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownProgramsTable_PersonId",
                table: "KnownProgramsTable",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagesTable_PersonId",
                table: "LanguagesTable",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTable_PersonId",
                table: "UsersTable",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificatesTable");

            migrationBuilder.DropTable(
                name: "EducationsTable");

            migrationBuilder.DropTable(
                name: "JobInformationsTable");

            migrationBuilder.DropTable(
                name: "KnownProgramsTable");

            migrationBuilder.DropTable(
                name: "LanguagesTable");

            migrationBuilder.DropTable(
                name: "UsersTable");

            migrationBuilder.DropTable(
                name: "PersonsTable");
        }
    }
}
