using System.Collections.Generic;
using CicekSepeti.Model;

namespace CicekSepeti.Service
{
    public interface IBouquetService : IEntityService<Bouquet>
    {
        Bouquet GetById(int id);
        List<BouquetSize> GetSizesOfBouquet(int id);
        List<FlowersInBouquet> GetFlowersInBouquetType(int bouquetSizeId);
        void AddBouquet(Bouquet bouquet);
        void AddSizeOfBouquet(BouquetSize bouquetSize);
        void AddFlowerToBouquet(FlowersInBouquet flower);
        void DeleteBouquet(Bouquet bouquet);
        void DeleteSizeOfBouquet(BouquetSize bouquetSize);
        void DeleteFlowersOfBouquetSize(int bouquetSizeId);
        void DeleteSizesOfBouquet(int bouquetId);
    }
}