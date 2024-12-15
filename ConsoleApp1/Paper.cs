using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    public class Paper : INameAndCopy
    {
        public string Title { get; set; }
        public Person Author { get; set; }
        public DateTime PublicationDate { get; set; }

        public string Name
        {
            get => Title;
            set => Title = value;
        }

        public Paper(string title, Person author, DateTime publicationDate)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        public Paper() : this("Default Title", new Person(), DateTime.Now) { }

        public virtual object DeepCopy()
        {
            return new Paper(Title, (Person)Author.DeepCopy(), PublicationDate);
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Published: {PublicationDate.ToShortDateString()}";
        }
    }
}
