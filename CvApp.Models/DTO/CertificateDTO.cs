using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Models.DTO
{
    using global::CvApp.Data.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace CvApp.Data.Entities
    {
        public class CertificateDTO
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int? CertificateId { get; set; }
            [Required(ErrorMessage = "Sertifika adı gereklidir.")]
            public string CertificateName { get; set; } = string.Empty;
            public string fileName { get; set; } = string.Empty;

            [MaxLength(100, ErrorMessage = ("Açıklama maximum 100 karakter olmalı."))]
            public string CertificateDescription { get; set; } = string.Empty;
            [Required(ErrorMessage = "Sertifika alınan kurum bilgisi gereklidir.")]
            public string CertificateCompany { get; set; } = string.Empty;
            public DateTime? CertificateDate { get; set; }
            public int? PersonId { get; set; }

            public string filePath { get; set; } = string.Empty;




        }
    }

}
