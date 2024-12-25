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
    public class CustomerService
    {
        public CustomerService() 
        {
        }
        public async Task<BaseResponse<List<Customer>>> GetList()
        {   
            var result = await ApiClient.GetAsync<List<Customer>>("Customer");
            var Customers = result.Data;
            return new BaseResponse<List<Customer>> { 
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = Customers
            };
        }
        public async Task<BaseResponse<Customer>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Customer>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Customer>.CreateMessage(ResStatusConst.Code.INVALID_PARAM,"Khácg hàng")
                };
            }
            //new 
            // call API
            var result = await ApiClient.GetAsync<Customer>($"Customer/{id}");
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Customer>.CreateMessage(brCode,"Khácg hàng")
            };
        }
        public async Task<BaseResponse<Customer>> Create(Customer obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;

            string jsonCustomer = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<Customer>($"Customer", jsonCustomer);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Customer>.CreateMessage(brCode,"Khácg hàng")
            };
        }

        public async Task<BaseResponse<Customer>> Update(Customer obj)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Customer>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Customer>.CreateMessage(ResStatusConst.Code.INVALID_PARAM,"Khácg hàng")
                };
            }
            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<Customer>($"Customer/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<Customer>.CreateMessage(ResStatusConst.Code.NOT_FOUND,"Khácg hàng")
            };

        }
        public async Task<BaseResponse<Customer>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Customer>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Customer>.CreateMessage(ResStatusConst.Code.INVALID_PARAM,"Khácg hàng")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<Customer>("Customer/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Customer>
            {
                Code = brCode,
                Message = BaseResponse<Customer>.CreateMessage(brCode,"Khácg hàng")
            };

        }
    }
}

