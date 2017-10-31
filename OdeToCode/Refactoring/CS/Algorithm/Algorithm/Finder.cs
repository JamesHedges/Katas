using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _people;

        public Finder(List<Person> person)
        {
            _people = person;
        }

        public PeopleCompare Find(FurthestClosest furthestClosest)
        {
            List<PeopleCompare> peoplePairs = GetPeopleCombinations(_people);

            return ComparePeople(furthestClosest, peoplePairs);
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

        private PeopleCompare GetClosestPair(List<PeopleCompare> peoplePairs)
        {
            return peoplePairs.OrderBy(pp => pp.BirthdateDifference).FirstOrDefault();
        }

        private PeopleCompare GetFurthestPair(List<PeopleCompare> peoplePairs)
        {
            return peoplePairs.OrderByDescending(pp => pp.BirthdateDifference).FirstOrDefault();
        }

        private PeopleCompare ComparePeople(FurthestClosest furthersClosest, List<PeopleCompare> peoplePairs)
        {
            PeopleCompare answer;

            switch (furthersClosest)
            {
                case FurthestClosest.Closest:
                    answer = GetClosestPair(peoplePairs);
                    break;
                case FurthestClosest.Furthest:
                    answer = GetFurthestPair(peoplePairs);
                    break;
                default:
                    answer = new PeopleCompare();
                    break;
            }
            return answer ?? new PeopleCompare();
        }
    }
}