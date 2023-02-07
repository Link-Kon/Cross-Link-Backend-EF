namespace Link_Backend_EF.Domain.Services
{
    public interface IUserInfoService<T, R>
    {
        Task<R> SaveAsync(T model);
        Task<R> FindByIdAsync(int id);
        Task<R> FindByStringAsync(string value);
        Task<R> Update(int id, T model);
        Task<R> Delete(int id);
    }
}
