using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchAPI.Datas.Models;
using WatchAPI.Datas.ViewModels;
using WatchAPI.Datas.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using WatchAPI.Extension;
using WatchAPI.Shared.Utils;
using WatchAPI.Shared.Repositories;

namespace WatchAPI.Repositories.Impl
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly WatchStoreContext _context;
        public CustomerRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<Customer> Insert(Customer obj, CancellationToken cancellationToken)
        {
            _context.Customers.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<Customer> Update(Customer obj, CancellationToken cancellationToken)
        {
            _context.Entry(obj).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
                return obj;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
                throw;
            }
        }

        public async Task<int> Delete(string id, CancellationToken cancellationToken)
        {
            var obj = await _context.Customers.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.Customers.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Customer> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Customers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Customer>> GetList(CancellationToken cancellationToken)
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
