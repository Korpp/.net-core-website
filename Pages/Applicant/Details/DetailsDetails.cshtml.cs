using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant.Details
{
    public class DetailsModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public DetailsModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

      public ApplicantDetails ApplicantDetails { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ApplicantDetails == null)
            {
                return NotFound();
            }

            var applicantdetails = await _context.ApplicantDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (applicantdetails == null)
            {
                return NotFound();
            }
            else 
            {
                ApplicantDetails = applicantdetails;
            }
            return Page();
        }
    }
}
