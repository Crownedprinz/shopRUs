using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Models.Invoices
{
    [Table("Tbl_Products")]
    public class Tbl_Products
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public String product { get; set; }
        [Required]
        public decimal amount { get; set; }
        public string category { get; set; }
    }
}
