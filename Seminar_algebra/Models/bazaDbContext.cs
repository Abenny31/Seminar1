using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Seminar_algebra.Models
{
    public class bazaDbContext : DbContext
    {
        public bazaDbContext()
            : base("baza") { }

        public DbSet<Predbiljezba> _dboPb { get; set; }
        public DbSet<Seminar> _dboSm { get; set; }
        public DbSet<Zaposlenik> _dboZp { get; set; }

        

    }

    
}