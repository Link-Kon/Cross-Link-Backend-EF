namespace Link_Backend_EF.Domain.Services
{
    public interface IHealthRecordService<T>
    {
        Task SaveAsync(T model);
        Task<T> FindByIdAsync(int id);
        Task<T> FindByPatiendIdAsync(int id);
        void Update(int id, T model);
    }
}
