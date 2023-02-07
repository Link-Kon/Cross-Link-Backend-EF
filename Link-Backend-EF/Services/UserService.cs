using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{
    public class UserService : IUserInfoService<User, UserResponse>
    {
        private readonly IUserInfoRepository<User> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserInfoRepository<User> repository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserResponse> Delete(int id)
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
                var result = await _repository.FindByStringAsync(value);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"User not found: {e.Message}");
            }
        }

        public async Task<UserResponse> SaveAsync(User model)
        {
            var existingIllnessName = await _userRepository.FindByCodeAsync(model.Code);
            if (existingIllnessName != null)
                return new UserResponse("There is already an illness with this name");

            try
            {
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(model);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<UserResponse> Update(int id, User model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new UserResponse("User not found");

            var existingUserCode = await _userRepository.FindByCodeAsync(model.Code);
            if (existingUserCode != null)
                return new UserResponse("There is already an User with this code");

            result.Code = model.Code;
            result.Username = model.Username;
            result.Password = model.Password;

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
    }
}
