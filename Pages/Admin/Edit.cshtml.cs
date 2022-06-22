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

namespace MyWebPage.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public EditModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppFile AppFile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AppFiles == null)
            {
                return NotFound();
            }

            var appfile =  await _context.AppFiles.FirstOrDefaultAsync(m => m.Id == id);
            if (appfile == null)
            {
                return NotFound();
            }
            AppFile = appfile;
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

            _context.Attach(AppFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppFileExists(AppFile.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppFileExists(int id)
        {
          return (_context.AppFiles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
