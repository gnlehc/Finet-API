﻿using System.ComponentModel.DataAnnotations;

namespace Finet.Model.Requests
{
    public class LoginRequest
    {
        [Required] 
        public string? Email { get; set; }

        [Required] 
        public string? Password { get; set; }
    }
}
