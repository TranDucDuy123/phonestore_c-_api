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
    public class ProductRepo : IProductRepo
    {
        private readonly WatchStoreContext _context;
        public ProductRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<Product> Insert(Product obj, CancellationToken cancellationToken)
        {
            _context.Products.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<Product> Update(Product obj, CancellationToken cancellationToken)
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
            var obj = await _context.Products.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.Products.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Product> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetList(CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync();
            foreach (var product in products)
            {
                product.Brand = new Brand
                {
                    Name = _context.Brands.FirstOrDefault(b => b.Id == product.BrandId)?.Name
                };
                product.Category = new Category
                {
                    Name = _context.Categories.FirstOrDefault(b => b.Id == product.CategoryId)?.Name
                };
            }
            return products;
        }
    }
}
