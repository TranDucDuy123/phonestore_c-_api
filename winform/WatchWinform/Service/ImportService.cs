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
    public class ImportService
    {
        public ImportService()
        {
        }
        public async Task<BaseResponse<List<Import>>> GetList()
        {
            var result = await ApiClient.GetAsync<List<Import>>("Phiếu nhập");
            var Imports = result.Data;
            return new BaseResponse<List<Import>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = Imports
            };
        }
        public async Task<BaseResponse<Import>> GetById(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Import>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Import>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Phiếu nhập")
                };
            }
            //new 
            // call API
            var result = await ApiClient.GetAsync<Import>($"ImportDetail/{id}");
            int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Import>.CreateMessage(brCode, "Phiếu nhập")
            };
        }
        public async Task<BaseResponse<Import>> Create(Import obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;

            string jsonImport = JsonConvert.SerializeObject(obj);
            // call API
            var result = await ApiClient.PostAsync<Import>($"Phiếu nhập", jsonImport);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Data = result.Data,
                Code = brCode,
                Message = BaseResponse<Import>.CreateMessage(brCode, "Phiếu nhập")
            };
        }

        public async Task<BaseResponse<Import>> Update(Import obj)
        {
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Import>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Import>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Phiếu nhập")
                };
            }
            string json = JsonConvert.SerializeObject(obj);
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            var putResult = await ApiClient.PutAsync<Import>($"Import/{obj.Id}", json);
            int brCode = (putResult == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Code = ResStatusConst.Code.NOT_FOUND,
                Message = BaseResponse<Import>.CreateMessage(ResStatusConst.Code.NOT_FOUND, "Phiếu nhập")
            };

        }
        public async Task<BaseResponse<Import>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Import>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Import>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Phiếu nhập")
                };
            }
            //call API
            var delete = await ApiClient.DeleteAsync<Import>("Import/" + id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Import>
            {
                Code = brCode,
                Message = BaseResponse<Import>.CreateMessage(brCode, "Phiếu nhập")
            };

        }
    }
}
