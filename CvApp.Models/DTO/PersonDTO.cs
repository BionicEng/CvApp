
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvApp.Models.DTO.CvApp.Data.Entities;

namespace CvApp.Models.DTO
{
    public class PersonDTO
    {

        public int Id { get; set; }

        public ICollection<EducationDTO>? Educations { get; set; }
        public ICollection<JobInformationDTO>? JobInformation { get; set; }
        public ICollection<LanguageDTO>? Languages { get; set; }
        public ICollection<KnownProgramDTO>? KnownPrograms { get; set; }
        public ICollection<CertificateDTO>? Certificates { get; set; }
       public ICollection<UserDTO>? Users { get; set; }

    }
}
