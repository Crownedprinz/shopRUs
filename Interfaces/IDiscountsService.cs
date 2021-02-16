using shopRUs.Models.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Interfaces
{
    public interface IDiscountsService
    {
        Task<Tbl_Discounts> AddDiscountAsync(Tbl_Discounts tbl_Discounts);
        Task<List<Tbl_Discounts>> GetAllDiscountsAsync();

        Task<List<Tbl_Discounts>> GetDiscountsByTypeAsync(string type);
        bool IsDiscountExisting(int id);
    }
}
