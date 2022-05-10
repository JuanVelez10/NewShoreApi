using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;

namespace Domain.Entities
{
    public class Message
    {
        [Required]
        public int Code { get; set; }

        [Required]
        public MessageType MessageType { get; set; }

        [Required]
        public string? Text { get; set; }
    }
}
