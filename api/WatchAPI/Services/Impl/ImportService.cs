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
    public class ImportService : IImportService
    {
        private readonly IImportRepo _importRepo;
        public ImportService(IImportRepo importRepo)
        {
            _importRepo = importRepo;
        }

        public async Task<BaseResponse<Import>> Create(Import obj, CancellationToken cancellationToken)
        {
            var result = await _importRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Import>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<Import>> Update(Import obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Import>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Import>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Nhập hàng")
                };
            }

            var fnd = await _importRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<Import>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<Import>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Nhập hàng")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<Import>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _importRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Import>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<Import>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Import>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Import>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Nhập hàng")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _importRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Code = brCode,
                Message = BaseResponse<Import>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<Import>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _importRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Import>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<List<Import>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _importRepo.GetList(cancellationToken);
            return new BaseResponse<List<Import>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
