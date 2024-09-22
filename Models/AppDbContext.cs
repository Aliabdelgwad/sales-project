using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sales.Models
{
          public class AppDbContext : DbContext
        {

            public AppDbContext() : base("VtsConString")
            {

            }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }

            public DbSet<Customer> Customers { get; set; }

            public DbSet<Invoice> Invoices { get; set; }
            public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
           public DbSet<User> Users { get; set; }
    }
    }
