using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{
    public class HeartIssuesRecordService : IHealthRecordService<HeartIssuesRecord, HeartIssuesRecordResponse>
    {
        private readonly IHealthRecordRepository<HeartIssuesRecord> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HeartIssuesRecordService(IHealthRecordRepository<HeartIssuesRecord> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<HeartIssuesRecordResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new HeartIssuesRecordResponse(result);
            }
            catch (Exception e)
            {
                return new HeartIssuesRecordResponse($"HeartIssuesRecord not found: {e.Message}");
            }
        }

        public async Task<HeartIssuesRecordResponse> FindByPatiendIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByPatiendIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new HeartIssuesRecordResponse(result);
            }
            catch (Exception e)
            {
                return new HeartIssuesRecordResponse($"HeartIssuesRecord not found: {e.Message}");
            }
        }

        public async Task<HeartIssuesRecordResponse> SaveAsync(HeartIssuesRecord model)
        {
            try
            {
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new HeartIssuesRecordResponse(model);
            }
            catch (Exception e)
            {
                return new HeartIssuesRecordResponse($"An error ocurred while saving the HeartIssuesRecord: {e.Message}");
            }
        }

        public async Task<HeartIssuesRecordResponse> Update(int id, HeartIssuesRecord model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new HeartIssuesRecordResponse("HeartIssuesRecord not found");

            result.LectureDate = model.LectureDate;
            result.Severity = model.Severity;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new HeartIssuesRecordResponse(result);
            }
            catch (Exception e)
            {
                return new HeartIssuesRecordResponse($"An error occurred while updating the HeartIssuesRecord: {e.Message}");
            }
        }
    }
}
