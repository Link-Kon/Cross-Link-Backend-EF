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

        public async Task<FriendshipResponse> Delete(int id)
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
        }

        public async Task<FriendshipResponse> FindByCaretakerAsync(int id)
        {
            try
            {
                var result = await _repository.FindByCaretakerIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new FriendshipResponse(result);
            }
            catch (Exception e)
            {
                return new FriendshipResponse($"Friendship not found: {e.Message}");
            }
        }

        public async Task<FriendshipResponse> FindByPatiendIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByPatiendIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new FriendshipResponse(result);
            }
            catch (Exception e)
            {
                return new FriendshipResponse($"Friendship not found: {e.Message}");
            }
        }

        public async Task<FriendshipResponse> SaveAsync(Friendship model)
        {
            var existingCaretakerCode = await _userRepository.FindByCodeAsync(model.CaretakerId.ToString());
            if (existingCaretakerCode != null)
                return new FriendshipResponse("Caretaker not found");

            var existingPatientCode = await _userRepository.FindByCodeAsync(model.PatientId.ToString());
            if (existingPatientCode != null)
                return new FriendshipResponse("Patient not found");

            try
            {
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new FriendshipResponse(model);
            }
            catch (Exception e)
            {
                return new FriendshipResponse($"An error ocurred while saving the Friendship: {e.Message}");
            }
        }

        public async Task<FriendshipResponse> Update(int id, Friendship model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new FriendshipResponse("Friendship not found");

            var existingCaretakerCode = await _userRepository.FindByCodeAsync(model.CaretakerId.ToString());
            if (existingCaretakerCode != null)
                return new FriendshipResponse("Caretaker not found");

            var existingPatientCode = await _userRepository.FindByCodeAsync(model.PatientId.ToString());
            if (existingPatientCode != null)
                return new FriendshipResponse("Patient not found");

            result.Active = model.Active;

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
