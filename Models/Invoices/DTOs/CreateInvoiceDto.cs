using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Models.Invoices.DTOs
{
    public class CreateInvoiceDto
    {
        [Required]
        public int id { get; set; }
        public int customerId { get; set; }
        public ProductDto products { get; set; }
    }
}
