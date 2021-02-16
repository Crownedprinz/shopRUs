using Microsoft.AspNetCore.Mvc;
using shopRUs.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Interfaces
{
    public interface IProductService
    {
        Task<List<Tbl_Products>> GetAllProductsAsync();
        Task<Tbl_Products> GetProductByIdAsync(int id);
        Task<List<Tbl_Products>> GetProductByNameAsync(string product);
        Task<Tbl_Products> AddProductAsync(Tbl_Products tbl_Products);
        Task<Tbl_Products> DeleteProductAsync(int id);
        bool IsProductExisting(int id);
        Task<Tbl_Products> UpdateProductAsync(int id, Tbl_Products Tbl_Products);
        List<int> InvalidProducts(List<int> ids);
    }
}
