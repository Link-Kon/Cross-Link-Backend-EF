using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;

namespace Link_Backend_EF.Services
{
    public class UserDataService : IUserInfoService<UserData>
    {
        private readonly IUserInfoRepository<UserData> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserDataService(IUserInfoRepository<UserData> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserData> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserData> FindByStringAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(UserData model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UserData model)
        {
            throw new NotImplementedException();
        }
    }
}
