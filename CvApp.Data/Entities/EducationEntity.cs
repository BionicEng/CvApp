using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Entities
{
    public class EducationEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EducationId { get; set; }
        [Required(ErrorMessage = ("Okul adı gereklidir."))]
        [MinLength(2, ErrorMessage = ("Okul adı minimum 2 karakter olmalı."))]
        [MaxLength(50, ErrorMessage = ("Okul adı maximum 50 karakter olmalı."))]
        public string? UniversityName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = ("Fakülte adı maximum 50 karakter olmalı."))]
        public string? FacultyName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = ("Bölüm adı maximum 50 karakter olmalı."))]
        public string? Department { get; set; } = string.Empty;
        public string? EducationDescription { get; set; } = string.Empty;
        public string? EducationType { get; set; } = string.Empty;
        public string? EducationLanguage { get; set; } = string.Empty;
        public decimal? DegreeNote { get; set; }
        public DateTime StartedTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? fileName { get; set; } = string.Empty;
        public string? filePath { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public EducationEntity()
        {
            PersonId = 1;
        }
    }
}
