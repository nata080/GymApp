using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GymApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa Kategorii")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "L.P.")]
        public int DisplayOrder { get; set; }
    }
}
