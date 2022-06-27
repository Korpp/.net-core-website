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
namespace MyWebPage.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly MyWebPage.Data.MyWebPageContext _context;
        private readonly IWebHostEnvironment _hostenvironment;
        public CreateModel(MyWebPage.Data.MyWebPageContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostenvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public FileViewModel FileUpload { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.AppFiles == null || FileUpload == null)
            {
                return Page();
            }
            if (FileUpload.FormFile != null)
            {
                using (var stream = new FileStream(Path.Combine(_hostenvironment.WebRootPath, "images", FileUpload.FormFile.FileName), FileMode.Create))
                {
                    await FileUpload.FormFile.CopyToAsync(stream);
                    var file = new AppFile()
                    {
                        FileName = FileUpload.FormFile.FileName
                    };
                    _context.AppFiles.Add(file);
                }
               /* using (var memoryStream = new MemoryStream())
                {
                    await FileUpload.FormFile.CopyToAsync(memoryStream);
                    if (memoryStream.Length > 2097152)
                    {
                        var file = new AppFile()
                        {
                            FileName = FileUpload.FormFile.FileName
                        };
                       
                    }
                    else
                    {
                        ModelState.AddModelError("File", "The file is too large.");
                    }
                }*/
            }


           
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
