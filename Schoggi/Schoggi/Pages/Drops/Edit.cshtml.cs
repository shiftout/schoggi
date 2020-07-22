using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schoggi.Data;
using Schoggi.Models;

namespace Schoggi.Pages.Drops
{
    public class EditModel : PageModel
    {
        private readonly Schoggi.Data.SchoggiContext _context;

        public EditModel(Schoggi.Data.SchoggiContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var dropToUpdate = await _context.Drop.FindAsync(id);
            if (await TryUpdateModelAsync<Drop>(dropToUpdate, "drop", d => d.Text))
            {
                dropToUpdate.LastModified = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

            //_context.Attach(Drop).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!DropExists(Drop.ID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");
        }

        private bool DropExists(int id)
        {
            return _context.Drop.Any(e => e.ID == id);
        }
    }
}
