﻿using System.ComponentModel.DataAnnotations;

namespace TrainHoppersTARpe23.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember login?")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
