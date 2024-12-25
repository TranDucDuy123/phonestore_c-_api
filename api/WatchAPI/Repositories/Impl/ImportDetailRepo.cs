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
    public class ImportDetailRepo : IImportDetailRepo
    {
        private readonly WatchStoreContext _context;
        public ImportDetailRepo(WatchStoreContext context)
        {
            _context = context;
        }

        public async Task<ImportDetail> Insert(ImportDetail obj, CancellationToken cancellationToken)
        {
            _context.ImportDetails.Add(obj);
            await _context.SaveChangesAsync(cancellationToken);
            return obj;
        }

        public async Task<ImportDetail> Update(ImportDetail obj, CancellationToken cancellationToken)
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
            var obj = await _context.ImportDetails.FindAsync(id);
            if (obj == null)
            {
                return 0;
            }
            _context.ImportDetails.Remove(obj);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<ImportDetail> GetById(string id, CancellationToken cancellationToken)
        {
            return await _context.ImportDetails.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<ImportDetail>> GetList(CancellationToken cancellationToken)
        {
            return await _context.ImportDetails.ToListAsync();
        }
    }
}
