using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wall.Models
{
    // public abstract class BaseEntity {}
    public class Message : BaseEntity
    {

        [Key]
        public int MessageId { get; set; }

        [Required]
        public string MContent { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


        public User user { get; set; }
    }
}