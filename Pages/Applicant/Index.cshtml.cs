using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant
{
    public class IndexModel : PageModel
    {
        private readonly MyWebPageContext _context;

        public IndexModel(MyWebPageContext context)
        {
            _context = context;
        }
        public int SearchInt { get; set; }

        public IEnumerable<ApplicantDetails> Details { get; set; } = default!;
        public IEnumerable<ApplicantSkills> Skills { get; set; } = default!;
        public IEnumerable<ApplicantWorkExperience> Experiences { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.ApplicantDetails != null)
            {
                Details = await _context.ApplicantDetails.ToListAsync();
            }
            if (_context.ApplicantSkills != null)
            {
                Skills = await _context.ApplicantSkills.ToListAsync();
            }
            if (_context.ApplicantWorkExperiences != null)
            {
                Experiences = await _context.ApplicantWorkExperiences.ToListAsync();
            }
        }
    }
    
}
