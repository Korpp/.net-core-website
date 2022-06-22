using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant.Experience
{
    public class CreateModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public CreateModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ApplicantWorkExperience ApplicantWorkExperience { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ApplicantWorkExperiences == null || ApplicantWorkExperience == null)
            {
                return Page();
            }

            _context.ApplicantWorkExperiences.Add(ApplicantWorkExperience);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ExperienceIndex");
        }
    }
}
