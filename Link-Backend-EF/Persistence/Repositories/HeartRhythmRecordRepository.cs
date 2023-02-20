using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Domain.Repositories;
using Link_Backend_EF.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Repositories
{
    public class HeartRhythmRecordRepository : BaseRepository, IHealthRecordRepository<HeartRhythmRecord>
    {
        public HeartRhythmRecordRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(HeartRhythmRecord model)
        {
            await _context.HeartRhythmRecord.AddAsync(model);
        }

        public async Task<HeartRhythmRecord> FindByIdAsync(int id)
        {
            return await _context.HeartRhythmRecord.FindAsync(id);
        }

        public async Task<HeartRhythmRecord> FindByPatiendIdAsync(int id)
        {
            return await _context.HeartRhythmRecord.FirstOrDefaultAsync(i => i.PatientId == id);
        }

        public void Update(HeartRhythmRecord model)
        {
            _context.HeartRhythmRecord.Update(model);
        }
    }
}