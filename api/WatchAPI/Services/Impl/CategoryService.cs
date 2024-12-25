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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<BaseResponse<Category>> Create(Category obj, CancellationToken cancellationToken)
        {
            var result = await _categoryRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Category>.CreateMessage(brCode, "Danh mục")
            };
        }

        public async Task<BaseResponse<Category>> Update(Category obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Category>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Category>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Danh mục")
                };
            }

            var fnd = await _categoryRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<Category>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<Category>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Danh mục")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<Category>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _categoryRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Category>.CreateMessage(brCode, "Danh mục")
            };
        }

        public async Task<BaseResponse<Category>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Category>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Category>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Danh mục")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _categoryRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Code = brCode,
                Message = BaseResponse<Category>.CreateMessage(brCode, "Danh mục")
            };
        }

        public async Task<BaseResponse<Category>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _categoryRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Category>.CreateMessage(brCode, "Danh mục")
            };
        }

        public async Task<BaseResponse<List<Category>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _categoryRepo.GetList(cancellationToken);
            return new BaseResponse<List<Category>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
