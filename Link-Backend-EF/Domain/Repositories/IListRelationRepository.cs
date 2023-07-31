using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IListRelationRepository<T>
    {
        Task AddAsync(T model);
        Task<List<T>> ListByUserIdAsync(int id);
        Task<T> FindByUsersIdAndEntityIdAsync(int userId, int deviceId);
        void Update(T model);
    }
}
