using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlingRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        IQueryable<Team> Teams { get; }

        public void DeleteBowler(Bowler b);
        public void CreateBowler(Bowler b);
        public void UpdateBowler(Bowler b); 

    }
}
