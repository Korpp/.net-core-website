﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Applicant.Details
{
    public class EditModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public EditModel(MyWebPage.Data.MyWebPageContext context)
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

            var applicantdetails =  await _context.ApplicantDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (applicantdetails == null)
            {
                return NotFound();
            }
            ApplicantDetails = applicantdetails;
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

            _context.Attach(ApplicantDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantDetailsExists(ApplicantDetails.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./DetailsIndex");
        }

        private bool ApplicantDetailsExists(int id)
        {
          return (_context.ApplicantDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}