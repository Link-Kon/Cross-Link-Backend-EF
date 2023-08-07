using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class PatientRepository : BaseRepository, IUserInfoRepository<Patient>
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Patient model)
        {
            await _context.Patient.AddAsync(model);
        }

        public void Delete(Patient model)
        {
            _context.Patient.Remove(model);
        }

        public async Task<Patient> FindByCodeAndSharedIdAsync(string code, int sharedId)
        {
            Friendship userFriendship = await _context.Friendship
                .Where(f => (f.User1Code == code || f.User2Code == code) && f.SharedId == sharedId)
                .FirstOrDefaultAsync();

            if (userFriendship != null)
            {
                string matchedUserCode = userFriendship.User1Code == code ? userFriendship.User2Code : userFriendship.User1Code;

                User user = await _context.User.FirstOrDefaultAsync(i => i.Code == matchedUserCode);
                return await _context.Patient.FindAsync(user.Id);
            }
            else
            {
                User user = await _context.User.FirstOrDefaultAsync(i => i.Code == code);
                return await _context.Patient.FindAsync(user.Id);
            }
        }

        public async Task<Patient> FindByIdAsync(int id)
        {
            return await _context.Patient.FindAsync(id);
        }

        // Find by UserData->Id
        public async Task<Patient> FindByStringAsync(string value)
        {
            return await _context.Patient.FirstOrDefaultAsync(i => i.UserDataId.ToString() == value);
        }

        public void Update(Patient model)
        {
            _context.Patient.Update(model);
        }

    }
}