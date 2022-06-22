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
    public class DeleteModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public DeleteModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ApplicantSkills == null)
            {
                return NotFound();
            }
            var applicantskills = await _context.ApplicantSkills.FindAsync(id);

            if (applicantskills != null)
            {
                ApplicantSkills = applicantskills;
                _context.ApplicantSkills.Remove(ApplicantSkills);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./SkillsIndex");
        }
    }
}
