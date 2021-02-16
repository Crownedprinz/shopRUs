using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using shopRUs.DATA;
using shopRUs.Interfaces;
using shopRUs.Models.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Services
{
    public class DiscountsService : IDiscountsService
    {
        private readonly shopRUDBContext _context;

        private readonly ILogger<DiscountsService> _logger;

        public DiscountsService(shopRUDBContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task<Tbl_Discounts> AddDiscountAsync(Tbl_Discounts tbl_Discounts)
        {
            await _context.AddAsync(tbl_Discounts);
            await _context.SaveChangesAsync();
            return tbl_Discounts;
        }

        public async Task<List<Tbl_Discounts>> GetAllDiscountsAsync()
        {
            return await _context.Tbl_Discounts.ToListAsync();
        }

        public async Task<List<Tbl_Discounts>> GetDiscountsByTypeAsync(string type)
        {
            return await _context.Tbl_Discounts.Where(x => x.type.ToLower().Contains(type)).ToListAsync();
        }

     
        public bool IsDiscountExisting(int id)
        {
            return _context.Tbl_Discounts.Any(e => e.id == id);
        }

      
    }
}
