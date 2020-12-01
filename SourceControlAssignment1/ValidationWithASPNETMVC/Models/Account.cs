using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ValidationWithASPNETMVC.Models
{
    public class Account
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Username
        {
            get;
            set;
        }
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Password
        {
            get;
            set;
        }
        [Required]
        public string FullName
        {
            get;
            set;
        }
        [Required]
        [Range(18, 50)]
        public int Age
        {
            get;
            set;
        }
        [Required]
        [EmailAddress]
        public string Email
        {
            get;
            set;
        }
        [Url]
        public string Website
        {
            get;
            set;
        }
    }
}