using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Shouldly;
using DDD.Core.Domain;

namespace DDD.Test
{
    public class EntityTests
    {
        private readonly ITestOutputHelper _OutputHelper;

        public EntityTests(ITestOutputHelper outputHelper)
        {
            _OutputHelper = outputHelper;
        }

        [Fact]
        public void CreateEntityIdIsCreated()
        {
            TestEntity sut;
            
            sut = TestEntity.Create();

            sut.Id.ShouldNotBeNull();
            sut.Id.ShouldBeOfType(typeof(Guid));
            sut.State.ShouldBe(EntityState.Inserted);
        }

        [Fact]
        public void ExistingEntityHasGivenId()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;

            sut = new TestEntity(entityId);

            sut.Id.ShouldBe(entityId);
            sut.Id.ShouldBeOfType(typeof(Guid));
            sut.State.ShouldBe(EntityState.Unchanged);
        }

        [Fact]
        public void EntityEqualityAreEqual()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;
            TestEntity testEntity;
            bool testResult;

            testEntity = new TestEntity(entityId);
            sut = new TestEntity(entityId);

            testResult = sut == testEntity;

            testResult.ShouldBeTrue();
        }

        [Fact]
        public void EntityEqualityAreNotEqual()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;
            TestEntity testEntity;
            bool testResult;

            testEntity = TestEntity.Create();
            sut = new TestEntity(entityId);

            testResult = sut == testEntity;

            testResult.ShouldBeFalse();
        }

        [Fact]
        public void EntityInEqualityAreEqual()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;
            TestEntity testEntity;
            bool testResult;

            testEntity = new TestEntity(entityId);
            sut = new TestEntity(entityId);

            testResult = sut != testEntity;

            testResult.ShouldBeFalse();
        }

        [Fact]
        public void EntityInEqualityAreNotEqual()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;
            TestEntity testEntity;
            bool testResult;

            testEntity = TestEntity.Create();
            sut = new TestEntity(entityId);

            testResult = sut != testEntity;

            testResult.ShouldBeTrue();
        }

        [Fact]
        public void EntityObjectEqualityAreNotEqual()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;
            Object testEntity;
            bool testResult;

            testEntity = new Object();
            sut = new TestEntity(entityId);

            testResult = sut == testEntity;

            testResult.ShouldBeFalse();
        }

        [Fact]
        public void EntityObjectInEqualityAreNotEqual()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;
            Object testEntity;
            bool testResult;

            testEntity = new Object();
            sut = new TestEntity(entityId);

            testResult = sut != testEntity;

            testResult.ShouldBeTrue();
        }

        [Fact]
        public void ExistingEntityHasIdHashCode()
        {
            Guid entityId = Guid.NewGuid();
            TestEntity sut;

            sut = new TestEntity(entityId);

            sut.GetHashCode().ShouldBe(entityId.GetHashCode());
        }
    }

    public class ValueObjTest : ValueObject<ValueObjTest>
    {
        public ValueObjTest(string testString, int testInt)
            : base()
        {
            TestString = testString;
            TestInt = testInt;
        }

        public string TestString { get; }
        public int TestInt { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new List<object> { TestString, TestInt };
        }
    }
}
