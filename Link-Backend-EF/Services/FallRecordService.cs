using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Persistence.Repositories;

namespace Link_Backend_EF.Services
{
    public class FallRecordService : IHealthRecordService<FallRecord>
    {
        private readonly IHealthRecordRepository<FallRecord> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FallRecordService(IHealthRecordRepository<FallRecord> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public Task<FallRecord> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FallRecord> FindByPatiendIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(FallRecord model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, FallRecord model)
        {
            throw new NotImplementedException();
        }
    }
}
