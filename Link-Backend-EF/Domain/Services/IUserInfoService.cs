namespace Link_Backend_EF.Domain.Services
{
    public interface IUserInfoService<T>
    {
        Task SaveAsync(T model);
        Task<T> FindByIdAsync(int id);
        Task<T> FindByStringAsync(string value);
        void Update(int id, T model);
        void Delete(int id);
    }
}
