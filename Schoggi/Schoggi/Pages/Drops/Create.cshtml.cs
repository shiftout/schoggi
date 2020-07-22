using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schoggi.Data;
using Schoggi.Models;

namespace Schoggi.Pages.Drops
{
    public class CreateModel : PageModel
    {
        private readonly Schoggi.Data.SchoggiContext _context;

        public CreateModel(Schoggi.Data.SchoggiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Drop Drop { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            Drop.CreatedDate = DateTime.Now;

            _context.Drop.Add(Drop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
