using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopRUs.DATA;
using shopRUs.Interfaces;
using shopRUs.Models.Invoices;

namespace shopRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

      

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Tbl_Products>> UpdateProducts(int id, Tbl_Products tbl_Products)
        {
            if (id != tbl_Products.id)
            {
                return BadRequest();
            }
            if (!_productService.IsProductExisting(id))
            {
                return NotFound();
            }
            return await _productService.UpdateProductAsync(id, tbl_Products);
        }

       

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tbl_Products>> DeleteProducts(int id)
        {
           
            if (!_productService.IsProductExisting(id))
            {
                return NotFound();
            }
            return await _productService.DeleteProductAsync(id);
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Products>>> GetProducts()
        {
            return await _productService.GetAllProductsAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbl_Products>> GetProductById(int id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }
        // GET: api/Customers/search-by-fullname
        [HttpGet("search-by-product")]
        public async Task<ActionResult<List<Tbl_Products>>> GetProductByName([Required]string product)
        {
            var result = await _productService.GetProductByNameAsync(product);

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
        public async Task<ActionResult<Tbl_Products>> CreateProduct(Tbl_Products tbl_Products)
        {
            var result = await _productService.AddProductAsync(tbl_Products);
            return CreatedAtAction("GetProducts", new { id = result.id }, result);
        }

    }
}
