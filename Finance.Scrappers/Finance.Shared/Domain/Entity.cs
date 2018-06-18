using System;

namespace Finance.Scrappers.Domain.Entities
{
    public abstract class Entity<keyType>
    {
        public keyType Id { get; protected set; }
    }

    public abstract class Entity : Entity<Guid> { 
               
    }
}
