using WatchAPI.Datas.ViewModels;
using WatchAPI.Datas.ViewModels.Base;

namespace WatchAPI.Services
{
    public interface IAuthService
    {
        Task<BaseResponse<LoginRes>> Login(LoginReq req, CancellationToken cancellationToken);
    }
}
