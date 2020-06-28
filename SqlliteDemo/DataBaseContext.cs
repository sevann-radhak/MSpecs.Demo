using Microsoft.EntityFrameworkCore;

namespace SqlliteDemo
{
    public class DataBaseContext : DbContext
    {
        private readonly string _connectionString;

        public DataBaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

        }
    }
}
