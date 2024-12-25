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
    public class OrderRepo : IOrderRepo
    {
        private readonly WatchStoreContext _context;
        public OrderRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<Order> Insert(Order obj, CancellationToken cancellationToken)
        {
            _context.Orders.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<Order> Update(Order obj, CancellationToken cancellationToken)
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
            var obj = await _context.Orders.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.Orders.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Order> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Order>> GetList(CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.ToListAsync();
            foreach (var order in orders)
            {
                order.Customer = new Customer
                {
                    Name = _context.Customers.FirstOrDefault(b => b.Id == order.CustomerId)?.Name
                };
                
            }
            return orders;
        }
    }
}
