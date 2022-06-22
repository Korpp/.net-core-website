using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant.Skills
{
    public class DetailsModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public DetailsModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

      public ApplicantSkills ApplicantSkills { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ApplicantSkills == null)
            {
                return NotFound();
            }

            var applicantskills = await _context.ApplicantSkills.FirstOrDefaultAsync(m => m.Id == id);
            if (applicantskills == null)
            {
                return NotFound();
            }
            else 
            {
                ApplicantSkills = applicantskills;
            }
            return Page();
        }
    }
}
