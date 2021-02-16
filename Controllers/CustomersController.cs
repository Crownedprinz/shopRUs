using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using shopRUs.DATA;
using shopRUs.Interfaces;
using shopRUs.Models.Customers;

namespace shopRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Customer>>> GetCustomer()
        {
           return await _customerService.GetAllCustomersAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbl_Customer>> GetCustomerById(int id)
        {
            var result = await _customerService.GetCustomerByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // GET: api/Customers/search-by-fullname
        [HttpGet("search-by-fullname")]
        public async Task<ActionResult<List<Tbl_Customer>>> GetCustomerByName([Required]string fullname)
        {
            var result = await _customerService.GetCustomerByFullNameAsync(fullname);

            if (result == null && !result.Any())
            {
                return NotFound();
            }

            return result;
        }

      

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tbl_Customer>> CreateCustomer(Tbl_Customer tbl_Customer)
        {
            var result = await _customerService.AddCustomerAsync(tbl_Customer);
            return CreatedAtAction("GetCustomer", new { id = result.id }, result);
        }

  

       
    }
}
