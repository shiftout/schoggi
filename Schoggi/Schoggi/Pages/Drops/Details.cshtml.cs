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
    public class DetailsModel : PageModel
    {
        private readonly Schoggi.Data.SchoggiContext _context;

        public DetailsModel(Schoggi.Data.SchoggiContext context)
        {
            _context = context;
        }

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
    }
}
