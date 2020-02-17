﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChatClient.Models
{
    [Table("ImagesTable")]
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
