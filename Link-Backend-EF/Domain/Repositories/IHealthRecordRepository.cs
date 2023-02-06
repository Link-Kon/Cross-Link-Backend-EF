using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IHealthRecordRepository<T>
    {
        Task AddAsync(T model);
        Task<T> FindByIdAsync(int id);
        Task<T> FindByPatiendIdAsync(int id);
        void Update(T model);
    }
}