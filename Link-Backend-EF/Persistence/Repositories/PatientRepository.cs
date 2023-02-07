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