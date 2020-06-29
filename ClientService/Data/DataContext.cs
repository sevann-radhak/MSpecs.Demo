using Microsoft.EntityFrameworkCore;

namespace ClientService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TeamEntity>()
               .HasIndex(t => t.Name)
               .IsUnique();
        }

        public DbSet<TeamEntity> Teams { get; set; }
    }
}
