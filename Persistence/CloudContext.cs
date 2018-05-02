using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DbConext : DbContext
    {
        public DbSet<Fondo> Fondo { get; set; }        

        public DbConext(DbContextOptions<DbConext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
