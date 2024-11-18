using Newtonsoft.Json;
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
using WatchWinform.API;
using WatchWinform.Helpers;
using WatchWinform.Helpper;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Shared.Utils;
using WatchWinform.Utils;
using WatchWinform.Utils.Base;
using WatchWinform.Datas.Models;

namespace WatchWinform.Service
{
    public class OrderService
    {
        public OrderService()
        {
        }
        public async Task<BaseResponse<List<Order>>> GetList()
        {
            var result = await ApiClient.GetAsync<List<Order>>("Order");
            var orders = result.Data;
            return new BaseResponse<List<Order>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = orders
            };
        }
        public async Task<BaseResponse<Order>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Order>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Order>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Đặt hàng")
                };
            }
            //new 
            // call API
            var result = await ApiClient.GetAsync<Order>($"Order/{id}");
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Order>.CreateMessage(brCode, "Đặt hàng")
            };
        }
        public async Task<BaseResponse<Order>> Create(Order obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;

            string jsonExprortDetail = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<Order>($"Order", jsonExprortDetail);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Order>.CreateMessage(brCode, "Đặt hàng")
            };
        }

        public async Task<BaseResponse<Order>> Update(Order obj)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Order>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Order>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Đặt hàng")
                };
            }
            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<Order>($"Order/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<Order>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Đặt hàng")
            };

        }
        public async Task<BaseResponse<Order>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Order>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Order>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Đặt hàng")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<Order>("Order/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Order>
            {
                Code = brCode,
                Message = BaseResponse<Order>.CreateMessage(brCode, "Đặt hàng")
            };

        }

    }
}
