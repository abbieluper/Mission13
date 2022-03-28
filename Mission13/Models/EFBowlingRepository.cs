using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFBowlingRepository (BowlingDbContext temp)
        {
            _context = temp; 
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;

        public IQueryable<Team> Teams => _context.Teams;


        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges(); 
        }

        public void CreateBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges(); 
        }

        public void UpdateBowler(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges(); 
        }


    }
}
