﻿using System.ComponentModel.DataAnnotations;

namespace Finet.Schemas
{
    public class User
    {
        [Key] [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]  
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
