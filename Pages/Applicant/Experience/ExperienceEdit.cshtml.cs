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

namespace MyWebPage.Pages.Applicant.Experience
{
    public class EditModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public EditModel(MyWebPage.Data.MyWebPageContext context)
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

            var applicantworkexperience =  await _context.ApplicantWorkExperiences.FirstOrDefaultAsync(m => m.Id == id);
            if (applicantworkexperience == null)
            {
                return NotFound();
            }
            ApplicantWorkExperience = applicantworkexperience;
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

            _context.Attach(ApplicantWorkExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantWorkExperienceExists(ApplicantWorkExperience.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ExperienceIndex");
        }

        private bool ApplicantWorkExperienceExists(int id)
        {
          return (_context.ApplicantWorkExperiences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
