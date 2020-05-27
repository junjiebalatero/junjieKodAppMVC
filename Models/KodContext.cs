using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KodApp.Models
{
    public class KodContext: DbContext
    {
        public KodContext(DbContextOptions<KodContext> options):base (options)
        {

        }

        public DbSet<Kod> Kods { get; set; }
    }
}
