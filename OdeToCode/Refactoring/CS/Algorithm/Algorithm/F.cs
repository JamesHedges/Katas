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

        public PeopleCompare(Person person1, Person person2)
        {
            if (person1.BirthDate < person2.BirthDate)
            {
                Person1 = person1;
                Person2 = person2;
            }
            else
            {
                Person1 = person2;
                Person2 = person1;
            }
            BirthdateDifference = Person2.BirthDate - Person1.BirthDate;
        }
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public TimeSpan BirthdateDifference { get; set; }
    }
}