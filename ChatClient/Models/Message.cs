using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    [Table("MessagesTable")]
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string RecipientId { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeMsgCreated { get; set; }
    }
}

