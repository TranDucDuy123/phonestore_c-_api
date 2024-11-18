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
using WatchWinform.Datas.ViewModels;
using WatchWinform.Helpers;
using WatchWinform.Helpper;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Shared.Utils;
using WatchWinform.Utils;
using WatchWinform.Utils.Base;
using Newtonsoft.Json;
using WatchWinform.Datas.Models;

namespace WatchWinform.Service
{
    public class ProductService
    {
        //private readonly ElectronicContext _dbContext = new ElectronicContext();
        public ProductService() 
        {
        }
        public async Task<BaseResponse<List<Product>>> GetList()
        {
            //var products = await _dbContext.Product.AsNoTracking().ToListAsync();
            var result = await ApiClient.GetAsync<List<Product>>("Product");
            var products = result.Data;
            return new BaseResponse<List<Product>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = products
            };
        }
        public async Task<BaseResponse<Product>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Product>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Sản phẩm")
                };
            }
            //var result = await _dbContext.Product.FirstOrDefaultAsync(p => p.Id == id);
            //call API
            var result = await ApiClient.GetAsync<Product>($"Product/{id}");
            var product = result.Data;
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Data = product,
                Code = brCode,
                Message = BaseResponse<Product>.CreateMessage(brCode, "Sản phẩm")
            };
        }
        public async Task<BaseResponse<Product>> Create(Product obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;
            // var result = _dbContext.Product.Add(obj);
            //await _dbContext.SaveChangesAsync();
            
            string jsonProduct = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<Product>($"Product", jsonProduct);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Product>.CreateMessage(brCode, "Sản phẩm")
            };
        }

        public async Task<BaseResponse<Product>> Update(Product obj)
        {
            
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Product>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Product>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Sản phẩm")
                };
            }
            //old
            //var fnd = await _dbContext.Product.FindAsync(obj.Id);
            //new
            //call API

            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<Product>($"Product/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<Product>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Sản phẩm")
            };
            
        }

        public async Task<BaseResponse<Product>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Product>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Product>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Sản phẩm")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<Account>("Product/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Product>
            {
                Code = brCode,
                Message = BaseResponse<Account>.CreateMessage(brCode, " Sản phẩm")
            };

        }
        
    }
}
