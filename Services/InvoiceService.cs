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
        private readonly ICustomerService _customerService;
        private readonly IDiscountsService _discountsService;
        private readonly IProductService _productService;
        public InvoiceService(shopRUDBContext context,
            ICustomerService customerService, IDiscountsService discountsService, IProductService productService)
        {
            _context = context;
            _customerService = customerService;
            _discountsService = discountsService;
            _productService = productService;
        }

        public async Task<Tbl_Invoices> CreateInvoiceAsync(CreateInvoiceDto requests)
        {
            var user = await _customerService.GetCustomerByIdAsync(requests.customerId);

            //Add products 
            var invoice = await AddProductsToInvoice(requests.products);
            invoice.customer = user;
            invoice.customerId = user.id;

            //Calculate Affiliate Discount 10 percent
            if (user.isAffiliate)
            {
                var percentage = Convert.ToDecimal(10F / 100);
                var total = percentage * invoice.totalAmount;
                invoice.totalDiscountAmount = total;
            }

            //Calculate Employee Discount 5 percent
            if (user.isCustomerLoyal())
            {
                var percentage = Convert.ToDecimal(5F / 100);
                var total = percentage * invoice.totalAmount;
                invoice.totalDiscountAmount = total;
            }

            //Customer can only get one percentage based discount
            //Calculate Employee Discount 30 percent
            if (user.isEmployee)
            {
                var percentage = Convert.ToDecimal(30F / 100);
                var total = percentage * invoice.totalAmount;
                invoice.totalDiscountAmount = total;
            }

            //Calculate 5% discount on every $100
            var discountedAmount = 100;
            var x = invoice.totalAmount % discountedAmount;
            var y = invoice.totalAmount - x;
            var z = y / discountedAmount;
            var totalDiscount = z * 5;
            invoice.billDiscountAmount = totalDiscount;
            invoice.billDiscountPercentage = 5;

            invoice.totalDiscountAmount = invoice.totalDiscountAmount + totalDiscount;
            invoice.updateTotalWithDiscount();
            invoice.issueDate = DateTime.Now;

            //Save to Db
            try{
            await _context.Tbl_Invoices.AddAsync(invoice);
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            return invoice;
        }

        private async Task<Tbl_Invoices> AddProductsToInvoice(List<ProductDto> products)
        {
            Tbl_Invoices tbl_Invoice = new Tbl_Invoices();
            List<Tbl_InvoiceItems> invoiceItems = new List<Tbl_InvoiceItems>();
            foreach(var item in products)
            {
                var getProduct = await _productService.GetProductByIdAsync(item.productsId);
                if (getProduct != null) {
                    var temp = new Tbl_InvoiceItems();
                    temp.quantity = item.quantity;
                    temp.unitPrice = getProduct.amount;
                    if (getProduct.category.ToLower() == "grocery") temp.isGrocery = true;
                    temp.products = getProduct;
                    temp.productsId = getProduct.id;
                    tbl_Invoice.totalProductsAmount += (temp.quantity * temp.unitPrice);

                    invoiceItems.Add(temp);
                }
            }
            tbl_Invoice.innvoiceItems = invoiceItems;
            tbl_Invoice.totalAmount = tbl_Invoice.totalProductsAmount;
            return tbl_Invoice;

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
            return await _context.Tbl_Invoices.Where(x => x.id == invoiceNumber).Select(i=>i.totalAmount).FirstOrDefaultAsync();
        }
        public bool IsInvoiceExisting(int id)
        {
            return _context.Tbl_Invoices.Any(e => e.id == id);
        }

    }
}
