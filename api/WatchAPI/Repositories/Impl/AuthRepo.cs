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

namespace WatchAPI.Repositories.Impl
{
    public class AuthRepo : IAuthRepo
    {
        private readonly IConfiguration _configuration;
        private readonly WatchStoreContext _context;
        public AuthRepo(IConfiguration configuration, WatchStoreContext context)
        {
            this._configuration = configuration;
            _context = context;
        }

        public async Task<Account?> GetUserByUserNameAndPassword(LoginReq req, CancellationToken cancellationToken)
        {
            return await _context.Accounts.SingleOrDefaultAsync(x => x.UserName == req.UserName);
        }
    }
}
