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
using WatchAPI.Repositories.Impl;

namespace WatchAPI.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IBrandRepo _brandRepo;
        public ProductService(IProductRepo productRepo, IBrandRepo brandRepo)
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
        }

        public async Task<BaseResponse<Product>> Create(Product obj, CancellationToken cancellationToken)
        {
            var result = await _productRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Product>.CreateMessage(brCode, "Sản phẩm")
            };
        }

        public async Task<BaseResponse<Product>> Update(Product obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Product>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Product>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Sản phẩm")
                };
            }

            var fnd = await _productRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<Product>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<Product>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Sản phẩm")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<Product>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _productRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Product>.CreateMessage(brCode, "Sản phẩm")
            };
        }

        public async Task<BaseResponse<Product>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Product>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Product>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Sản phẩm")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _productRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Code = brCode,
                Message = BaseResponse<Product>.CreateMessage(brCode, "Sản phẩm")
            };
        }

        public async Task<BaseResponse<Product>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _productRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Product>.CreateMessage(brCode, "Sản phẩm")
            };
        }

        public async Task<BaseResponse<List<Product>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _productRepo.GetList(cancellationToken);
            return new BaseResponse<List<Product>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
