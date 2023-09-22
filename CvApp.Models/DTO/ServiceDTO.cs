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
    public class ServiceDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? fileName { get; set; } = string.Empty;
        public string? filePath { get; set; } = string.Empty;
        public PersonEntity? Person { get; set; }
        public int PersonId { get; set; }
        public ServiceDTO()
        {
            PersonId = 1;
        }
    }
}
