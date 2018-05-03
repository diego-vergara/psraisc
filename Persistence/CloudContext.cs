using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class CloudContext : DbContext
    {
        public DbSet<Administradora> Administradora { get; set; }
        public DbSet<Fondo> Fondo { get; set; }
        

        public CloudContext(DbContextOptions<CloudContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
