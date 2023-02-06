using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class HeartIssuesRecordRepository : BaseRepository, IHealthRecordRepository<HeartIssuesRecord>
    {
        public HeartIssuesRecordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(HeartIssuesRecord model)
        {
            await _context.HeartIssuesRecord.AddAsync(model);
        }

        public async Task<HeartIssuesRecord> FindByIdAsync(int id)
        {
            return await _context.HeartIssuesRecord.FindAsync(id);
        }

        public async Task<HeartIssuesRecord> FindByPatiendIdAsync(int id)
        {
            return await _context.HeartIssuesRecord.FirstOrDefaultAsync(i => i.UserDataId == id);
        }

        public void Update(HeartIssuesRecord model)
        {
            _context.HeartIssuesRecord.Update(model);
        }
    }
}