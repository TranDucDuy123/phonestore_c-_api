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
    public class ImportDetailService : IImportDetailService
    {
        private readonly IImportDetailRepo _importDetailRepo;
        public ImportDetailService(IImportDetailRepo importDetailRepo)
        {
            _importDetailRepo = importDetailRepo;
        }

        public async Task<BaseResponse<ImportDetail>> Create(ImportDetail obj, CancellationToken cancellationToken)
        {
            var result = await _importDetailRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<ImportDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<ImportDetail>> Update(ImportDetail obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<ImportDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<ImportDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Chi tiết nhập hàng")
                };
            }

            var fnd = await _importDetailRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<ImportDetail>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<ImportDetail>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Chi tiết nhập hàng")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<ImportDetail>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _importDetailRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<ImportDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<ImportDetail>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<ImportDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<ImportDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Chi tiết nhập hàng")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _importDetailRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Code = brCode,
                Message = BaseResponse<ImportDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<ImportDetail>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _importDetailRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<ImportDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<List<ImportDetail>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _importDetailRepo.GetList(cancellationToken);
            return new BaseResponse<List<ImportDetail>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
