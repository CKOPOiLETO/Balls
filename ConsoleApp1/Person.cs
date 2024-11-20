using System;

public class Person
{
    private string firstName;
    private string lastName;
    private DateTime birthDate;

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
    }

    public Person()
    {
        firstName = "Имя";
        lastName = "Фамилия";
        birthDate = new DateTime(2000, 1, 1);
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    public override string ToString()
    {
        return $"Имя: {firstName}, Фамилия: {lastName}, Дата рождения: {birthDate.ToShortDateString()}";
    }

    public virtual string ToShortString()
    {
        return $"{firstName} {lastName}";
    }
}
