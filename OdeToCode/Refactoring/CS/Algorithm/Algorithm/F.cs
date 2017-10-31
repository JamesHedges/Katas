using System;

namespace Algorithm
{
    public class PeopleCompare
    {
        public PeopleCompare()
        {
            Person1 = null;
            Person2 = null;
            BirthdateDifference = TimeSpan.Zero;
        }

        public PeopleCompare(Person first, Person second)
        {
            if (first.BirthDate < second.BirthDate)
            {
                Person1 = first;
                Person2 = second;
            }
            else
            {
                Person1 = second;
                Person2 = first;
            }
            BirthdateDifference = Person2.BirthDate - Person1.BirthDate;
        }
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public TimeSpan BirthdateDifference { get; set; }
    }
}