using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schoggi.Models;

namespace Schoggi.Data
{
    public class SchoggiContext : DbContext
    {
        public SchoggiContext (DbContextOptions<SchoggiContext> options)
            : base(options)
        {
        }

        public DbSet<Schoggi.Models.Drop> Drop { get; set; }
    }
}
