using System.Collections.Generic;
using CicekSepeti.Model;
using CicekSepeti.Repository;

namespace CicekSepeti.Service
{
    //Implementation of bouquets service to be accessed 
    //Use this methods in our controllers and add new methods if needed
    public class BouquetService : EntityService<Bouquet>, IBouquetService
    {
        private readonly IBouquetRepository _bouquetRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BouquetService(IUnitOfWork unitOfWork, IBouquetRepository bouquetRepository)
            : base(unitOfWork, bouquetRepository)
        {
            _unitOfWork = unitOfWork;
            _bouquetRepository = bouquetRepository;
        }

        public Bouquet GetById(int id)
        {
            return _bouquetRepository.GetById(id);
        }

        public List<BouquetSize> GetSizesOfBouquet(int id)
        {
            return _bouquetRepository.GetSizesOfBouquet(id);
        }

        public List<FlowersInBouquet> GetFlowersInBouquetType(int bouquetSizeId)
        {
            return _bouquetRepository.GetFlowersInBouquetType(bouquetSizeId);
        }

        public void AddBouquet(Bouquet bouquet)
        {
            _bouquetRepository.AddBouquet(bouquet);
            _unitOfWork.Commit();
        }

        public void AddSizeOfBouquet(BouquetSize bouquetSize)
        {
            _bouquetRepository.AddSizeOfBouquet(bouquetSize);
            _unitOfWork.Commit();
        }

        public void AddFlowerToBouquet(FlowersInBouquet flower)
        {
            _bouquetRepository.AddFlowerToBouquet(flower);
            _unitOfWork.Commit();
        }

        public void DeleteBouquet(Bouquet bouquet)
        {
            _bouquetRepository.DeleteBouquet(bouquet);
            _unitOfWork.Commit();
        }

        public void DeleteSizeOfBouquet(BouquetSize bouquetSize)
        {
            _bouquetRepository.DeleteSizeOfBouquet(bouquetSize);
            _unitOfWork.Commit();
        }

        public void DeleteFlowersOfBouquetSize(int bouquetSizeId)
        {
            _bouquetRepository.DeleteFlowersOfBouquetSize(bouquetSizeId);
            _unitOfWork.Commit();
        }

        public void DeleteSizesOfBouquet(int bouquetId)
        {
            _bouquetRepository.DeleteSizesOfBouquet(bouquetId);
            _unitOfWork.Commit();
        }
    }
}