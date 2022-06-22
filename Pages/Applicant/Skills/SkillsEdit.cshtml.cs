using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant.Skills
{
    public class EditModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public EditModel(MyWebPage.Data.MyWebPageContext context)
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

            var applicantskills =  await _context.ApplicantSkills.FirstOrDefaultAsync(m => m.Id == id);
            if (applicantskills == null)
            {
                return NotFound();
            }
            ApplicantSkills = applicantskills;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicantSkills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantSkillsExists(ApplicantSkills.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./SkillsIndex");
        }

        private bool ApplicantSkillsExists(int id)
        {
          return (_context.ApplicantSkills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
