using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CicekSepeti.Model;

namespace CicekSepeti.Repository
{
    //Repository class for Flowers
    public class FlowerRepository : GenericRepository<Flower>, IFlowerRepository
    {
        public FlowerRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<Flower> GetAll()
        {
            return _entities.Set<Flower>().ToList();
        }

        public Flower GetById(int id)
        {
            return _dbset.FirstOrDefault(x => x.Id == id);
        }
    }
}