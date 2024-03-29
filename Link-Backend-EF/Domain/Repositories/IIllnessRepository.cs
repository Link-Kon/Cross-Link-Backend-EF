﻿using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Repositories
{
    public interface IIllnessRepository
    {
        Task<IEnumerable<Illness>> ListAsync();
        Task AddAsync(Illness model);
        Task<Illness> FindByIdAsync(int id);
        Task<Illness> FindByNameAsync(string name);
        void Update(Illness model);
        void Delete(Illness model);
    }
}
