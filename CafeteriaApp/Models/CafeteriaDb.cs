using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CafeteriaApp.Models
{
    public class CafeteriaDb : DbContext
    {
         public CafeteriaDb()
            : base("DefaultConnection")
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}