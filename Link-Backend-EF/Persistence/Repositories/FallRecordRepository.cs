using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class FallRecordRepository : BaseRepository, IHealthRecordRepository<FallRecord>
    {
        public FallRecordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(FallRecord model)
        {
            await _context.FallRecord.AddAsync(model);
        }

        public async Task<FallRecord> FindByIdAsync(int id)
        {
            return await _context.FallRecord.FindAsync(id);
        }

        public async Task<FallRecord> FindByPatiendIdAsync(int id)
        {
            return await _context.FallRecord.FirstOrDefaultAsync(i => i.UserDataId == id);
        }

        public void Update(FallRecord model)
        {
            _context.FallRecord.Update(model);
        }
    }
}