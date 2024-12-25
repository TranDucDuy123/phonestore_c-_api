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
    public class BrandRepo : IBrandRepo
    {
        private readonly WatchStoreContext _context;
        public BrandRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<Brand> Insert(Brand obj, CancellationToken cancellationToken)
        {
            _context.Brands.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<Brand> Update(Brand obj, CancellationToken cancellationToken)
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
            var obj = await _context.Brands.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.Brands.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Brand> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Brands.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Brand>> GetList(CancellationToken cancellationToken)
        {
            return await _context.Brands.ToListAsync();
        }
    }
}
