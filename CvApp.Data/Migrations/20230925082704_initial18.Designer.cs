﻿// <auto-generated />
using System;
using CvApp.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CvApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230925082704_initial18")]
    partial class initial18
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CvApp.Data.Entities.CertificateEntity", b =>
                {
                    b.Property<int>("CertificateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CertificateId"));

                    b.Property<string>("CertificateCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CertificateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CertificateDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CertificateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CertificateId");

                    b.HasIndex("PersonId");

                    b.ToTable("CertificatesTable");
                });

            modelBuilder.Entity("CvApp.Data.Entities.EducationEntity", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationId"));

                    b.Property<decimal?>("DegreeNote")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Department")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EducationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacultyName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PersonEntityId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EducationId");

                    b.HasIndex("PersonEntityId");

                    b.ToTable("EducationsTable");
                });

            modelBuilder.Entity("CvApp.Data.Entities.JobInformationEntity", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<DateTime?>("CompanyCreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanySector")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsContinue")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkingMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.HasIndex("PersonId");

                    b.ToTable("JobInformationsTable");
                });

            modelBuilder.Entity("CvApp.Data.Entities.KnownProgramEntity", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramId"));

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("ProgramDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("programStock")
                        .HasColumnType("int");

                    b.HasKey("ProgramId");

                    b.HasIndex("PersonId");

                    b.ToTable("KnownProgramsTable");
                });

            modelBuilder.Entity("CvApp.Data.Entities.LanguageEntity", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"));

                    b.Property<int?>("LanguageCount")
                        .HasColumnType("int");

                    b.Property<string>("LanguageDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LanguageLevel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.HasIndex("PersonId");

                    b.ToTable("LanguagesTable");
                });

            modelBuilder.Entity("CvApp.Data.Entities.MessageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("SenderEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderSubject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("MessagesTable");
                });

            modelBuilder.Entity("CvApp.Data.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PersonsTable");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("CvApp.Data.Entities.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("ServicesTable");
                });

            modelBuilder.Entity("CvApp.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirtDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hobies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramLınk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LinkedinLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("MSwasDone")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("PasswordConfirm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkypeLınk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserCount")
                        .HasColumnType("int");

                    b.Property<string>("UserDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("fileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("PersonId");

                    b.ToTable("UsersTable");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Adress = "Sample Address",
                            BirtDay = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2023, 9, 25, 11, 27, 4, 609, DateTimeKind.Local).AddTicks(7796),
                            Email = "john@example.com",
                            FacebookLink = "https://facebook.com/johndoe",
                            FirstName = "John",
                            Gender = "Male",
                            Hobies = "Sample Hobbies",
                            InstagramLınk = "https://instagram.com/johndoe",
                            LastName = "Doe",
                            LinkedinLink = "https://linkedin.com/johndoe",
                            Location = "Sample Location",
                            MSwasDone = true,
                            Password = "123456",
                            PasswordConfirm = "",
                            PersonId = 1,
                            PhoneNumber = "1234567890",
                            Roles = "User",
                            SkypeLınk = "https://skype.com/johndoe",
                            TwitterLink = "https://twitter.com/johndoe",
                            UK = "",
                            UserDescription = "Sample description",
                            UserName = "johndoe",
                            fileName = "1684652602676.jpg@",
                            filePath = ""
                        });
                });

            modelBuilder.Entity("CvApp.Data.Entities.CertificateEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", "Person")
                        .WithMany("Certificates")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CvApp.Data.Entities.EducationEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", null)
                        .WithMany("Educations")
                        .HasForeignKey("PersonEntityId");
                });

            modelBuilder.Entity("CvApp.Data.Entities.JobInformationEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", "Person")
                        .WithMany("JobInformation")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CvApp.Data.Entities.KnownProgramEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", "Person")
                        .WithMany("KnownPrograms")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CvApp.Data.Entities.LanguageEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", "Person")
                        .WithMany("Languages")
                        .HasForeignKey("PersonId");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CvApp.Data.Entities.MessageEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CvApp.Data.Entities.ServiceEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CvApp.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("CvApp.Data.Entities.PersonEntity", "Person")
                        .WithMany("Users")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("CvApp.Data.Entities.PersonEntity", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Educations");

                    b.Navigation("JobInformation");

                    b.Navigation("KnownPrograms");

                    b.Navigation("Languages");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
