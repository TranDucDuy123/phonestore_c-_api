using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WatchAPI.Shared.Repositories
{
    public interface IBaseRepository<T, ID>
    {
        Task<T> Insert(T obj, CancellationToken cancellationToken);
        Task<T> Update(T obj, CancellationToken cancellationToken);
        Task<int> Delete(ID id, CancellationToken cancellationToken);
        Task<T> GetById(ID id, CancellationToken cancellationToken);
        Task<List<T>> GetList(CancellationToken cancellationToken);
    }
}
