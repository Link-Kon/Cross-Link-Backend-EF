using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Resources.Base;

namespace Link_Backend_EF.Services
{
    public class UserService : IUserInfoService<User, UserResponse>, IUserService
    {
        private readonly IUserInfoRepository<User> _repository;
        private readonly IUserInfoRepository<UserData> _userDatarepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserInfoRepository<User> repository, IUserInfoRepository<UserData> userDatarepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userDatarepository = userDatarepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new UserResponse("User not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public Task<UserResponse> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"User not found: {e.Message}");
            }
        }

        // Find by Username
        public async Task<UserResponse> FindByStringAsync(string value)
        {
            try
            {
                var result1 = await _repository.FindByStringAsync(value);
                var result2 = await _userDatarepository.FindByStringAsync(result1.Code);

                await _unitOfWork.CompleteAsync();

                return new UserResponse(result2);
            }
            catch (Exception e)
            {
                return new UserResponse($"User not found: {e.Message}");
            }
        }

        public async Task<UserResponse> FindByIdAndOldTokenAsync(TokenValidationResource resource)
        {
            try
            {
                var result = await _userRepository.FindByIdAndOldTokenAsync(resource.Id, resource.OldToken);

                if (result != null)
                {
                    var userReToken = await _repository.FindByIdAsync(resource.Id);
                    userReToken.Token = resource.NewToken;
                    userReToken.Attempt = 0;

                    _repository.Update(userReToken);
                    await _unitOfWork.CompleteAsync();

                    return new UserResponse(userReToken);
                }
                else
                {
                    var userWarning = await _repository.FindByIdAsync(resource.Id);
                    userWarning.Attempt += 1;

                    _repository.Update(userWarning);
                    await _unitOfWork.CompleteAsync();

                    string warningMessage = "El token colocado no existe";

                    return new UserResponse(warningMessage);
                }
            }
            catch (Exception e)
            {
                return new UserResponse($"User not found: {e.Message}");
            }
        }

        public async Task<UserResponse> SaveAsync(User model)
        {
            var existingVal = await _userRepository.FindByCodeAsync(model.Code);
            if (existingVal != null)
                return new UserResponse("There is already a user with this code");

            try
            {
                model.Code = Guid.NewGuid().ToString();
                model.CreationDate = DateTime.UtcNow;
                model.LastUpdateDate = null;
                model.Attempt = 0;

                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(model);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User model)
        {
            var result = await _userRepository.FindByCodeAsync(model.Code);
            if (result == null)
                return new UserResponse("User not found");

            //var existingUserCode = await _userRepository.FindByCodeAsync(model.Code);
            //if (existingUserCode != null)
            //    return new UserResponse("There is already an User with this code");

            //result.Username = model.Username;
            if (result.Token == model.Token)
            {
                model.Token = result.Token;
            }
            else
            {
                result.Token = model.Token;
            }
            result.DeviceToken = model.DeviceToken;

            result.LastUpdateDate = DateTime.UtcNow;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while updating the user: {e.Message}");
            }
        }

        public async Task<UserResponse> FindByCodeAsync(string code)
        {
            try
            {
                var result = await _userRepository.FindByCodeAsync(code);

                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"User not found: {e.Message}");
            }
        }
    }
}
