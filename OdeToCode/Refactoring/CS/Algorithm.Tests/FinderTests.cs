using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            IPeopleCompareFilter filter = new FurthestBirthdateCompareFilter();
            var finder = new Finder(list, filter);

            var result = finder.Find();

            Assert.Null(result.Person1);
            Assert.Null(result.Person2);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            IPeopleCompareFilter filter = new ClosesBirthdateCompareFilter();
            var finder = new Finder(list, filter);

            var result = finder.Find();

            Assert.Null(result.Person1);
            Assert.Null(result.Person2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            IPeopleCompareFilter filter = new ClosesBirthdateCompareFilter();
            var finder = new Finder(list, filter);

            var result = finder.Find();

            Assert.Same(sue, result.Person1);
            Assert.Same(greg, result.Person2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            IPeopleCompareFilter filter = new FurthestBirthdateCompareFilter();
            var finder = new Finder(list, filter);

            var result = finder.Find();

            Assert.Same(greg, result.Person1);
            Assert.Same(mike, result.Person2);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            IPeopleCompareFilter filter = new FurthestBirthdateCompareFilter();
            var finder = new Finder(list, filter);

            var result = finder.Find();

            Assert.Same(sue, result.Person1);
            Assert.Same(sarah, result.Person2);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            IPeopleCompareFilter filter = new ClosesBirthdateCompareFilter();
            var finder = new Finder(list, filter);

            var result = finder.Find();

            Assert.Same(sue, result.Person1);
            Assert.Same(greg, result.Person2);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}