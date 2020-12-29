using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymApp.Models.ViewModels
{
    public class ExerciseVM
    {
        public Exercise Exercise { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
