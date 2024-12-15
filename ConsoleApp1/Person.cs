using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    public class Person : INameAndCopy
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public string Name
        {
            get => $"{FirstName} {LastName}";
            set
            {
                var parts = value.Split(' ');
                if (parts.Length >= 2)
                {
                    FirstName = parts[0];
                    LastName = parts[1];
                }
            }
        }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public Person() : this("DefaultFirstName", "DefaultLastName", DateTime.Now) { }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return FirstName == other.FirstName && LastName == other.LastName && BirthDate == other.BirthDate;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, BirthDate);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Born: {BirthDate.ToShortDateString()}";
        }

        public static bool operator ==(Person left, Person right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Person left, Person right)
        {
            return !Equals(left, right);
        }

        public virtual object DeepCopy()
        {
            return new Person(FirstName, LastName, BirthDate);
        }
    }
}
