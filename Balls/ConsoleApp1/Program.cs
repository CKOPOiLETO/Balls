using System;

namespace ResearchTeamApp
{
    class Program
    {
        static void Main()
        {
            
            ResearchTeam team = new ResearchTeam();
            Console.WriteLine("ResearchTeam (ToShortString):");
            Console.WriteLine(team.ToShortString());

            
            Console.WriteLine("\nЗначения индексатора:");
            Console.WriteLine($"TimeFrame.Year: {team[TimeFrame.Year]}");
            Console.WriteLine($"TimeFrame.TwoYears: {team[TimeFrame.TwoYears]}");
            Console.WriteLine($"TimeFrame.Long: {team[TimeFrame.Long]}");

            
            team.ResearchTopic = "Stas Development";
            team.Organization = "Open Pivo";
            team.RegistrationNumber = 12345;
            team.Duration = TimeFrame.Long;
            Console.WriteLine("\nResearchTeam (ToString) после присвоения значений:");
            Console.WriteLine(team.ToString());

            
            Paper paper1 = new Paper("Paper 1", new Person("Антон", "Чигур", new DateTime(1990, 5, 24)), new DateTime(2022, 1, 10));
            Paper paper2 = new Paper("Paper 2", new Person("Арсений", "Бузынин", new DateTime(1985, 8, 12)), new DateTime(2023, 6, 15));
            Paper paper3 = new Paper("Paper 3", new Person("Александр", "Каменный", new DateTime(1993, 2, 20)), new DateTime(2021, 11, 5));
            team.AddPapers(paper1, paper2, paper3);
            Console.WriteLine("\nResearchTeam после добавления публикаций:");
            Console.WriteLine(team.ToString());

            
            Console.WriteLine("\nПубликация с самой поздней датой:");
            Console.WriteLine(team.LatestPaper?.ToString() ?? "Нет публикаций");

            
            Console.WriteLine("\nСравнение времени выполнения операций с массивами:");
            CompareArrayPerformance();
        }

        static void CompareArrayPerformance()
        {
            int nrow = 100; 
            int ncolumn = 100; 
            int totalElements = nrow * ncolumn;

            
            Paper[] oneDimArray = new Paper[totalElements];
            for (int i = 0; i < totalElements; i++)
            {
                oneDimArray[i] = new Paper();
            }

            
            Paper[,] twoDimArray = new Paper[nrow, ncolumn];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    twoDimArray[i, j] = new Paper();
                }
            }

            
            Paper[][] jaggedArray = new Paper[nrow][];
            for (int i = 0; i < nrow; i++)
            {
                jaggedArray[i] = new Paper[ncolumn];
                for (int j = 0; j < ncolumn; j++)
                {
                    jaggedArray[i][j] = new Paper();
                }
            }

            int start = Environment.TickCount;
            for (int i = 0; i < totalElements; i++)
            {
                oneDimArray[i].Title = "Updated Title";
            }
            int end = Environment.TickCount;
            Console.WriteLine($"Время для одномерного массива: {end - start} мс");

            start = Environment.TickCount;
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    twoDimArray[i, j].Title = "Updated Title";
                }
            }
            end = Environment.TickCount;
            Console.WriteLine($"Время для двумерного массива: {end - start} мс");

            start = Environment.TickCount;
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    jaggedArray[i][j].Title = "Updated Title";
                }
            }
            end = Environment.TickCount;
            Console.WriteLine($"Время для ступенчатого массива: {end - start} мс");

            Console.WriteLine($"\nЧисло строк: {nrow}, Число столбцов: {ncolumn}");
        }
    }
}

