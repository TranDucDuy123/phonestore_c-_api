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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly WatchStoreContext _context;
        public CategoryRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<Category> Insert(Category obj, CancellationToken cancellationToken)
        {
            _context.Categories.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<Category> Update(Category obj, CancellationToken cancellationToken)
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
            var obj = await _context.Categories.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.Categories.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Category> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Category>> GetList(CancellationToken cancellationToken)
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
