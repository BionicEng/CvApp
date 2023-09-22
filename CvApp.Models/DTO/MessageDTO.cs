using CvApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Models.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string? SenderName { get; set; } = string.Empty;
        public string? SenderEmail { get; set; } = string.Empty;
        public string? SenderSubject { get; set; } = string.Empty;
        public string? SenderMessage { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public MessageDTO()
        {
            PersonId = 1;
        }

    }
}
