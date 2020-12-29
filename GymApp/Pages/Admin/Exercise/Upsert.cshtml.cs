using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApp.DataAccess.Data.Repository.IRepository;
using GymApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymApp.Pages.Admin.Exercise
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnviroment = hostingEnvironment;
        }
        [BindProperty]
        public ExerciseVM ExerciseObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            ExerciseObj = new ExerciseVM
            {
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                Exercise = new Models.Exercise()
            };
            if (id != null)
            {
                ExerciseObj.Exercise = _unitOfWork.Exercise.GetFirstOrDefault(u => u.Id == id);
                if (ExerciseObj.Exercise == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            string webRootPath = _hostingEnviroment.WebRootPath;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (ExerciseObj.Exercise.Id == 0)
            {
                _unitOfWork.Exercise.Add(ExerciseObj.Exercise);
            }
            else
            {
                _unitOfWork.Exercise.Update(ExerciseObj.Exercise);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }



    }
}
