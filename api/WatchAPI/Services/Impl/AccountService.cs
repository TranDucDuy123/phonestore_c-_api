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
using WatchAPI.Repositories;
using Microsoft.OpenApi.Extensions;
using WatchAPI.Utils;
using WatchAPI.Helpers;

namespace WatchAPI.Services.Impl
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;
        public AccountService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public async Task<BaseResponse<Account>> Create(Account obj, CancellationToken cancellationToken)
        {
            var result = await _accountRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Account>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Account>.CreateMessage(brCode, "Tài khoản")
            };
        }

        public async Task<BaseResponse<Account>> Update(Account obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Tài khoản")
                };
            }

            var fnd = await _accountRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Tài khoản")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<Account>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _accountRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Account>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Account>.CreateMessage(brCode, "Tài khoản")
            };
        }

        public async Task<BaseResponse<Account>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Tài khoản")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _accountRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Account>
            {
                Code = brCode,
                Message = BaseResponse<Account>.CreateMessage(brCode, "Tài khoản")
            };
        }

        public async Task<BaseResponse<Account>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _accountRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Account>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Account>.CreateMessage(brCode, "Tài khoản")
            };
        }

        public async Task<BaseResponse<List<Account>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _accountRepo.GetList(cancellationToken);
            return new BaseResponse<List<Account>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
