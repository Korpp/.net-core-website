using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

      /*[BindProperty]
        public FileViewModel FileUpload { get; set; }*/

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Items == null || Item == null)
            {
                return Page();
            }
   
            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
