﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TekGain.DAL.Entities
{
    public class SignUp
    {
        // Implement the properties here
        [Required(ErrorMessage = "First name required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email address required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}