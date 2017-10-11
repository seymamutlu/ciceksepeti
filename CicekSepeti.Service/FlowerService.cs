using CicekSepeti.Model;
using CicekSepeti.Repository;

namespace CicekSepeti.Service
{
    //Implementation of flowers service to be accessed 
    //Use this methods in our controllers and add new methods if needed
    public class FlowerService : EntityService<Flower>, IFlowerService
    {
        private readonly IFlowerRepository _flowerRepository;
        private IUnitOfWork _unitOfWork;

        public FlowerService(IUnitOfWork unitOfWork, IFlowerRepository flowerRepository)
            : base(unitOfWork, flowerRepository)
        {
            _unitOfWork = unitOfWork;
            _flowerRepository = flowerRepository;
        }

        public Flower GetById(int id)
        {
            return _flowerRepository.GetById(id);
        }
    }
}