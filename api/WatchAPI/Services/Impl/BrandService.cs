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
using System.Reflection;
using AutoMapper;
using WatchAPI.Helpers;

namespace WatchAPI.Services.Impl
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepo _brandRepo;
        public BrandService(IBrandRepo brandRepo)
        {
            _brandRepo = brandRepo;
        }

        public async Task<BaseResponse<Brand>> Create(Brand obj, CancellationToken cancellationToken)
        {
            var result = await _brandRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Brand>.CreateMessage(brCode, "Thương hiệu")
            };
        }

        public async Task<BaseResponse<Brand>> Update(Brand obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Brand>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Brand>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }

            var fnd = await _brandRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<Brand>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<Brand>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Thương hiệu")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<Brand>(obj, fnd);
           
            fnd.UpdatedAt = DateTime.Now;

            var result = await _brandRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Brand>.CreateMessage(brCode, "Thương hiệu")
            };
        }

        public async Task<BaseResponse<Brand>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Brand>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Brand>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _brandRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Code = brCode,
                Message = BaseResponse<Brand>.CreateMessage(brCode, "Thương hiệu")
            };
        }

        public async Task<BaseResponse<Brand>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _brandRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Brand>.CreateMessage(brCode, "Thương hiệu")
            };
        }

        public async Task<BaseResponse<List<Brand>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _brandRepo.GetList(cancellationToken);
            return new BaseResponse<List<Brand>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
