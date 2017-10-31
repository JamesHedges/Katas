using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;
        private readonly IPeopleCompareFilter _filter;

        public Finder(List<Person> person, IPeopleCompareFilter filter)
        {
            _people = person;
            _filter = filter;
        }

        public PeopleCompare Find()
        {
            List<PeopleCompare> peoplePairs = GetPeopleCombinations(_people);

            return _filter.ApplyFilter(peoplePairs);
            //return ComparePeople(furthestClosest, peoplePairs);
        }

        private List<PeopleCompare> GetPeopleCombinations(List<Person> people)
        {
            var peoplePairs = new List<PeopleCompare>();

            for (var i = 0; i < people.Count - 1; i++)
            {
                for (var j = i + 1; j < people.Count; j++)
                {
                    peoplePairs.Add(new PeopleCompare(people[i], people[j]));
                }
            }
            return peoplePairs;
        }
    }

    public interface IPeopleCompareFilter
    {
        PeopleCompare ApplyFilter(List<PeopleCompare> people);
    }

    public class ClosesBirthdateCompareFilter : IPeopleCompareFilter
    {
        public PeopleCompare ApplyFilter(List<PeopleCompare> peoplePairs)
        {
            var compareResult = peoplePairs.OrderBy(pp => pp.BirthdateDifference).FirstOrDefault();
            return compareResult ?? new PeopleCompare();
        }
    }

    public class FurthestBirthdateCompareFilter : IPeopleCompareFilter
    {
        public PeopleCompare ApplyFilter(List<PeopleCompare> peoplePairs)
        {
            var compareResult = peoplePairs.OrderByDescending(pp => pp.BirthdateDifference).FirstOrDefault();
            return compareResult ?? new PeopleCompare();
        }
    }
}