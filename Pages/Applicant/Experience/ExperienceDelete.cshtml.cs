using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant.Experience
{
    public class DeleteModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public DeleteModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ApplicantWorkExperience ApplicantWorkExperience { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ApplicantWorkExperiences == null)
            {
                return NotFound();
            }

            var applicantworkexperience = await _context.ApplicantWorkExperiences.FirstOrDefaultAsync(m => m.Id == id);

            if (applicantworkexperience == null)
            {
                return NotFound();
            }
            else 
            {
                ApplicantWorkExperience = applicantworkexperience;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ApplicantWorkExperiences == null)
            {
                return NotFound();
            }
            var applicantworkexperience = await _context.ApplicantWorkExperiences.FindAsync(id);

            if (applicantworkexperience != null)
            {
                ApplicantWorkExperience = applicantworkexperience;
                _context.ApplicantWorkExperiences.Remove(ApplicantWorkExperience);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ExperienceIndex");
        }
    }
}
