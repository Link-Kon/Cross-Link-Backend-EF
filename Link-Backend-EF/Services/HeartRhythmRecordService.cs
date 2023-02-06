using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;

namespace Link_Backend_EF.Services
{
    public class HeartRhythmRecordService : IHealthRecordService<HeartRhythmRecord>
    {
        private readonly IHealthRecordRepository<HeartIssuesRecord> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HeartRhythmRecordService(IHealthRecordRepository<HeartIssuesRecord> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public Task<HeartRhythmRecord> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HeartRhythmRecord> FindByPatiendIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(HeartRhythmRecord model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, HeartRhythmRecord model)
        {
            throw new NotImplementedException();
        }
    }
}
