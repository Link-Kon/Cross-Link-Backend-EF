using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;

namespace Link_Backend_EF.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FriendshipService(IFriendshipRepository repository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<FriendshipResponse> GetFriendshipProof(string user1Code, string user2Code)
        {

            try
            {
                var action = await _repository.GetFriendshipProof(user1Code, user2Code);
                await _unitOfWork.CompleteAsync();

                return new FriendshipResponse(action);
            }
            catch (Exception e)
            {
                return new FriendshipResponse($"An error ocurred while saving the Friendship: {e.Message}");
            }
        }

        /*public async Task<FriendshipResponse> Delete(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new FriendshipResponse("Friendship not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new FriendshipResponse(result);
            }
            catch (Exception e)
            {
                return new FriendshipResponse($"An error occurred while deleting the Friendship: {e.Message}");
            }
        }*/

        public async Task<IEnumerable<Friendship>> ListByUserCodeAsync(string code)
        {
            return await _repository.ListByUserCodeAsync(code);
        }

        public async Task<FriendshipResponse> SaveAsync(Friendship model)
        {
            //REVISAR
            var existingCaretakerCode = await _userRepository.FindByCodeAsync(model.User1Code.ToString());
            if (existingCaretakerCode == null)
                return new FriendshipResponse("User1Code not found");

            var existingPatientCode = await _userRepository.FindByCodeAsync(model.User2Code.ToString());
            if (existingPatientCode == null)
                return new FriendshipResponse("User2Code not found");

            if (model.User1Code == model.User2Code)
                return new FriendshipResponse("Both users must no be the same");

            try
            {
                model.CreationDate = DateTime.UtcNow;
                model.LastUpdateDate = null;

                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new FriendshipResponse(model);
            }
            catch (Exception e)
            {
                return new FriendshipResponse($"An error ocurred while saving the Friendship: {e.Message}");
            }
        }

        public async Task<FriendshipResponse> UpdateAsync(Friendship model)
        {
            var result = await _repository.FindByUsersCodeAsync(model.User1Code, model.User2Code);
            if (result == null)
                return new FriendshipResponse("Friendship not found");

            result.State = model.State;

            result.LastUpdateDate = DateTime.UtcNow;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new FriendshipResponse(result);
            }
            catch (Exception e)
            {
                return new FriendshipResponse($"An error occurred while updating the Friendship: {e.Message}");
            }
        }
    }
}
