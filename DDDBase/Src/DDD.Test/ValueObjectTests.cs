using System;
using Xunit;
using Shouldly;

namespace DDD.Test
{
    public class ValueObjectTests
    {
        [Fact]
        public void CreateValueObject()
        {
            string testString = "Unit Test String";
            int testInt = 1234567;
            ValueObjTest sut = new ValueObjTest(testString, testInt); ;

            sut.ShouldNotBeNull();
            sut.TestString.ShouldBe(testString);
            sut.TestInt.ShouldBe(testInt);
        }

        [Fact]
        public void ValueObjectsEqualityIsEqual()
        {
            string testString = "equality test";
            int testInt = 12345;
            ValueObjTest sut;
            ValueObjTest compareSut;
            bool equalsIsEqual;
            bool isEqual;

            sut = new ValueObjTest(testString, testInt);
            compareSut = new ValueObjTest(testString, testInt);

            equalsIsEqual = sut.Equals(compareSut);
            isEqual = sut == compareSut;

            equalsIsEqual.ShouldBeTrue();
            isEqual.ShouldBeTrue();
        }

        [Fact]
        public void ValueObjectsEqualityIsNotEqual()
        {
            string testString = "equality test";
            int testInt = 12345;
            ValueObjTest sut;
            ValueObjTest compareSut;
            bool equalsIsEqual;
            bool isEqual;

            sut = new ValueObjTest(testString, testInt);
            compareSut = new ValueObjTest("other", testInt);

            equalsIsEqual = sut.Equals(compareSut);
            isEqual = sut == compareSut;

            equalsIsEqual.ShouldBeFalse();
            isEqual.ShouldBeFalse();
        }

        [Fact]
        public void ValueObjectObjectEqualityIsNotEqual()
        {
            string testString = "equality test";
            int testInt = 12345;
            ValueObjTest sut;
            Object compareSut;
            bool equalsIsEqual;
            bool isEqual;

            sut = new ValueObjTest(testString, testInt);
            compareSut = new object();

            equalsIsEqual = sut.Equals(compareSut);
            isEqual = sut == compareSut;

            equalsIsEqual.ShouldBeFalse();
            isEqual.ShouldBeFalse();
        }

    }
}
