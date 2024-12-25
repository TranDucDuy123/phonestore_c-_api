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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepo _orderDetailRepo;
        public OrderDetailService(IOrderDetailRepo orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }

        public async Task<BaseResponse<OrderDetail>> Create(OrderDetail obj, CancellationToken cancellationToken)
        {
            var result = await _orderDetailRepo.Insert(obj, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<OrderDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<OrderDetail>> Update(OrderDetail obj, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<OrderDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<OrderDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Chi tiết nhập hàng")
                };
            }

            var fnd = await _orderDetailRepo.GetById(obj.Id, cancellationToken);
            if (fnd == null)
            {
                return new BaseResponse<OrderDetail>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = BaseResponse<OrderDetail>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Chi tiết nhập hàng")
                };
            }
            // Update only the properties that are not null in obj
            fnd = AutoMapperCF.MapperNotNull<OrderDetail>(obj, fnd);

            fnd.UpdatedAt = DateTime.Now;

            var result = await _orderDetailRepo.Update(fnd, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<OrderDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<OrderDetail>> Delete(string id, CancellationToken cancellationToken)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<OrderDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<OrderDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Chi tiết nhập hàng")
                };
            }
            string delId = string.Empty;
            if (id != null)
            {
                delId = id;
            }
            int deleted = await _orderDetailRepo.Delete(delId, cancellationToken);
            int brCode = (deleted == 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Code = brCode,
                Message = BaseResponse<OrderDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<OrderDetail>> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _orderDetailRepo.GetById(id, cancellationToken);
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Data = result,
                Code = brCode,
                Message = BaseResponse<OrderDetail>.CreateMessage(brCode, "Chi tiết nhập hàng")
            };
        }

        public async Task<BaseResponse<List<OrderDetail>>> GetList(CancellationToken cancellationToken)
        {
            var results = await _orderDetailRepo.GetList(cancellationToken);
            return new BaseResponse<List<OrderDetail>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = results,
            };
        }

    }
}
