using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services.Communication.List;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Domain.Services;

namespace Link_Backend_EF.Services
{
    public class IllnessesListService : IListRelationService<IllnessesList, IllnessesListResponse, IllnessesListListResponse>
    {
        private readonly IListRelationRepository<IllnessesList> _repository;
        private readonly IUserInfoRepository<UserData> _userDataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public IllnessesListService(IListRelationRepository<IllnessesList> repository, IUserInfoRepository<UserData> userDataRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userDataRepository = userDataRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IllnessesListListResponse> ListByUserIdAsync(int id)
        {
            var result = await _repository.ListByUserIdAsync(id);
            await _unitOfWork.CompleteAsync();

            return new IllnessesListListResponse(result);
        }

        public async Task<IllnessesListResponse> SaveAsync(IllnessesList model)
        {
            var existingUserData = await _userDataRepository.FindByIdAsync(model.UserDataId);
            if (existingUserData == null)
                return new IllnessesListResponse("UserDataId not found");

            try
            {
                model.CreationDate = DateTime.UtcNow;
                model.LastUpdateDate = null;

                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new IllnessesListResponse(model);
            }
            catch (Exception e)
            {
                return new IllnessesListResponse($"An error ocurred while saving the UserDevice: {e.Message}");
            }
        }

        public async Task<IllnessesListResponse> UpdateAsync(IllnessesList model)
        {
            var result = await _repository.FindByUsersIdAndEntityIdAsync(model.UserDataId, model.IllnessId);
            if (result == null)
                return new IllnessesListResponse("Illness not found");

            result.State = model.State;

            try
            {
                result.LastUpdateDate = DateTime.UtcNow;

                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new IllnessesListResponse(result);
            }
            catch (Exception e)
            {
                return new IllnessesListResponse($"An error occurred while updating the Friendship: {e.Message}");
            }
        }
    }
}
