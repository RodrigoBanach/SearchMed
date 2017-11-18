using SearchMed.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SearchMed.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Farmacia> Farmacias { get; set; }
        public DbSet<Remedio> Remedios { get; set; }
    }
}