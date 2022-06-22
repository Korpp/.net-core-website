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
    public class IndexModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public IndexModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

        public IList<ApplicantWorkExperience> ApplicantWorkExperience { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ApplicantWorkExperiences != null)
            {
                ApplicantWorkExperience = await _context.ApplicantWorkExperiences.ToListAsync();
            }
        }
    }
}
