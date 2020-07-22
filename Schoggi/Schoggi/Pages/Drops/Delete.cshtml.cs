using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schoggi.Data;
using Schoggi.Models;

namespace Schoggi.Pages.Drops
{
    public class DeleteModel : PageModel
    {
        private readonly Schoggi.Data.SchoggiContext _context;

        public DeleteModel(Schoggi.Data.SchoggiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Drop Drop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drop = await _context.Drop.FirstOrDefaultAsync(m => m.ID == id);

            if (Drop == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drop = await _context.Drop.FindAsync(id);

            if (Drop != null)
            {
                _context.Drop.Remove(Drop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
