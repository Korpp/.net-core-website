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
    public class DeleteModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public DeleteModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ApplicantDetails == null)
            {
                return NotFound();
            }
            var applicantdetails = await _context.ApplicantDetails.FindAsync(id);

            if (applicantdetails != null)
            {
                ApplicantDetails = applicantdetails;
                _context.ApplicantDetails.Remove(ApplicantDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./DetailsIndex");
        }
    }
}
