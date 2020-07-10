using System;
using System.Collections.Generic;
using System.Text;
using AdminProysis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminProysis.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pac> Pac { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Sistema> Sistema { get; set; }
        public DbSet<CompraTimbre> CompraTimbres { get; set; }
        //public DbSet<CompraTimbreDetalle> CompraTimbresDetalle { get; set; }

    }
}
