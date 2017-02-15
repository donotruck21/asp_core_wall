using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wall.Models
{
    // public abstract class BaseEntity {}
    public class Comment : BaseEntity
    {

        [Key]
        public int CommentId { get; set; }

        [Required]
        public string CContent { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }



        public User user { get; set; }

        public Message message { get; set; }
    }
}