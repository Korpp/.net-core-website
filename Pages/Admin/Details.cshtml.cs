using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
using MyWebPage.Models;

namespace MyWebPage.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;

        public DetailsModel(MyWebPage.Data.MyWebPageContext context)
        {
            _context = context;
        }

      public AppFile AppFile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AppFiles == null)
            {
                return NotFound();
            }

            var appfile = await _context.AppFiles.FirstOrDefaultAsync(m => m.Id == id);
            if (appfile == null)
            {
                return NotFound();
            }
            else 
            {
                AppFile = appfile;
            }
            return Page();
        }
    }
}
