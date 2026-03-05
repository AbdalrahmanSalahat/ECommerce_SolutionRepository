using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? CodeResetPassword { get; set; }
        public DateTime PasswordResetCodeExpiry { get; set; }
    }
}
