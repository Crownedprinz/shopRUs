using Microsoft.EntityFrameworkCore;
using shopRUs.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopRUs.Models.Discounts;
using shopRUs.Models.Invoices;

namespace shopRUs.DATA
{
    public class shopRUDBContext: DbContext
    {
        public DbSet<Tbl_Customer> Tbl_Customer { get; set; }
        public shopRUDBContext(DbContextOptions<shopRUDBContext> options) : base(options)
        {
        }
        public DbSet<shopRUs.Models.Discounts.Tbl_Discounts> Tbl_Discounts { get; set; }
        public DbSet<shopRUs.Models.Invoices.Tbl_Products> Tbl_Products { get; set; }
        public DbSet<shopRUs.Models.Invoices.Tbl_InvoiceItems> Tbl_InvoiceItems { get; set; }
        public DbSet<shopRUs.Models.Invoices.Tbl_Invoices> Tbl_Invoices { get; set; }
    }
}
