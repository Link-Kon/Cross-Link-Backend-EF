using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;

namespace Link_Backend_EF.Services
{
    public class UserService : IUserInfoService<User>
    {
        private readonly IUserInfoRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserInfoRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByStringAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(User model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User model)
        {
            throw new NotImplementedException();
        }
    }
}
