using shopRUs.Models.Customers;
using shopRUs.Models.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace shopRUs.Models.Invoices
{
    [Table("Tbl_Invoices")]
    public class Tbl_Invoices
    {
        [Key]
        [Required]
        public int id { get; set; }
        [ForeignKey("customer")]
        public int customerId { get; set; }
        public Tbl_Customer customer { get; set; }
        public List<Tbl_InvoiceItems> innvoiceItems { get; set; }

        [ForeignKey("discounts")]
        public int discountsId { get; set; }

        public Tbl_Discounts discounts { get; set; }
        [Required]
        public int billDiscountPercentage { get; set; }
        [Required]
        public decimal billDiscountAmount { get; set; }
        [Required]
        public decimal totalDiscountAmount { get; set; }
        [Required]
        public decimal totalProductsAmount { get; set; }
        [Required]
        public decimal totalAmount { get; set; }

        [Required]
        public DateTime issueDate { get; set; }

        internal void updateTotalWithDiscount()
        {
            totalAmount = (totalProductsAmount - totalDiscountAmount);
        }

    }
}
