using System.Collections.Generic;
using CicekSepeti.Model;

namespace CicekSepeti.Service
{
    //Base service class for our entities
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}