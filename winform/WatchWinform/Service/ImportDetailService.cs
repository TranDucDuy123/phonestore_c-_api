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
    public class ImportDetailService
    {
        public ImportDetailService() 
        {
        }
        public async Task<BaseResponse<List<ImportDetail>>> GetList()
        { 
            var result = await ApiClient.GetAsync<List<ImportDetail>>("Chi tiết phiếu nhập");
            var ImportDetails = result.Data;
            return new BaseResponse<List<ImportDetail>>{ 
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = ImportDetails
            };
        }
        public async Task<BaseResponse<ImportDetail>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<ImportDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<ImportDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM,"Chi tiết phiếu nhập")
                };
            }
            //new 
            // call API
            var result = await ApiClient.GetAsync<ImportDetail>($"ImportDetail/{id}");
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<ImportDetail>.CreateMessage(brCode,"Chi tiết phiếu nhập")
            };
        }
        public async Task<BaseResponse<ImportDetail>> Create(ImportDetail obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;

            string jsonImportDetail = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<ImportDetail>($"Chi tiết phiếu nhập", jsonImportDetail);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<ImportDetail>.CreateMessage(brCode,"Chi tiết phiếu nhập")
            };
        }

        public async Task<BaseResponse<ImportDetail>> Update(ImportDetail obj)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<ImportDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<ImportDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM,"Chi tiết phiếu nhập")
                };
            }
            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<ImportDetail>($"ImportDetail/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<ImportDetail>.CreateMessage(ResStatusConst.Code.NOT_FOUND,"Chi tiết phiếu nhập")
            };

        }
        public async Task<BaseResponse<ImportDetail>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<ImportDetail>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<ImportDetail>.CreateMessage(ResStatusConst.Code.INVALID_PARAM,"Chi tiết phiếu nhập")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<ImportDetail>("ImportDetail/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<ImportDetail>
            {
                Code = brCode,
                Message = BaseResponse<ImportDetail>.CreateMessage(brCode,"Chi tiết phiếu nhập")
            };

        }
    }
}
