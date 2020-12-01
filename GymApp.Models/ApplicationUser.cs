using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymApp.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name="Imię")]
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Height { get; set; }
    }
}
