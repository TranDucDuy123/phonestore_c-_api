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
    public class ImportRepo : IImportRepo
    {
        private readonly WatchStoreContext _context;
        public ImportRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<Import> Insert(Import obj, CancellationToken cancellationToken)
        {
            _context.Imports.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<Import> Update(Import obj, CancellationToken cancellationToken)
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
            var obj = await _context.Imports.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.Imports.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<Import> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.Imports.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Import>> GetList(CancellationToken cancellationToken)
        {
            var imports = await _context.Imports.ToListAsync();
            foreach (var import in imports)
            {
                import.CreateUser = new Account
                {
                    Name = _context.Accounts.FirstOrDefault(b => b.Id == import.CreateUserId)?.Name
                };

            }
            return imports;
        }
    }
}
