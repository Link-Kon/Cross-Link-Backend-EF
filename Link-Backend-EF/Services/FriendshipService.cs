using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Domain.Services;
using Link_Backend_EF.Domain.Services.Communication;
using Link_Backend_EF.Resources;

namespace Link_Backend_EF.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly IFriendshipRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUserInfoRepository<UserData> _userDataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FriendshipService(IFriendshipRepository repository, IUserRepository userRepository, IUserInfoRepository<UserData> userDataRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _userRepository = userRepository;
            _userDataRepository = userDataRepository;
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

        public async Task<IEnumerable<FriendshipListResponse>> ListByUserCodeAsync(string code)
        {
            var response = new List<FriendshipListResponse>();

            var result = await _repository.ListByUserCodeAsync(code);

            // Filter the results to include only distinct user codes related to the given code
            var distinctResult = result
                .Where(f => f.User1Code == code || f.User2Code == code)
                .SelectMany(f => new[] { f.User1Code, f.User2Code })
                .Distinct()
                .Where(userCode => userCode != code)
                .ToList();

            for (int i = 0; i < distinctResult.Count; i++)
            {
                var userCodesResult = await _userDataRepository.FindByStringAsync(distinctResult[i]);
                var itemList = new FriendshipListResponse()
                {
                    Code = distinctResult[i],
                    Name = userCodesResult.Name,
                    Lastname = userCodesResult.Lastname,
                    CreationDate = userCodesResult.CreationDate
                };
                response.Add(itemList);
            }

            return response;
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
