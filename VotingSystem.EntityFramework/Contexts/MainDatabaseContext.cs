using Microsoft.EntityFrameworkCore;
using VotingSystem.Domain;

namespace VotingSystem.EntityFramework
{
    public class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        //Add-Migration -Context MainDatabaseContext -o Migrations/MainDatabaseMigrations <Nazwa migracji>
        //Remove-Migration -Context MainDatabaseContext
        
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Voting> Votings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
