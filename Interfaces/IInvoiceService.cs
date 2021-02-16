using Microsoft.AspNetCore.Mvc;
using shopRUs.Models.Invoices;
using shopRUs.Models.Invoices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Interfaces
{
    public interface IInvoiceService
    {
        Task<decimal> GetTotalAmountByInvoiceNumber(int invoiceNumber);
        public bool IsInvoiceExisting(int id);
        Task<ActionResult<Tbl_Invoices>> DeleteInvoiceAsync(int id);
        Task<Tbl_Invoices> CreateInvoiceAsync(CreateInvoiceDto request);
    }
}
