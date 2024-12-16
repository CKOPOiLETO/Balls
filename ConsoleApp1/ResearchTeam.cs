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
        private Team BaseTeam;

        public ResearchTeam(string topic, string organization, int regNumber, TimeFrame duration)
            : base(organization, regNumber)
        {
            researchTopic = topic;
            researchDuration = duration;
            members = new ArrayList();
            publications = new ArrayList();
            BaseTeam = new Team(organization, regNumber);
        }

        public ResearchTeam() : this("Default Topic", "Default Organization", 1, TimeFrame.Year) { }

        public Team Team { get { return BaseTeam; }
            set {
                BaseTeam.Name = value.Name;
                BaseTeam.RegistrationNumber = value.RegistrationNumber;
            }
        }

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
            foreach (Person person in members)
            {
                if (publications.Count == 0)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable GetPublicationsInLastYears(int years)
        {
            DateTime threshold = DateTime.Now.AddYears(-years);
            foreach (Paper paper in publications)
            {
                if (paper.PublicationDate >= threshold)
                {
                    yield return paper;
                }
            }
        }
    }
}
