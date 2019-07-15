using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.Models
{
    public class ChangePasswordVm
    {
        
        public string Password { get; set; }
        
        public string NewPassword { get; set; }
        
        public string NewPasswordConfirm { get; set; }
    }
}