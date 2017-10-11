namespace CicekSepeti.Model
{
    //Abstract base class for the Id column in the tabless
    public abstract class BaseEntity
    {
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }
}