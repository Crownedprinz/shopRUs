using Microsoft.AspNetCore.Mvc;
using shopRUs.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Interfaces
{
   public interface ICustomerService
    {
        Task<List<Tbl_Customer>> GetAllCustomersAsync();

        Task<Tbl_Customer> GetCustomerByIdAsync(int Id);
        Task<List<Tbl_Customer>> GetCustomerByFullNameAsync(string fullName);
        Task<Tbl_Customer> UpdateCustomerAsync(int id, Tbl_Customer tbl_Customer);
        bool IsCustomerExisting(int id);
        Task<Tbl_Customer> AddCustomerAsync(Tbl_Customer tbl_Customer);
        Task<Tbl_Customer> DeleteCustomerAsync(int id);
    }
}
