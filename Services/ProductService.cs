using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using shopRUs.DATA;
using shopRUs.Interfaces;
using shopRUs.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Services
{
    public class ProductService : IProductService
    { 
        private readonly shopRUDBContext _context;

        private readonly ILogger<ProductService> _logger;

        public ProductService(shopRUDBContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task<Tbl_Products> AddProductAsync(Tbl_Products tbl_Products)
        {
            await _context.Tbl_Products.AddAsync(tbl_Products);
            await _context.SaveChangesAsync();
            return tbl_Products;
        }

        public async Task<Tbl_Products> DeleteProductAsync(int id)
        {
            var tbl_Products = await _context.Tbl_Products.FindAsync(id);

            _context.Remove(tbl_Products);
            await _context.SaveChangesAsync();
            return tbl_Products;
        }

        public async Task<List<Tbl_Products>> GetAllProductsAsync()
        {
            return await _context.Tbl_Products.ToListAsync();
        }

        public async Task<List<Tbl_Products>> GetProductByNameAsync(string product)
        {
            return await _context.Tbl_Products.Where(x => x.product.ToLower().Contains(product)).ToListAsync();
        }

        public async Task<Tbl_Products> GetProductByIdAsync(int Id)
        {
            return await _context.Tbl_Products.FindAsync(Id);
        }

        public bool IsProductExisting(int id)
        {
            return _context.Tbl_Products.Any(e => e.id == id);
        }

        public async Task<Tbl_Products> UpdateProductAsync(int id, Tbl_Products tbl_Products)
        {
            _context.Update(tbl_Products);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return tbl_Products;
        }

    
    }
}
