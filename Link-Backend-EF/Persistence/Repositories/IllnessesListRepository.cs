using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class IllnessesListRepository : BaseRepository, IListRelationRepository<IllnessesList>
    {
        public IllnessesListRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(IllnessesList model)
        {
            await _context.IllnessList.AddAsync(model);
        }

        public async Task<IllnessesList> FindByUsersIdAndEntityIdAsync(int userId, int deviceId)
        {
            return await _context.IllnessList.FirstOrDefaultAsync(i => i.UserDataId == userId && i.IllnessId == deviceId);
        }

        public async Task<List<IllnessesList>> ListByUserIdAsync(int id)
        {
            return await _context.IllnessList.Where(i => i.UserDataId == id).ToListAsync();
        }

        public void Update(IllnessesList model)
        {
            _context.IllnessList.Update(model);
        }
    }
}
