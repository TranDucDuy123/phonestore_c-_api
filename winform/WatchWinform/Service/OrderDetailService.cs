using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatchWinform.Helpers;
using WatchWinform.Helpper;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Shared.Utils;
using WatchWinform.Utils;
using WatchWinform.Utils.Base;
using WatchWinform.API;
using Newtonsoft.Json;
using WatchWinform.Datas.Models;

namespace WatchWinform.Service
{
    public class OrderDetailService
    {
        public OrderDetailService()
        {
        }
        public async Task<BaseResponse<List<OrderDetail>>> GetList()
        {
            var result = await ApiClient.GetAsync<List<OrderDetail>>("OrderDetail");
            var OrderDetails = result.Data;
            return new BaseResponse<List<OrderDetail>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = OrderDetails
            };
        }
        public async Task<BaseResponse<OrderDetail>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<OrderDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<OrderDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Đơn hàng")
                };
            }
            //new 
            // call API
            var result = await ApiClient.GetAsync<OrderDetail>($"OrderDetail/{id}");
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<OrderDetail>.CreateMessage(brCode, "Đơn hàng")
            };
        }
        public async Task<BaseResponse<OrderDetail>> Create(OrderDetail obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;

            string jsonExprortDetail = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<OrderDetail>($"OrderDetail", jsonExprortDetail);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<OrderDetail>.CreateMessage(brCode, "Đơn hàng")
            };
        }

        public async Task<BaseResponse<OrderDetail>> Update(OrderDetail obj)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<OrderDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<OrderDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Đơn hàng")
                };
            }
            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<OrderDetail>($"OrderDetail/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<OrderDetail>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Đơn hàng")
            };

        }
        public async Task<BaseResponse<OrderDetail>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<OrderDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<OrderDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Đơn hàng")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<OrderDetail>("OrderDetail/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<OrderDetail>
            {
                Code = brCode,
                Message = BaseResponse<OrderDetail>.CreateMessage(brCode, "Đơn hàng")
            };

        }

    }
}
