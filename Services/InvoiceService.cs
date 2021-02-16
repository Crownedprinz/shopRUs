using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopRUs.DATA;
using shopRUs.Interfaces;
using shopRUs.Models.Invoices;
using shopRUs.Models.Invoices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly shopRUDBContext _context;
        private readonly IMapper mapper;
        public InvoiceService(shopRUDBContext context, IMapper mapper)
        {
            this.mapper = mapper;
            _context = context;
        }

        public Task<Tbl_Invoices> CreateInvoiceAsync(CreateInvoiceDto requests)
        {
            var invoice = mapper.Map<Tbl_Invoices>(requests);


            throw new NotImplementedException();
        }

        public async Task<ActionResult<Tbl_Invoices>> DeleteInvoiceAsync(int id)
        {
            var tbl_Invoices = await _context.Tbl_Invoices.FindAsync(id);

            _context.Remove(tbl_Invoices);
            await _context.SaveChangesAsync();
            return tbl_Invoices;
        }

        public async Task<decimal> GetTotalAmountByInvoiceNumber(int invoiceNumber)
        {
            return await _context.Tbl_Invoices.Where(x => x.id == invoiceNumber).Select(i=>i.total).FirstOrDefaultAsync();
        }
        public bool IsInvoiceExisting(int id)
        {
            return _context.Tbl_Invoices.Any(e => e.id == id);
        }

    }
}
