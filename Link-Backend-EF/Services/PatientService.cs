using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{
    public class PatientService : IUserInfoService<Patient,PatientResponse>
    {
        private readonly IUserInfoRepository<Patient> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUserInfoRepository<Patient> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PatientResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new PatientResponse("Patient not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(result);
            }
            catch (Exception e)
            {
                return new PatientResponse($"An error occurred while deleting the patient: {e.Message}");
            }
        }

        public async Task<PatientResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(result);
            }
            catch (Exception e)
            {
                return new PatientResponse($"UserData not found: {e.Message}");
            }
        }

        // Find by UserData->Id
        public async Task<PatientResponse> FindByStringAsync(string value)
        {
            try
            {
                var result = await _repository.FindByStringAsync(value);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(result);
            }
            catch (Exception e)
            {
                return new PatientResponse($"Patient not found: {e.Message}");
            }
        }

        public async Task<PatientResponse> SaveAsync(Patient model)
        {
            var existingUserDataId = await _repository.FindByStringAsync(model.UserDataId.ToString());
            if (existingUserDataId != null)
                return new PatientResponse("There is already an patient with this patient");

            try
            {
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(model);
            }
            catch (Exception e)
            {
                return new PatientResponse($"An error ocurred while saving the patient: {e.Message}");
            }
        }

        public async Task<PatientResponse> UpdateAsync(int id, Patient model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new PatientResponse("Patient not found");

            result.Active = model.Active;
            result.Height = model.Height;
            result.Weight = model.Weight;
            result.Country = model.Country;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(result);
            }
            catch (Exception e)
            {
                return new PatientResponse($"An error occurred while updating the patient: {e.Message}");
            }
        }
    }
}
