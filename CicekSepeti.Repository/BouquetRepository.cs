using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CicekSepeti.Model;

namespace CicekSepeti.Repository
{
    //Repository class of Bouquets
    //Access the database context using these methods 
    public class BouquetRepository : GenericRepository<Bouquet>, IBouquetRepository
    {
        public BouquetRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<Bouquet> GetAll()
        {
            return _entities.Set<Bouquet>().ToList();
        }

        public Bouquet GetById(int id)
        {
            return _dbset.FirstOrDefault(x => x.Id == id);
        }

        public List<BouquetSize> GetSizesOfBouquet(int id)
        {
            return _entities.Set<BouquetSize>().Where(x => x.BouquetId == id).ToList();
        }

        public List<FlowersInBouquet> GetFlowersInBouquetType(int bouquetSizeId)
        {
            return _entities.Set<FlowersInBouquet>().Where(x => x.BouquetSizeId == bouquetSizeId).ToList();
        }

        public void AddBouquet(Bouquet bouquet)
        {
            _dbset.Add(bouquet);
        }

        public void AddSizeOfBouquet(BouquetSize bouquetSize)
        {
            _entities.Set<BouquetSize>().Add(bouquetSize);
        }

        public void AddFlowerToBouquet(FlowersInBouquet flower)
        {
            _entities.Set<FlowersInBouquet>().Add(flower);
        }

        public void DeleteBouquet(Bouquet bouquet)
        {
            _dbset.Remove(bouquet);
        }

        public void DeleteSizeOfBouquet(BouquetSize bouquetSize)
        {
            _entities.Set<BouquetSize>().Remove(bouquetSize);
        }

        public void DeleteSizesOfBouquet(int bouquetId)
        {
            _entities.Set<BouquetSize>().RemoveRange(_entities.Set<BouquetSize>().Where(x => x.BouquetId == bouquetId));
        }

        public void DeleteFlowersOfBouquetSize(int bouquetSizeId)
        {
            _entities.Set<FlowersInBouquet>()
                .RemoveRange(_entities.Set<FlowersInBouquet>().Where(x => x.BouquetSizeId == bouquetSizeId));
        }
    }
}