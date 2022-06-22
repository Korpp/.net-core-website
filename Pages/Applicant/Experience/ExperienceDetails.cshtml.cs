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
    public class DetailsModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public DetailsModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

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
    }
}
