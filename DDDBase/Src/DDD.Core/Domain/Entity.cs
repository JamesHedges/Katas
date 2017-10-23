namespace DDD.Core.Domain
{
    public abstract class Entity<TIdType> : IEntity<TIdType>
    {
        private TIdType _Id;
        private EntityState _State;

        protected Entity()
        {
            _State = EntityState.Inserted;
        }

        public Entity(TIdType entityId)
        {
            _Id = entityId;
            _State = EntityState.Unchanged;
        }

        public TIdType Id
        {
            get => _Id;
            protected set
            {
                _Id = value;
            }
        }
        public EntityState State
        {
            get => _State;
            protected set
            {
                _State = value;
            }
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