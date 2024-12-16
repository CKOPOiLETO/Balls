using System;

namespace ConsoleApp1
{
    public class Team : INameAndCopy

    {
        protected string organizationName;
        protected int registrationNumber;

        public Team(string organizationName, int registrationNumber)
        {
            if (registrationNumber <= 0)
            {
                throw new ArgumentException("Registration number must be greater than 0.", nameof(registrationNumber));
            }
            this.organizationName = organizationName;
            this.registrationNumber = registrationNumber;
        }

        public Team() : this("Default Organization", 1) { }

        public string OrganizationName
        {
            get => organizationName;
            set => organizationName = value;
        }

        public int RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Registration number must be greater than 0.", nameof(value));
                }
                registrationNumber = value;
            }
        }

        public string Name { get; set; }

        public virtual object DeepCopy()
        {
            return new Team(this.organizationName, this.registrationNumber) { Name = this.Name };
        }

        public override bool Equals(object obj)
        {
            if (obj is Team other)
            {
                return organizationName == other.organizationName && registrationNumber == other.registrationNumber;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(organizationName, registrationNumber);
        }

        public override string ToString()
        {
            return $"Organization: {organizationName}, Registration Number: {registrationNumber}";
        }

        public static bool operator ==(Team left, Team right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Team left, Team right)
        {
            return !Equals(left, right);
        }
    }
}
