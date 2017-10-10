using System;

namespace DDD.Shared.Domain
{
    public abstract class Entity<TIdType> : IEquatable<Entity<TIdType>>
    {
        public TIdType Id { get; set; }
        public EntityState State { get; set; }

        protected Entity()
        {
            State = EntityState.Inserted;
        }

        public Entity(TIdType entityId)
        {
            Id = entityId;
            State = EntityState.Unchanged;
        }

        public override bool Equals(object other)
        {
            return other is Entity<TIdType> && this == (Entity<TIdType>)other;
        }

        public bool Equals(Entity<TIdType> other)
        {
            return other != null && Id.Equals(other.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TIdType> entity1, Entity<TIdType> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            return (entity1.Id.ToString() == entity2.Id.ToString());
        }

        public static bool operator !=(Entity<TIdType> entity1, Entity<TIdType> entity2)
        {
            return (!(entity1 == entity2));
        }

    }
}
