using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionaleDipendentiMVC.Models;

namespace GestionaleDipendentiMVC.Data
{
    public class GestionaleDipendentiMVCContext : DbContext
    {
        public GestionaleDipendentiMVCContext (DbContextOptions<GestionaleDipendentiMVCContext> options)
            : base(options)
        {
        }

        public DbSet<GestionaleDipendentiMVC.Models.Ruolo> Ruolo { get; set; } = default!;
        public DbSet<GestionaleDipendentiMVC.Models.Dipendente> Dipendente { get; set; } = default!;
    }
}
