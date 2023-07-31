using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Repositories;
using Link_Backend_EF.Domain.Services.Communication.List;

namespace Link_Backend_EF.Services
{
    public class UserDeviceService : IListRelationService<UserDevice, UserDeviceResponse, UserDeviceListResponse>
    {
        private readonly IListRelationRepository<UserDevice> _repository;
        private readonly IUserInfoRepository<UserData> _userDataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserDeviceService(IListRelationRepository<UserDevice> repository, IUserInfoRepository<UserData> userDataRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userDataRepository = userDataRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<UserDeviceListResponse> ListByUserIdAsync(int id)
        {
            //List<UserDeviceResponse> result = new List<UserDeviceResponse> ();c
            var result = await _repository.ListByUserIdAsync(id);
            await _unitOfWork.CompleteAsync();

            return new UserDeviceListResponse(result);
        }



        public async Task<UserDeviceResponse> SaveAsync(UserDevice model)
        {
            var existingUserData = await _userDataRepository.FindByIdAsync(model.UserDataId);
            if (existingUserData == null)
                return new UserDeviceResponse("UserDataId not found");

            //var existingPatientCode = await _userRepository.FindByCodeAsync(model.User2Code.ToString());
            //if (existingPatientCode == null)
            //    return new FriendshipResponse("User2Code not found");

            try
            {
                model.CreationDate = DateTime.UtcNow;
                model.LastUpdateDate = null;

                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new UserDeviceResponse(model);
            }
            catch (Exception e)
            {
                return new UserDeviceResponse($"An error ocurred while saving the UserDevice: {e.Message}");
            }
        }

        public async Task<UserDeviceResponse> UpdateAsync(UserDevice model)
        {
            var result = await _repository.FindByUsersIdAndEntityIdAsync(model.UserDataId, model.DeviceId);
            if (result == null)
                return new UserDeviceResponse("UserDevice not found");

            result.State = model.State;

            try
            {
                result.LastUpdateDate = DateTime.UtcNow;

                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new UserDeviceResponse(result);
            }
            catch (Exception e)
            {
                return new UserDeviceResponse($"An error occurred while updating the Friendship: {e.Message}");
            }
        }
    }
}
