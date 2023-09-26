using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Entities
{
    public class FactEntity
    {
        public int Id { get; set; }
        public int? PropertyStock { get; set; }
        public string? PropertyName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public PersonEntity? Person { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public FactEntity() 
        {
            PersonId = 1;
        }
    }
}
