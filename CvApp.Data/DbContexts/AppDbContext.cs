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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            var person1 = new PersonEntity
            {
                Id = 1
            };

            modelBuilder.Entity<PersonEntity>().HasData(person1);

        }
    }

}
