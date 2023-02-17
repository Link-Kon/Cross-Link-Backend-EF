using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{   
    public class UserDataService : IUserInfoService<UserData, UserDataResponse>
    {
        private readonly IUserInfoRepository<UserData> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserDataService(IUserInfoRepository<UserData> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
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

        // Find by Email
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
            var existingUserDataEmail = await _repository.FindByStringAsync(model.Email);
            if (existingUserDataEmail != null)
                return new UserDataResponse("There is already an userData with this email");

            try
            {
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

            result.Active = model.Active;
            result.Email = model.Email;
            result.Name = model.Name;
            result.Lastname = model.Lastname;
            result.UserPhoto = model.UserPhoto;
            
            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new UserDataResponse(result);
            }
            catch (Exception e)
            {
                return new UserDataResponse($"An error occurred while updating the illness: {e.Message}");
            }
        }
    }
}
