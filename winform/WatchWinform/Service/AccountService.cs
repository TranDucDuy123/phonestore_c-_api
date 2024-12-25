using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WatchWinform.API;
using WatchWinform.Datas.ViewModels;
using WatchWinform.Helpers;
using WatchWinform.Helpper;
using WatchWinform.Datas.Models;
using WatchWinform.Shared.Constant;
using WatchWinform.Shared.GlobalVar;
using WatchWinform.Shared.Utils;
using WatchWinform.Utils;
using WatchWinform.Utils.Base;

namespace WatchWinform.Service
{
    public class AccountService
    {
        //private readonly ElectronicContext _dbContext = new ElectronicContext();
        public AccountService() 
        {
        }
        public async Task<BaseResponse<Account>> Login(string userName, string password)
        {
            var result = await ApiClient.GetAsync<LoginRes>("Account");
            if (result == null)
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.NOT_FOUND,
                    Message = string.Format(ResStatusConst.Message.NOT_FOUND, $"Tài khoản {result.Data.User.Name}"),
                };
            }
            if (result.Data.User.Password != password.ToMD5())
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = "Sai mật khẩu"
                };
            }

            UserGlobal.Id = result.Data.User.Id;
            UserGlobal.Role = result.Data.User.Role;
            //UserGlobal.Account = result;
            return new BaseResponse<Account>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                //Data =
            };
        }
        public async Task<BaseResponse<List<Account>>> GetListUser()
        {
            var result = await ApiClient.GetAsync<List<Account>>("Account");
            var userData = result.Data.Where(item => item.Role == "User");

            //var accounts = await _dbContext.Account.AsNoTracking().Where(a => a.Role == Role.User).ToListAsync();
            int brCode = (result.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<List<Account>>
            {
                Code = ResStatusConst.Code.SUCCESS,
                Message = ResStatusConst.Message.SUCCESS,
                Data = userData.ToList()
            };
        }
        public async Task<BaseResponse<Account>> GetById(string id) //id rỗng thì call Account/ => call api GetList() => trả về BaseResponse<List<Account>> => Json parse không được => báo lỗi
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Tài khoản")
                };
            }
            var result = await ApiClient.GetAsync<Account>($"Account/{id}");
            if (result.Code == 0)
            {
                int brCode = (result == null) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
                return new BaseResponse<Account>
                {
                    Data = result.Data,
                    Code = brCode,
                    Message = BaseResponse<Account>.CreateMessage(brCode, "Người dùng")
                };
            }
            return new BaseResponse<Account>
            {   
                Data = result.Data,
                Code = ResStatusConst.Code.SYSTEM_ERROR,
                Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.NOT_FOUND,"Người dùng")
            };

        }
        public async Task<BaseResponse<Account>> Create(Account obj)
        {
            obj.CreatedAt = DateTime.Now;
            obj.CreateUserId = UserGlobal.Id;
            string jsonAccout = JsonConvert.SerializeObject(obj);
            var result = await ApiClient.PostAsync<Account>($"Account",jsonAccout);
            int brCode = (result == null) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            if (result.Code == 0)
            {
                return new BaseResponse<Account>
                {
                    Data = result.Data,
                    Code = brCode,
                    Message = BaseResponse<Account>.CreateMessage(brCode, "Tài khoản")
                };
            }
            return new BaseResponse<Account>
            {
                Data = result.Data,
                Code = ResStatusConst.Code.SYSTEM_ERROR,
               
            };
            //var result = _dbContext.Account.Add(obj);
            //await _dbContext.SaveChangesAsync();
            
        }

        public async Task<BaseResponse<Account>> Update(Account obj)
        {
            obj.UpdatedAt = DateTime.Now;
            obj.UpdateUserId = UserGlobal.Id;
            if (StringExtension.CheckGuid(obj.Id) != true)
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Tài khoản")
                };
            }
            // json Account
            string json = JsonConvert.SerializeObject(obj);
            var put = await ApiClient.PutAsync<Account>($"Account/{obj.Id}", json);
            
            // Update only the properties that are not null in obj
            //fnd = AutoMapperCF.MapperNotNull<Account>(obj, fnd);
            //fnd.UpdatedAt = DateTime.Now;

            // Api Put
            int brCode = (put.Code != 0) ? ResStatusConst.Code.SYSTEM_ERROR : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Account>
            {
                Data = put.Data,
                Code = brCode,
                Message = BaseResponse<Account>.CreateMessage(brCode, "Tài khoản")
            };
        }

        public async Task<BaseResponse<Account>> Delete(string id)
        {
            if (StringExtension.CheckGuid(id) != true)
            {
                return new BaseResponse<Account>
                {
                    Code = ResStatusConst.Code.INVALID_PARAM,
                    Message = BaseResponse<Account>.CreateMessage(ResStatusConst.Code.INVALID_PARAM, "Tài khoản")
                };
            }
             
            // call API check user
            // Call APT Delete
            var delete = await ApiClient.DeleteAsync<Account>("Account/"+id);

            int brCode = (delete.Code != 0) ? ResStatusConst.Code.NOT_FOUND : ResStatusConst.Code.SUCCESS;
            return new BaseResponse<Account>
            {
                Code = brCode,
                Message = BaseResponse<Account>.CreateMessage(brCode, "Tài khoản")
            };

        }
    }
}
