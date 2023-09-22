using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvApp.Data.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string? SenderName { get; set; } = string.Empty;
        public string? SenderEmail { get; set; } = string.Empty;
        public string? SenderSubject { get; set; } = string.Empty;
        public string? SenderMessage { get; set; } = string.Empty;
        public PersonEntity? Person { get; set; }
        public int PersonId { get; set; }
        public MessageEntity()
        {
            PersonId = 1;
        }

    }
}
