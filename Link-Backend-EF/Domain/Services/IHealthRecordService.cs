namespace Link_Backend_EF.Domain.Services
{
    public interface IHealthRecordService<T, R>
    {
        Task<R> SaveAsync(T model);
        Task<R> FindByIdAsync(int id);
        Task<R> FindByPatiendIdAsync(int id);
        Task<R> UpdateAsync(int id, T model);
    }
}
