using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CvApp.Data.Entities
{
    public class KnownProgramEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }
        [Required(ErrorMessage = "Program adı gereklidir.")]
        [MinLength(2, ErrorMessage = ("Program adı minimum 2 karakter olmalı."))]
        [MaxLength(50, ErrorMessage = ("Program adı maximum 50 karakter olmalı."))]
        public string ProgramName { get; set; } = string.Empty;
        [MaxLength(200, ErrorMessage = ("Açıklama maximum 200 karakter olmalı."))]
        public string ProgramDescription { get; set; } = string.Empty;

        public string fileName { get; set; } = string.Empty;
        public string filePath { get; set; } = string.Empty;
        [ForeignKey(nameof(Person))]
        public int PersonId { get; set; }
        public PersonEntity? Person { get; set; }
        public KnownProgramEntity()
        {
            PersonId = 1;
        }



    }
}
