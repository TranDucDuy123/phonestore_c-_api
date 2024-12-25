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
    public class BrandService
    {
        //private readonly ElectronicContext _dbContext = new ElectronicContext();
        public BrandService()
        {
        }
        public async Task<BaseResponse<List<Brand>>> GetList()
        {
            var result = await ApiClient.GetAsync<List<Brand>>("Brand");
            var brands = result.Data;
            return new BaseResponse<List<Brand>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = brands
            };
        }
        public async Task<BaseResponse<Brand>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Brand>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Brand>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }
            //new 
            // call API
            var result = await ApiClient.GetAsync<Brand>($"Brand/{id}");
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Brand>.CreateMessage(brCode, "Thương hiệu")
            };
        }
        public async Task<BaseResponse<Brand>> Create(Brand obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;

            string jsonBrand = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<Brand>($"Brand", jsonBrand);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Brand>.CreateMessage(brCode, "Thương hiệu")
            };
        }

        public async Task<BaseResponse<Brand>> Update(Brand obj)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Brand>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Brand>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }
            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<Brand>($"Brand/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<Brand>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Thương hiệu")
            };

        }

        public async Task<BaseResponse<Brand>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Brand>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Brand>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<Account>("Brand/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Brand>
            {
                Code = brCode,
                Message = BaseResponse<Brand>.CreateMessage(brCode, "Thương hiệu")
            };

        }
    }
}
