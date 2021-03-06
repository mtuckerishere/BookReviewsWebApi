﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Models
{
    public class Reviewer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="Name must be less than 100 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage ="Last Name must be less than 200 characters.")]
        public string LastName { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
