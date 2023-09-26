using CvApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Models.DTO
{
    public class ReferanceDTO
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ReferanceName { get; set; } = string.Empty;
        public string? ReferanceTitle { get; set; } = string.Empty;
        public string? ReferanceDescription { get; set; } = string.Empty;
        public string? fileName { get; set; } = string.Empty;
        public string? filePath { get; set; } = string.Empty;

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public ReferanceDTO()
        {
            PersonId = 1;
        }
    }
}
