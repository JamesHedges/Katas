using System;
using DDD.Core.Domain;

namespace DDD.Test
{
    public class TestEntity : Entity<Guid>
    {
        protected TestEntity ()
            : base() { }

        public TestEntity(Guid id)
            : base(id) { }

        public static TestEntity Create()
        {
            return new TestEntity
            {
                Id = Guid.NewGuid()
            };
        }
    }
}
