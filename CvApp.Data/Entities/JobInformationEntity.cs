using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Entities
{
    public class JobInformationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public DateTime? StartedTime { get; set; }
        public DateTime? EndTime { get; set; }
        [Required(ErrorMessage = "Ünvan gereklidir.")]
        [MinLength(2, ErrorMessage = ("Ünvan adı minimum 2 karakter olmalı."))]
        [MaxLength(50, ErrorMessage = ("Ünvan adı maximum 50 karakter olmalı."))]
        public string? JobTitle { get; set; } = string.Empty;
        public string? JobDescription { get; set; } = string.Empty;
        public bool? IsContinue { get; set; }
        public int? CompanyId { get; set; }
        public string? WorkingMethod { get; set; } = string.Empty;

        public string? fileName { get; set; } = string.Empty;
        public string? filePath { get; set; } = string.Empty;

        [ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }
        public PersonEntity? Person { get; set; }
        public JobInformationEntity()
        {
            PersonId = 1;
            
        }


        [Required(ErrorMessage = "Şirket adı gereklidir.")]
        [MinLength(2, ErrorMessage = ("Şirket adı minimum 2 karakter olmalı."))]
        [MaxLength(50, ErrorMessage = ("Şirket adı maximum 50 karakter olmalı."))]
        public string? CompanyName { get; set; } = string.Empty;
        public string? CompanyDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şirket Tipi bilgisi gereklidir.")]
        public string? CompanyType { get; set; } = string.Empty;
        [Required(ErrorMessage = "Sektör bilgisi gereklidir.")]
        public string? CompanySector { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şehir bilgisi gereklidir.")]
        public string? CompanyLocation { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public DateTime? CompanyCreatedTime { get; set; }
    }
}
