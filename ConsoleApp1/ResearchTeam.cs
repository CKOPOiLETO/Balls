using ConsoleApp1;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ResearchTeam : Team, IEnumerable
    {
        private string researchTopic;
        private TimeFrame researchDuration;
        private ArrayList members;
        private ArrayList publications;

        public ResearchTeam(string topic, string organization, int regNumber, TimeFrame duration)
            : base(organization, regNumber)
        {
            researchTopic = topic;
            researchDuration = duration;
            members = new ArrayList();
            publications = new ArrayList();
        }

        public ResearchTeam() : this("Default Topic", "Default Organization", 1, TimeFrame.Year) { }

        public string ResearchTopic
        {
            get => researchTopic;
            set => researchTopic = value;
        }

        public TimeFrame ResearchDuration
        {
            get => researchDuration;
            set => researchDuration = value;
        }

        public ArrayList Members
        {
            get => members;
            set => members = value;
        }

        public ArrayList Publications
        {
            get => publications;
            set => publications = value;
        }

        public Paper LatestPublication
        {
            get
            {
                if (publications.Count == 0) return null;
                Paper latest = (Paper)publications[0];
                foreach (Paper paper in publications)
                {
                    if (paper.PublicationDate > latest.PublicationDate)
                    {
                        latest = paper;
                    }
                }
                return latest;
            }
        }

        public void AddPapers(params Paper[] papers)
        {
            foreach (var paper in papers)
            {
                publications.Add(paper);
            }
        }

        public void AddMembers(params Person[] persons)
        {
            foreach (var person in persons)
            {
                members.Add(person);
            }
        }

        public override object DeepCopy()
        {
            var copy = new ResearchTeam(researchTopic, OrganizationName, RegistrationNumber, researchDuration)
            {
                Name = this.Name,
                Members = (ArrayList)this.members.Clone(),
                Publications = (ArrayList)this.publications.Clone()
            };
            return copy;
        }

        public override string ToString()
        {
            string publicationsInfo = string.Join("\n", publications.ToArray());
            string membersInfo = string.Join("\n", members.ToArray());
            return $"Topic: {researchTopic}, Duration: {researchDuration}, Organization: {OrganizationName}\n" +
                   $"Publications:\n{publicationsInfo}\nMembers:\n{membersInfo}";
        }

        public string ToShortString()
        {
            return $"Topic: {researchTopic}, Duration: {researchDuration}, Organization: {OrganizationName}";
        }

        public IEnumerator GetEnumerator()
        {
            return new ResearchTeamEnumerator(members, publications);
        }

        public IEnumerable GetMembersWithMultiplePublications()
        {
            foreach (Person person in members)
            {
                int publicationCount = 0;
                foreach (Paper paper in publications)
                {
                    if (paper.Author == person)
                    {
                        publicationCount++;
                    }
                }
                if (publicationCount > 1)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable GetRecentPublications()
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            foreach (Paper paper in publications)
            {
                if (paper.PublicationDate >= oneYearAgo)
                {
                    yield return paper;
                }
            }
        }

        private class ResearchTeamEnumerator : IEnumerator
        {
            private readonly ArrayList members;
            private readonly ArrayList publications;
            private int position = -1;

            public ResearchTeamEnumerator(ArrayList members, ArrayList publications)
            {
                this.members = members;
                this.publications = publications;
            }

            public object Current
            {
                get
                {
                    if (position < 0 || position >= members.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    Person currentPerson = (Person)members[position];
                    foreach (Paper paper in publications)
                    {
                        if (paper.Author == currentPerson)
                        {
                            return currentPerson;
                        }
                    }
                    return null;
                }
            }

            public bool MoveNext()
            {
                while (++position < members.Count)
                {
                    Person currentPerson = (Person)members[position];
                    foreach (Paper paper in publications)
                    {
                        if (paper.Author == currentPerson)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}
