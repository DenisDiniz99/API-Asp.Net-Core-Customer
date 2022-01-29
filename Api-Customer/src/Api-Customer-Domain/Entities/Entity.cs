using System;

namespace Api_Customer_Domain.Entities
{
    public abstract class Entity
    {
        protected Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
