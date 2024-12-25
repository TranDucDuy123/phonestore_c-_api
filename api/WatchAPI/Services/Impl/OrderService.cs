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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<BaseResponse<Order>> Create(Order obj, CancellationToken cancellationToken)
        {
            var result = await _orderRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Order>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<Order>> Update(Order obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Order>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Order>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Nhập hàng")
                };
            }

            var fnd = await _orderRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<Order>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<Order>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Nhập hàng")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<Order>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _orderRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Order>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<Order>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Order>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Order>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Nhập hàng")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _orderRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Code = brCode,
                Message = BaseResponse<Order>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<Order>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _orderRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<Order>.CreateMessage(brCode, "Nhập hàng")
            };
        }

        public async Task<BaseResponse<List<Order>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _orderRepo.GetList(cancellationToken);
            return new BaseResponse<List<Order>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
