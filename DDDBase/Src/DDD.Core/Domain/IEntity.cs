using System;

namespace DDD.Core.Domain
{
    public interface IEntity<TIdType> : IEquatable<Entity<TIdType>>
    {
        TIdType Id { get; }
        EntityState State { get; }
    }
}
