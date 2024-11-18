using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
using WatchWinform.Datas.Models;

namespace WatchWinform.Service
{
    public class CategoryService
    {
        public CategoryService() 
        {
        }
        public async Task<BaseResponse<List<Category>>> GetList()
        {   
            var result = await ApiClient.GetAsync<List<Category>>("Category");
            var Categorys = result.Data;
            return new BaseResponse<List<Category>> { 
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = Categorys
            };
        }
        public async Task<BaseResponse<Category>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Category>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Category>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }
            //new 
            // call API
            var result = await ApiClient.GetAsync<Category>($"Category/{id}");
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Category>.CreateMessage(brCode, "Thương hiệu")
            };
        }
        public async Task<BaseResponse<Category>> Create(Category obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;

            string jsonCategory = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<Category>($"Category", jsonCategory);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Category>.CreateMessage(brCode, "Thương hiệu")
            };
        }

        public async Task<BaseResponse<Category>> Update(Category obj)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Category>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Category>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }
            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<Category>($"Category/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<Product>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Thương hiệu")
            };

        }

        public async Task<BaseResponse<Category>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Category>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Category>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Thương hiệu")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<Account>("Category/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Category>
            {
                Code = brCode,
                Message = BaseResponse<Category>.CreateMessage(brCode, "Thương hiệu")
            };

        }
        
    }
}
