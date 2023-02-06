using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;

namespace Link_Backend_EF.Services
{
    public class PatientService : IUserInfoService<Patient>
    {
        private readonly IUserInfoRepository<Patient> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUserInfoRepository<Patient> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> FindByStringAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Patient model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Patient model)
        {
            throw new NotImplementedException();
        }
    }
}
