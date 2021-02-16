using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using shopRUs.DATA;
using shopRUs.Interfaces;
using shopRUs.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopRUs.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly shopRUDBContext _context;

        private readonly ILogger<CustomerService> _logger;

        public CustomerService( shopRUDBContext context)
        {
            _context = context;
            //_logger = logger;
        }

        public async Task<Tbl_Customer> AddCustomerAsync(Tbl_Customer tbl_Customer)
        {
            await _context.Tbl_Customer.AddAsync(tbl_Customer);
            await _context.SaveChangesAsync();
            return tbl_Customer;
        }

        public async Task<Tbl_Customer> DeleteCustomerAsync(int id)
        {
            var tbl_Customer = await _context.Tbl_Customer.FindAsync(id);

            _context.Tbl_Customer.Remove(tbl_Customer);
            await _context.SaveChangesAsync();
            return tbl_Customer;
        }

        public async Task<List<Tbl_Customer>> GetAllCustomersAsync()
        {
            return await _context.Tbl_Customer.ToListAsync();
        }

        public async Task<List<Tbl_Customer>> GetCustomerByFullNameAsync(string fullName)
        {
           return await _context.Tbl_Customer.Where(x => x.fullName.ToLower().Contains(fullName)).ToListAsync();
        }

        public async Task<Tbl_Customer> GetCustomerByIdAsync(int Id)
        {
           return await _context.Tbl_Customer.FindAsync(Id);
        }

        public bool IsCustomerExisting(int id)
        {
            return _context.Tbl_Customer.Any(e => e.id == id);
        }

        public async Task<Tbl_Customer> UpdateCustomerAsync(int id, Tbl_Customer tbl_Customer)
        {
            _context.Update(tbl_Customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }
            return tbl_Customer;
        }

    }
}
