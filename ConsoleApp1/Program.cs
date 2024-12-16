using ConsoleApp1;
using System;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //основные задания
                /*//1 Создать два объекта типа Team с совпадающими данными и проверить,
                //что ссылки на объекты не равны, а объекты равны, вывести значения
                //хэш - кодов для объектов.
                Team team1 = new Team("Org1", 123);
                Team team2 = new Team("Org1", 123);

                Console.WriteLine($"Are references equal? {ReferenceEquals(team1, team2)}");
                Console.WriteLine($"Are objects equal? {team1 == team2}");
                Console.WriteLine($"Hash code team1: {team1.GetHashCode()}, team2: {team2.GetHashCode()}");

                //2 В блоке try/catch присвоить свойству с номером регистрации
                //некорректное значение, в обработчике исключения вывести сообщение,
                //переданное через объект-исключение.
                try
                {
                    team1.RegistrationNumber = -10;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }

                //3 Создать объект типа ResearchTeam, добавить элементы в список
                //публикаций и список участников проекта и вывести данные объекта
                //ResearchTeam.
                ResearchTeam researchTeam = new ResearchTeam("AI Research", "TechCorp", 456, TimeFrame.TwoYears);
                researchTeam.AddMembers(new Person("Alice", "Smith", DateTime.Now), new Person("Bob", "Johnson", DateTime.Now));
                researchTeam.AddPapers(
                    new Paper("AI in Healthcare", new Person("Dr. Emily", "Brown", DateTime.Now), new DateTime(2021, 5, 1)),
                    new Paper("Future of AI", new Person("Dr. John", "Davis", DateTime.Now), new DateTime(2023, 3, 15))
                );

                Console.WriteLine("Research Team Data:");
                Console.WriteLine(researchTeam);

                //4 Вывести значение свойства Team для объекта типа ResearchTeam.
                Console.WriteLine("Team Data:");
                Console.WriteLine(researchTeam.OrganizationName);

                //5 С помощью метода DeepCopy() создать полную копию объекта
                //ResearchTeam.Изменить данные в исходном объекте ResearchTeam и
                //вывести копию и исходный объект, полная копия исходного объекта
                //должна остаться без изменений.
                ResearchTeam copy = (ResearchTeam)researchTeam.DeepCopy();
                researchTeam.ResearchTopic = "Changed Topic";
                researchTeam.OrganizationName = "NewOrg";
                Console.WriteLine("Original Research Team:");
                Console.WriteLine(researchTeam);
                Console.WriteLine("Copied Research Team:");
                Console.WriteLine(copy);

                //6 С помощью оператора foreach для итератора, определенного в классе
                //ResearchTeam, вывести список участников проекта, которые не имеют
                //публикаций.
                Console.WriteLine("Members without publications:");
                foreach (Person member in researchTeam)
                {
                    Console.WriteLine(member);
                }

                //7 С помощью оператора foreach для итератора с параметром,
                //определенного в классе ResearchTeam, вывести список всех
                //публикаций, вышедших за последние два года.
                Console.WriteLine("Recent Publications:");
                foreach (Paper paper in researchTeam.GetPublicationsInLastYears(2))
                {
                    Console.WriteLine(paper);
                }*/
                //доп задания
                // Создаем объект ResearchTeam и заполняем данными
                ResearchTeam team = new ResearchTeam("AI Research", "TechCorp", 42, TimeFrame.TwoYears);

                // Добавляем участников
                Person alice = new Person("Alice", "Johnson", new DateTime(1990, 5, 1));
                Person bob = new Person("Bob", "Smith", new DateTime(1985, 10, 15));
                Person charlie = new Person("Charlie", "Brown", new DateTime(1992, 3, 20));
                team.AddMembers(alice, bob, charlie);

                // Добавляем публикации
                team.AddPapers(
                    new Paper("AI in Healthcare", alice, new DateTime(2022, 1, 15)),
                    new Paper("Deep Learning Advances", alice, new DateTime(2023, 6, 10)),
                    new Paper("Quantum Computing Basics", bob, new DateTime(2023, 3, 25))
                );

                // Задание 25: Вывести список участников, у которых есть публикации
                Console.WriteLine("Participants with publications:");
                foreach (Person person in team)
                {
                    Console.WriteLine(person);
                }

                // Задание 26: Вывести список участников, имеющих более одной публикации
                Console.WriteLine("\nParticipants with multiple publications:");
                foreach (Person person in team.GetMembersWithMultiplePublications())
                {
                    Console.WriteLine(person);
                }

                // Задание 27: Вывести список публикаций, вышедших за последний год
                Console.WriteLine("\nPublications from the last year:");
                foreach (Paper paper in team.GetRecentPublications())
                {
                    Console.WriteLine(paper);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}");
            }
        }
    }
}
