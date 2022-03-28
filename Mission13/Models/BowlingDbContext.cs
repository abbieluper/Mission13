using System;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Models
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; } // Bowlers is the name of the table in the database
        public DbSet<Team> Teams { get; set; }
    }
}
