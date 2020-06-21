using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity: IEquatable<Entity> 
    {
       public Guid Id {get; private set;}

       protected Entity()
       {
          Id = Guid.NewGuid();
       }

       
       public bool Equals(Entity other)
       {
          return Id==other.Id;
       }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
