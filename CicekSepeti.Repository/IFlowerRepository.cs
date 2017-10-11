using CicekSepeti.Model;

namespace CicekSepeti.Repository
{
    public interface IFlowerRepository : IGenericRepository<Flower>
    {
        Flower GetById(int id);
    }
}