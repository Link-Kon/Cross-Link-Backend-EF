using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;

namespace Link_Backend_EF.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public FriendshipService(IFriendshipRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Friendship> FindByCaretakerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Friendship> FindByPatiendIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Friendship model)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Friendship model)
        {
            throw new NotImplementedException();
        }
    }
}
