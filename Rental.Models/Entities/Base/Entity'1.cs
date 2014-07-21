namespace Rental.Models.Entities.Base
{
    public class Entity<T> : Entity
    {
        public virtual T Id { get; set; }
    }
}
