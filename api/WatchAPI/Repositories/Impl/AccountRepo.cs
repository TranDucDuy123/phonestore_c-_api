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
    public class AccountRepo : IAccountRepo
    {
        private readonly WatchStoreContext _context;
        public AccountRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<Account> Insert(Account obj, CancellationToken cancellationToken)
        {
            _context.Accounts.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<Account> Update(Account obj, CancellationToken cancellationToken)
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
            var obj = await _context.Accounts.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.Accounts.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Account> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Accounts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Account>> GetList(CancellationToken cancellationToken)
        {
            return await _context.Accounts.ToListAsync();
        }
    }
}
