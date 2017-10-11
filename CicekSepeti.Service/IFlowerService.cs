using CicekSepeti.Model;

namespace CicekSepeti.Service
{
    public interface IFlowerService : IEntityService<Flower>
    {
        Flower GetById(int id);
    }
}