using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{
    public class HeartRhythmRecordService : IHealthRecordService<HeartRhythmRecord, HeartRhythmRecordResponse>
    {
        private readonly IHealthRecordRepository<HeartRhythmRecord> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HeartRhythmRecordService(IHealthRecordRepository<HeartRhythmRecord> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<HeartRhythmRecordResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new HeartRhythmRecordResponse(result);
            }
            catch (Exception e)
            {
                return new HeartRhythmRecordResponse($"HeartRhythmRecord not found: {e.Message}");
            }
        }

        public async Task<HeartRhythmRecordResponse> FindByPatiendIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByPatiendIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new HeartRhythmRecordResponse(result);
            }
            catch (Exception e)
            {
                return new HeartRhythmRecordResponse($"HeartRhythmRecord not found: {e.Message}");
            }
        }

        public async Task<HeartRhythmRecordResponse> SaveAsync(HeartRhythmRecord model)
        {
            try
            {
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new HeartRhythmRecordResponse(model);
            }
            catch (Exception e)
            {
                return new HeartRhythmRecordResponse($"An error ocurred while saving the HeartRhythmRecord: {e.Message}");
            }
        }

        public async Task<HeartRhythmRecordResponse> UpdateAsync(int id, HeartRhythmRecord model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new HeartRhythmRecordResponse("HeartRhythmRecord not found");

            result.LectureDate = model.LectureDate;
            result.Bpm = model.Bpm;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new HeartRhythmRecordResponse(result);
            }
            catch (Exception e)
            {
                return new HeartRhythmRecordResponse($"An error occurred while updating the HeartRhythmRecord: {e.Message}");
            }
        }
    }
}
