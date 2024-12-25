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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<BaseResponse<Customer>> Create(Customer obj, CancellationToken cancellationToken)
        {
            var result = await _customerRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Customer>.CreateMessage(brCode, "Khách hàng")
            };
        }

        public async Task<BaseResponse<Customer>> Update(Customer obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Customer>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Customer>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Khách hàng")
                };
            }

            var fnd = await _customerRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<Customer>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<Customer>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Khách hàng")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<Customer>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _customerRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Customer>.CreateMessage(brCode, "Khách hàng")
            };
        }

        public async Task<BaseResponse<Customer>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Customer>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Customer>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Khách hàng")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _customerRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Code = brCode,
                Message = BaseResponse<Customer>.CreateMessage(brCode, "Khách hàng")
            };
        }

        public async Task<BaseResponse<Customer>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _customerRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Customer>.CreateMessage(brCode, "Khách hàng")
            };
        }

        public async Task<BaseResponse<List<Customer>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _customerRepo.GetList(cancellationToken);
            return new BaseResponse<List<Customer>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
