
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CvApp.Data.Entities;

namespace CvApp.Models.DTO
{
    public class KnownProgramDTO
    {
        public int ProgramId { get; set; }

        public string? ProgramName { get; set; } = string.Empty;

        public string? ProgramDescription { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public string? fileName { get; set; } = string.Empty;
        public KnownProgramDTO()
        {
            PersonId = 1;
        }
        public string filePath { get; set; } = string.Empty;
        public int? programStock { get; set; }

    }
}
