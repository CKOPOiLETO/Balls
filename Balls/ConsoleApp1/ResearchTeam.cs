using System;
using System.Linq;

public class ResearchTeam
{
    private string researchTopic;
    private string organization;
    private int registrationNumber;
    private TimeFrame duration;
    private Paper[] papers;

    public ResearchTeam(string researchTopic, string organization, int registrationNumber, TimeFrame duration)
    {
        this.researchTopic = researchTopic;
        this.organization = organization;
        this.registrationNumber = registrationNumber;
        this.duration = duration;
        papers = new Paper[0];
    }

    public ResearchTeam()
    {
        researchTopic = "Без темы";
        organization = "Неизвестная организация";
        registrationNumber = 0;
        duration = TimeFrame.Year;
        papers = new Paper[0];
    }

    public string ResearchTopic
    {
        get { return researchTopic; }
        set { researchTopic = value; }
    }

    public string Organization
    {
        get { return organization; }
        set { organization = value; }
    }

    public int RegistrationNumber
    {
        get { return registrationNumber; }
        set { registrationNumber = value; }
    }

    public TimeFrame Duration
    {
        get { return duration; }
        set { duration = value; }
    }

    public Paper[] Papers
    {
        get { return papers; }
        set { papers = value; }
    }

    public Paper LatestPaper
    {
        get
        {
            if (papers.Length == 0) return null;
            return papers.OrderByDescending(p => p.PublicationDate).First();
        }
    }

    public bool this[TimeFrame timeFrame]
    {
        get { return duration == timeFrame; }
    }

    public void AddPapers(params Paper[] newPapers)
    {
        int currentLength = papers.Length;
        Array.Resize(ref papers, currentLength + newPapers.Length);
        Array.Copy(newPapers, 0, papers, currentLength, newPapers.Length);
    }

    public override string ToString()
    {
        string papersList = papers.Length == 0 ? "Нет публикаций" : string.Join("\n", papers.Select(p => p.ToString()));
        return $"Тема: {researchTopic}, Организация: {organization}, Регистрационный номер: {registrationNumber}, " +
               $"Продолжительность: {duration}, Публикации:\n{papersList}";
    }

    public virtual string ToShortString()
    {
        return $"Тема: {researchTopic}, Организация: {organization}, Регистрационный номер: {registrationNumber}, " +
               $"Продолжительность: {duration}";
    }
}
