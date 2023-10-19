using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Repositories;

namespace Link_Backend_EF.Services
{
    public class DeviceService : IUserInfoService<Device, DeviceResponse>
    {
        private readonly IUserInfoRepository<Device> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeviceService(IUserInfoRepository<Device> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeviceResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new DeviceResponse("Device not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(result);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public Task<DeviceResponse> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            throw new NotImplementedException();
        }

        public async Task<DeviceResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(result);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"User not found: {e.Message}");
            }
        }

        public Task<DeviceResponse> FindByStringAsync(string value)
        {
            throw new NotImplementedException();
        }

        public async Task<DeviceResponse> SaveAsync(Device model)
        {
            try
            {
                model.CreationDate = DateTime.UtcNow;
                model.LastUpdateDate = null;

                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(model);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error ocurred while saving the device: {e.Message}");
            }
        }

        public async Task<DeviceResponse> UpdateAsync(int id, Device model)
        {
            var result = await _repository.FindByIdAsync(id);

            result.Nickname = model.Nickname;
            result.MacAddress = model.MacAddress;
            result.Model = model.Model;
            result.LastUpdateDate = DateTime.UtcNow;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new DeviceResponse(result);
            }
            catch (Exception e)
            {
                return new DeviceResponse($"An error occurred while updating the user: {e.Message}");
            }
        }
    }
}
