using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CvApp.Data.Entities
{
    public class KnownProgramEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }

        public string? ProgramName { get; set; } = string.Empty;

        public string? ProgramDescription { get; set; } = string.Empty;

        public string? fileName { get; set; } = string.Empty;
        public string? filePath { get; set; } = string.Empty;
        [ForeignKey(nameof(Person))]
        public int? PersonId { get; set; }
        public PersonEntity? Person { get; set; }
        public KnownProgramEntity()
        {
            PersonId = 1;
        }
        public int? programStock { get; set; }



    }
}
