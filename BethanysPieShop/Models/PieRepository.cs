using System.Collections.Generic;
using System.Linq;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext db;

        public PieRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Pie> GetAllPies()
        {
            return db.Pies;
        }

        public Pie GetPieById(int pieId)
        {
            return db.Pies.FirstOrDefault(p => p.Id == pieId);
        }
    }
}
