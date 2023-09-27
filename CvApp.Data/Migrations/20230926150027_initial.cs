using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace CvApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PersonsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonsTable", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CertificatesTable",
                columns: table => new
                {
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CertificateName = table.Column<string>(type: "longtext", nullable: false),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
                    CertificateDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    CertificateCompany = table.Column<string>(type: "longtext", nullable: false),
                    CertificateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificatesTable", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_CertificatesTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EducationsTable",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UniversityName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    FacultyName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    EducationDescription = table.Column<string>(type: "longtext", nullable: true),
                    EducationType = table.Column<string>(type: "longtext", nullable: true),
                    EducationLanguage = table.Column<string>(type: "longtext", nullable: true),
                    DegreeNote = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FactsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PropertyStock = table.Column<int>(type: "int", nullable: true),
                    PropertyName = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactsTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobInformationsTable",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StartedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    JobTitle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    JobDescription = table.Column<string>(type: "longtext", nullable: true),
                    IsContinue = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    WorkingMethod = table.Column<string>(type: "longtext", nullable: true),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    CompanyName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    CompanyDescription = table.Column<string>(type: "longtext", nullable: true),
                    CompanyType = table.Column<string>(type: "longtext", nullable: false),
                    CompanySector = table.Column<string>(type: "longtext", nullable: false),
                    CompanyLocation = table.Column<string>(type: "longtext", nullable: false),
                    Country = table.Column<string>(type: "longtext", nullable: true),
                    CompanyCreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInformationsTable", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobInformationsTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KnownProgramsTable",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProgramName = table.Column<string>(type: "longtext", nullable: true),
                    ProgramDescription = table.Column<string>(type: "longtext", nullable: true),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true),
                    programStock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownProgramsTable", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_KnownProgramsTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LanguagesTable",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LanguageName = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    LanguageDescription = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    LanguageLevel = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    LanguageCount = table.Column<int>(type: "int", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesTable", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_LanguagesTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MessagesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SenderName = table.Column<string>(type: "longtext", nullable: true),
                    SenderEmail = table.Column<string>(type: "longtext", nullable: true),
                    SenderSubject = table.Column<string>(type: "longtext", nullable: true),
                    SenderMessage = table.Column<string>(type: "longtext", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagesTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReferancesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ReferanceName = table.Column<string>(type: "longtext", nullable: true),
                    ReferanceTitle = table.Column<string>(type: "longtext", nullable: true),
                    ReferanceDescription = table.Column<string>(type: "longtext", nullable: true),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicesTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesTable_PersonsTable_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    PasswordConfirm = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false),
                    UserDescription = table.Column<string>(type: "longtext", nullable: true),
                    UserCount = table.Column<int>(type: "int", nullable: true),
                    fileName = table.Column<string>(type: "longtext", nullable: true),
                    filePath = table.Column<string>(type: "longtext", nullable: true),
                    BirtDay = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Location = table.Column<string>(type: "longtext", nullable: true),
                    UK = table.Column<string>(type: "longtext", nullable: true),
                    Gender = table.Column<string>(type: "longtext", nullable: true),
                    MSwasDone = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Hobies = table.Column<string>(type: "longtext", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Roles = table.Column<string>(type: "longtext", nullable: false),
                    Adress = table.Column<string>(type: "longtext", nullable: true),
                    TwitterLink = table.Column<string>(type: "longtext", nullable: true),
                    FacebookLink = table.Column<string>(type: "longtext", nullable: true),
                    InstagramLınk = table.Column<string>(type: "longtext", nullable: true),
                    SkypeLınk = table.Column<string>(type: "longtext", nullable: true),
                    LinkedinLink = table.Column<string>(type: "longtext", nullable: true)
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
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PersonsTable",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "UsersTable",
                columns: new[] { "UserId", "Adress", "BirtDay", "CreatedAt", "Email", "FacebookLink", "FirstName", "Gender", "Hobies", "InstagramLınk", "LastName", "LinkedinLink", "Location", "MSwasDone", "Password", "PasswordConfirm", "PersonId", "PhoneNumber", "Roles", "SkypeLınk", "TwitterLink", "UK", "UserCount", "UserDescription", "UserName", "fileName", "filePath" },
                values: new object[] { 1, "Sample Address", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 26, 18, 0, 26, 992, DateTimeKind.Local).AddTicks(7594), "john@example.com", "https://facebook.com/johndoe", "John", "Male", "Sample Hobbies", "https://instagram.com/johndoe", "Doe", "https://linkedin.com/johndoe", "Sample Location", true, "123456", "", 1, "1234567890", "User", "https://skype.com/johndoe", "https://twitter.com/johndoe", "", null, "Sample description", "johndoe", "1684652602676.jpg@", "" });

            migrationBuilder.CreateIndex(
                name: "IX_CertificatesTable_PersonId",
                table: "CertificatesTable",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsTable_PersonEntityId",
                table: "EducationsTable",
                column: "PersonEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FactsTable_PersonId",
                table: "FactsTable",
                column: "PersonId");

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
                name: "IX_MessagesTable_PersonId",
                table: "MessagesTable",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferancesTable_PersonId",
                table: "ReferancesTable",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesTable_PersonId",
                table: "ServicesTable",
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
                name: "FactsTable");

            migrationBuilder.DropTable(
                name: "JobInformationsTable");

            migrationBuilder.DropTable(
                name: "KnownProgramsTable");

            migrationBuilder.DropTable(
                name: "LanguagesTable");

            migrationBuilder.DropTable(
                name: "MessagesTable");

            migrationBuilder.DropTable(
                name: "ReferancesTable");

            migrationBuilder.DropTable(
                name: "ServicesTable");

            migrationBuilder.DropTable(
                name: "UsersTable");

            migrationBuilder.DropTable(
                name: "PersonsTable");
        }
    }
}
