using WatchAPI.Datas.Models;
using WatchAPI.Datas.ViewModels;
using WatchAPI.Datas.ViewModels.Base;

namespace WatchAPI.Repositories
{
    public interface IAuthRepo
    {
        Task<Account?> GetUserByUserNameAndPassword(LoginReq req, CancellationToken cancellationToken);
    }
}
