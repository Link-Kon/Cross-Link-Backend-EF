using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Domain.Services
{
    public interface IIllnessService
    {
        Task<IEnumerable<Illness>> ListAsync();
        Task<IllnessResponse> SaveAsync(Illness model);
        Task<IllnessResponse> FindByIdAsync(int id);
        Task<IllnessResponse> UpdateAsync(int id, Illness model);
        Task<IllnessResponse> DeleteAsync(int id);
    }
}
