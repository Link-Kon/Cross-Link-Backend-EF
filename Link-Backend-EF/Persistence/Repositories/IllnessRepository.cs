using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class IllnessRepository : BaseRepository, IIllnessRepository
    {
        public IllnessRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Illness illness)
        {
            await _context.Illness.AddAsync(illness);
        }

        public void Delete(Illness illness)
        {
            _context.Illness.Remove(illness);
        }

        public async Task<Illness> FindByIdAsync(int id)
        {
            return await _context.Illness.FindAsync(id);
        }
        
        public async Task<Illness> FindByNameAsync(string name)
        {
            return await _context.Illness.FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<IEnumerable<Illness>> ListAsync()
        {
            return await _context.Illness.ToListAsync();
        }

        public void Update(Illness illness)
        {
            _context.Illness.Update(illness);
        }
    }
}
