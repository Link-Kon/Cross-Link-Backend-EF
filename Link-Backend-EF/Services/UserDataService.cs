using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{
    public class UserDataService : IUserInfoService<UserData, UserDataResponse>, IUserDataService
    {
        private readonly IUserInfoRepository<UserData> _repository;
        private readonly IUserDataRepository _userDataRepository;
        private readonly IFriendshipService _friendshipService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserDataService(IUserInfoRepository<UserData> repository, IUserDataRepository userDataRepository, IFriendshipService friendshipService, IUserService userService, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userDataRepository = userDataRepository;
            _friendshipService = friendshipService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDataResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new UserDataResponse("UserData not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new UserDataResponse(result);
            }
            catch (Exception e)
            {
                return new UserDataResponse($"An error occurred while deleting the userData: {e.Message}");
            }
        }

        public async Task<UserDataResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new UserDataResponse(result);
            }
            catch (Exception e)
            {
                return new UserDataResponse($"UserData not found: {e.Message}");
            }
        }

        // Find by Code
        public async Task<UserDataResponse> FindByStringAsync(string value)
        {
            try
            {
                var result = await _repository.FindByStringAsync(value);
                await _unitOfWork.CompleteAsync();

                return new UserDataResponse(result);
            }
            catch (Exception e)
            {
                return new UserDataResponse($"UserData not found: {e.Message}");
            }
        }

        public async Task<UserDataResponse> SaveAsync(UserData model)
        {
            //var existingUserDataEmail = await _repository.FindByStringAsync(model.Email);
            //if (existingUserDataEmail != null)
            //    return new UserDataResponse("There is already an userData with this email");

            var existingUserCodeFound = await _userService.FindByCodeAsync(model.UserCode);
            if (existingUserCodeFound.Resource.Code != model.UserCode)
                return new UserDataResponse("An error ocurred, please try again later");

            try
            {
                model.UserId = existingUserCodeFound.Resource.Id;
                model.CreationDate = DateTime.UtcNow;
                model.LastUpdateDate = null;

                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new UserDataResponse(model);
            }
            catch (Exception e)
            {
                return new UserDataResponse($"An error ocurred while saving the userData: {e.Message}");
            }
        }

        public async Task<UserDataResponse> UpdateAsync(int id, UserData model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new UserDataResponse("UserData not found");

            var existingUserDataEmail = await _repository.FindByStringAsync(model.Email);
            if (existingUserDataEmail != null)
                return new UserDataResponse("There is already an User with this code");

            result.State = model.State;
            result.Email = model.Email;
            result.Name = model.Name;
            result.Lastname = model.Lastname;
            result.UserPhoto = model.UserPhoto;
            
            result.LastUpdateDate = DateTime.UtcNow;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new UserDataResponse(result);
            }
            catch (Exception e)
            {
                return new UserDataResponse($"An error occurred while updating the user data: {e.Message}");
            }
        }

        public async Task<UserDataResponse> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            try
            {
                var result = await _repository.FindByCodeAndSharedIdAsync(code, sharedId);
                await _unitOfWork.CompleteAsync();

                return new UserDataResponse(result);
            }
            catch (Exception e)
            {
                return new UserDataResponse($"An error occurred while searching for user data: {e.Message}");
            }
        }

        public async Task<UserDataResponse> FindByFriendAsync(string user1Code, string user2Code)
        {
            try
            {
                var verification = await _friendshipService.GetFriendshipProof(user1Code, user2Code);
                if (verification.Success)
                {
                    var result = await _userDataRepository.FindByFriendAsync(user2Code);
                    return new UserDataResponse(result);
                }
                else
                {
                    return new UserDataResponse("There is nothing to search");
                }
            }
            catch (Exception e)
            {
                return new UserDataResponse($"An error occurred while searching for user data: {e.Message}");
            }
        }
    }
}
