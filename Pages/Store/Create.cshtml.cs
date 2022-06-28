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
using MyWebPage.ViewModel;

namespace MyWebPage.Pages.Store
{
    public class CreateModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;
        //private readonly IWebHostEnvironment _hostenvironment;
        public CreateModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<AppFile> Files { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.AppFiles != null)
            {
                Files = await _context.AppFiles.ToListAsync();
            }
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Items == null || Item == null)
            {
                return Page();
            }
            if (_context.AppFiles != null)
            {
                Files = await _context.AppFiles.ToListAsync();
            }
            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
