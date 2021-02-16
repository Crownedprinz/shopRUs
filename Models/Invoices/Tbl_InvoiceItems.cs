using shopRUs.Models.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Models.Invoices
{
    [Table("Tbl_InvoiceItems")]
    public class Tbl_InvoiceItems
    {
        [Key]
        [Required]
        public int id { get; set; }
        [ForeignKey("products")]
        public int productsId { get; set; }
        public Tbl_Products products { get; set; }  
        [ForeignKey("invoices")]
        public int invoicesId { get; set; }
        public Tbl_Invoices invoices { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public decimal unitPrice { get; set; }
        [Required]
        public bool isGrocery { get; set; }
    }
}
