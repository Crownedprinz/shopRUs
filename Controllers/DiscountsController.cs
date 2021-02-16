using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopRUs.DATA;
using shopRUs.Models.Discounts;
using shopRUs.Services;

namespace shopRUs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly DiscountsService _discountsService;

        public DiscountsController(shopRUDBContext context, DiscountsService discountsService)
        {
            _discountsService = discountsService;
        }

        // GET: api/Discounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Discounts>>> GetAllDiscounts()
        {
            return await _discountsService.GetAllDiscountsAsync();
        }

        // POST: api/Discounts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tbl_Discounts>> AddDiscount(Tbl_Discounts tbl_Discounts)
        {
            var result = await _discountsService.AddDiscountAsync(tbl_Discounts);
            return CreatedAtAction("GetAllDiscounts", new { id = result.id }, result);
        }

        // GET: api/Discounts/search-by-type
        [HttpGet("search-by-fullname")]
        public async Task<ActionResult<List<Tbl_Discounts>>> GetDiscountByType([Required]string type)
        {
            var result = await _discountsService.GetDiscountsByTypeAsync(type);

            if (result == null && !result.Any())
            {
                return NotFound();
            }

            return result;
        }
    }
}
