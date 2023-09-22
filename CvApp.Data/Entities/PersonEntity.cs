using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Entities
{
    public class PersonEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ICollection<EducationEntity>? Educations { get; set; }
        public ICollection<JobInformationEntity>? JobInformation { get; set; }
        public ICollection<LanguageEntity>? Languages { get; set; }
        public ICollection<KnownProgramEntity>? KnownPrograms { get; set; }
        public ICollection<CertificateEntity>? Certificates { get; set; }
        public ICollection<UserEntity>? Users { get; set; }



    }
}
