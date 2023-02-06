using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IUserInfoRepository<T>
	{
        Task AddAsync(T model);
        Task<T> FindByIdAsync(int id);
        Task<T> FindByStringAsync(string value);
        void Update(T model);
        void Delete(T model);
    }
}