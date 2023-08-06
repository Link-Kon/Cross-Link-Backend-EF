using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Persistence.Repositories;

namespace Link_Backend_EF.Services
{
    public class FallRecordService : IHealthRecordService<FallRecord, FallRecordResponse>
    {
        private readonly IHealthRecordRepository<FallRecord> _repository;
        private readonly IUserInfoRepository<Patient> _patientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FallRecordService(IHealthRecordRepository<FallRecord> repository, IUserInfoRepository<Patient> patientRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<FallRecordResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new FallRecordResponse(result);
            }
            catch (Exception e)
            {
                return new FallRecordResponse($"FallRecord not found: {e.Message}");
            }
        }

        public async Task<FallRecordResponse> FindByPatiendIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByPatiendIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new FallRecordResponse(result);
            }
            catch (Exception e)
            {
                return new FallRecordResponse($"FallRecord not found: {e.Message}");
            }
        }

        public async Task<FallRecordResponse> SaveAsync(FallRecord model)
        {
            var result = await _patientRepository.FindByIdAsync(model.PatientId);
            if (result == null)
                return new FallRecordResponse("The patient do not exit");

            if (result.State == false)
                return new FallRecordResponse("The patient must be active");

            try
            {
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new FallRecordResponse(model);
            }
            catch (Exception e)
            {
                return new FallRecordResponse($"An error ocurred while saving the FallRecord: {e.Message}");
            }
        }

        public async Task<FallRecordResponse> UpdateAsync(int id, FallRecord model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new FallRecordResponse("FallRecord not found");

            result.LectureDate = model.LectureDate;
            result.Severity = model.Severity;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new FallRecordResponse(result);
            }
            catch (Exception e)
            {
                return new FallRecordResponse($"An error occurred while updating the FallRecord: {e.Message}");
            }
        }
    }
}
