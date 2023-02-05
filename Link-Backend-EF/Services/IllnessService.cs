using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{
    public class IllnessService : IIllnessService
    {
        private readonly IIllnessRepository _illnessRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IllnessService(IIllnessRepository illnessRepository, IUnitOfWork unitOfWork)
        {
            _illnessRepository = illnessRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IllnessResponse> DeleteAsync(int id)
        {
            var result = await _illnessRepository.FindByIdAsync(id);
            if (result == null)
                return new IllnessResponse("Illness not found");

            try
            {
                _illnessRepository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new IllnessResponse(result);
            }
            catch (Exception e)
            {
                return new IllnessResponse($"An error occurred while deleting the illness: {e.Message}");
            }
        }

        public async Task<IllnessResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _illnessRepository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new IllnessResponse(result);
            }
            catch (Exception e)
            {
                return new IllnessResponse($"Illness not found: {e.Message}");
            }
        }

        public async Task<IEnumerable<Illness>> ListAsync()
        {
            return await _illnessRepository.ListAsync();
        }

        public async Task<IllnessResponse> SaveAsync(Illness illness)
        {
            var existingIllnessName = await _illnessRepository.FindByNameAsync(illness.Name);
            if (existingIllnessName != null)
                return new IllnessResponse("There is already an illness with this name");

            try
            {
                await _illnessRepository.AddAsync(illness);
                await _unitOfWork.CompleteAsync();

                return new IllnessResponse(illness);
            }
            catch (Exception e)
            {
                return new IllnessResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<IllnessResponse> UpdateAsync(int id, Illness illness)
        {
            var result = await _illnessRepository.FindByIdAsync(id);
            if (result == null)
                return new IllnessResponse("Illness not found");

            var existingIllnessName = await _illnessRepository.FindByNameAsync(illness.Name);
            if (existingIllnessName != null)
                return new IllnessResponse("There is already an illness with this name");

            result.Name = illness.Name;
            result.Description = illness.Description;
            result.Creator = illness.Creator;

            try
            {
                _illnessRepository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new IllnessResponse(result);
            }
            catch (Exception e)
            {
                return new IllnessResponse($"An error occurred while updating the illness: {e.Message}");
            }
        }
    }
}
