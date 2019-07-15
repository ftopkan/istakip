using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.UI.Models
{
    public class SignUpVm
    {
        [Required]
        public string Email { get; set; }
        
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }

        public string Title { get; set; }
    }
}