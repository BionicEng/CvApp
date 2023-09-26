using CvApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Models.DTO
{
    public class FactDTO
    {
        public int Id { get; set; }
        public int? PropertyStock { get; set; }
        public string? PropertyName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public int PersonId { get; set; }
        public FactDTO()
        {
            PersonId = 1;
        }
    }
}
