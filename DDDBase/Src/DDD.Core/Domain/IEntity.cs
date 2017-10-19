﻿using System;

namespace DDD.Shared.Domain
{
    public interface IEntity<TIdType> : IEquatable<Entity<TIdType>>
    {
        TIdType Id { get; }
        EntityState State { get; }
    }
}
