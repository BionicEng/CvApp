using CvApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CertificateEntity> CertificatesTable { get; set; }
        public DbSet<EducationEntity> EducationsTable { get; set; }
        public DbSet<JobInformationEntity> JobInformationsTable { get; set; }
        public DbSet<KnownProgramEntity> KnownProgramsTable { get; set; }
        public DbSet<LanguageEntity> LanguagesTable { get; set; }
        public DbSet<PersonEntity> PersonsTable { get; set; }
        public DbSet<UserEntity> UsersTable { get; set; }
        public DbSet<ServiceEntity> ServicesTable { get; set; }
        public DbSet<MessageEntity> MessagesTable { get; set; }
        public DbSet<ReferanceEntity> ReferancesTable { get; set; }
        public DbSet<FactEntity> FactsTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            var person1 = new PersonEntity
            {
                Id = 1
            };
            var users = new List<UserEntity>
            {
                new UserEntity
                {
                    UserId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    Password = "123456",
                    UserName = "johndoe",
                    PhoneNumber = "1234567890",
                    UserDescription = "Sample description",
                    BirtDay = new DateTime(1990, 1, 1),
                    Location = "Sample Location",
                    Gender = "Male",
                    MSwasDone = true,
                    Hobies = "Sample Hobbies",
                    Roles = "User",
                    Adress = "Sample Address",
                    TwitterLink = "https://twitter.com/johndoe",
                    FacebookLink = "https://facebook.com/johndoe",
                    InstagramLınk = "https://instagram.com/johndoe",
                    SkypeLınk = "https://skype.com/johndoe",
                    LinkedinLink = "https://linkedin.com/johndoe",
                    fileName = "1684652602676.jpg@"
                },
                // Diğer kullanıcılar buraya eklenir...
            };

            modelBuilder.Entity<UserEntity>().HasData(users);


            modelBuilder.Entity<PersonEntity>().HasData(person1);

        }
    }

}
