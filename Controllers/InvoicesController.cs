﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopRUs.DATA;
using shopRUs.Interfaces;
using shopRUs.Models.Invoices;
using shopRUs.Models.Invoices.DTOs;

namespace shopRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ICustomerService _customerService;
        private readonly IDiscountsService _discountsService;
        private readonly IProductService _productService;

        public InvoicesController(IInvoiceService invoiceService, ICustomerService customerService,
           IDiscountsService discountsService, IProductService productService )
        {
            _invoiceService = invoiceService;
            _discountsService = discountsService;
            _customerService = customerService;
            _productService = productService;
        }

        // GET: api/Invoices/get-total-invoice-amount
        [HttpGet("get-total-invoice-amount")]
        public async Task<ActionResult<decimal>> GetTotalAmountByInvoiceNumber([Required]int InvoiceNumber)
        {
            if (!_invoiceService.IsInvoiceExisting(InvoiceNumber))
            {
                return NotFound();
            }
            return await _invoiceService.GetTotalAmountByInvoiceNumber(InvoiceNumber);
        }



        //// POST: api/Invoices
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tbl_Invoices>> CreateInvoice(CreateInvoiceDto request)
        {
            List<int> listOfProductIds = new List<int>();
            if(!ModelState.IsValid) return BadRequest();
            if (!_customerService.IsCustomerExisting(request.customerId))
            {
                return NotFound("Customer not found");
            }
            //Get all list of Products Ids
            request.products.ForEach(x => listOfProductIds.Add(x.productsId));
            //Check if any Product Id is not valid
            
             var productResult = _productService.InvalidProducts(listOfProductIds);
            if(productResult.Any())
            {
                return NotFound("Some Products Ids were Invalid: " +String.Join(",",productResult));
            }
            var result = await _invoiceService.CreateInvoiceAsync(request);
            return CreatedAtAction("GetTotalAmountByInvoiceNumber", new { id = result.id }, result);
        }

        //// DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tbl_Invoices>> Delete_Invoice(int id)
        {

            if (!_invoiceService.IsInvoiceExisting(id))
            {
                return NotFound();
            }
            return await _invoiceService.DeleteInvoiceAsync(id);
        }


    }
}
