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
    public class IndexModel : PageModel
    {
        private readonly Schoggi.Data.SchoggiContext _context;

        public IndexModel(Schoggi.Data.SchoggiContext context)
        {
            _context = context;
        }

        public IList<Drop> Drop { get;set; }

        public async Task OnGetAsync()
        {
            Drop = await _context.Drop.ToListAsync();
        }
    }
}
