using Link_Backend_EF.Domain.Models;
using Link_Backend_EF.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Link_Backend_EF.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Illness> Illness { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Constrains

            builder.UseSnakeCaseNamingConvention();
        }
    }
}
