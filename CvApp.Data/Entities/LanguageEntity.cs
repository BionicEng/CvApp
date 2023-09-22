using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Entities
{
    public class LanguageEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId{ get; set; }
        [Required(ErrorMessage = "Dil bilgisi girişi gereklidir.")]
        [MinLength(2, ErrorMessage = ("Dil adı minimum 2 karakter olmalı."))]
        [MaxLength(15, ErrorMessage = ("Dil adı maximum 15 karakter olmalı."))]
        public string LanguageName { get; set; } = string.Empty;
        [MaxLength(200, ErrorMessage = ("Açıklama maximum 100 karakter olmalı."))]
        public string LanguageDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Dil seviyesi girişi gereklidir.")]
        [MinLength(2, ErrorMessage = ("Dil seviyesi minimum 2 karakter olmalı."))]
        [MaxLength(15, ErrorMessage = ("Dil seviyesi maximum 15 karakter olmalı."))]
        public string LanguageLevel { get; set; } = string.Empty;
        public int LanguageCount { get; set; }
        public string filePath { get; set; } = string.Empty;
        public string fileName { get; set; } = string.Empty;
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public PersonEntity? Person { get; set; }
    }
}
