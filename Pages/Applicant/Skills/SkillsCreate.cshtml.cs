using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant.Skills
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
        public ApplicantSkills ApplicantSkills { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ApplicantSkills == null || ApplicantSkills == null)
            {
                return Page();
            }

            _context.ApplicantSkills.Add(ApplicantSkills);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SkillsIndex");
        }
    }
}
