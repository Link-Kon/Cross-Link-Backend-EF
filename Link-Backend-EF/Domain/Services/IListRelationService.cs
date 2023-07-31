using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Domain.Services
{
    public interface IListRelationService<T,R,L>
    {
        Task<R> SaveAsync(T model);
        Task<L> ListByUserIdAsync(int id);
        Task<R> UpdateAsync(T model);
    }
}
