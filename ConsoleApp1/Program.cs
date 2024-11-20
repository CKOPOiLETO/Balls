using System;

namespace ResearchTeamApp
{
    class Program
    {
        static void Main()
        {
            // 1. Создание объекта ResearchTeam и вывод с помощью ToShortString()
            ResearchTeam team = new ResearchTeam();
            Console.WriteLine("ResearchTeam (ToShortString):");
            Console.WriteLine(team.ToShortString());

            // 10. Вывод значений индексатора для TimeFrame.Year, TimeFrame.TwoYears, TimeFrame.Long
            Console.WriteLine("\nЗначения индексатора:");
            Console.WriteLine($"TimeFrame.Year: {team[TimeFrame.Year]}");
            Console.WriteLine($"TimeFrame.TwoYears: {team[TimeFrame.TwoYears]}");
            Console.WriteLine($"TimeFrame.Long: {team[TimeFrame.Long]}");

            // 11. Присвоение значений всем свойствам ResearchTeam и вывод с помощью ToString()
            team.ResearchTopic = "AI Development";
            team.Organization = "OpenAI";
            team.RegistrationNumber = 12345;
            team.Duration = TimeFrame.Long;
            Console.WriteLine("\nResearchTeam (ToString) после присвоения значений:");
            Console.WriteLine(team.ToString());

            // 12. Добавление публикаций с помощью AddPapers и вывод данных ResearchTeam
            Paper paper1 = new Paper("AI Paper 1", new Person("Alice", "Smith", new DateTime(1990, 5, 24)), new DateTime(2022, 1, 10));
            Paper paper2 = new Paper("AI Paper 2", new Person("Bob", "Johnson", new DateTime(1985, 8, 12)), new DateTime(2023, 6, 15));
            Paper paper3 = new Paper("AI Paper 3", new Person("Charlie", "Brown", new DateTime(1993, 2, 20)), new DateTime(2021, 11, 5));
            team.AddPapers(paper1, paper2, paper3);
            Console.WriteLine("\nResearchTeam после добавления публикаций:");
            Console.WriteLine(team.ToString());

            // 13. Вывод публикации с самой поздней датой выхода
            Console.WriteLine("\nПубликация с самой поздней датой:");
            Console.WriteLine(team.LatestPaper?.ToString() ?? "Нет публикаций");

            // 14. Сравнение времени выполнения операций с одномерным, двумерным и ступенчатым массивами
            Console.WriteLine("\nСравнение времени выполнения операций с массивами:");
            CompareArrayPerformance();
        }

        static void CompareArrayPerformance()
        {
            int nrow = 100; // количество строк
            int ncolumn = 100; // количество столбцов
            int totalElements = nrow * ncolumn;

            // Одномерный массив
            Paper[] oneDimArray = new Paper[totalElements];
            for (int i = 0; i < totalElements; i++)
            {
                oneDimArray[i] = new Paper();
            }

            // Двумерный прямоугольный массив
            Paper[,] twoDimArray = new Paper[nrow, ncolumn];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncolumn; j++)
                {
                    twoDimArray[i, j] = new Paper();
                }
            }

            // Двумерный ступенчатый массив
            Paper[][] jaggedArray = new Paper[nrow][];
            for (int i = 0; i < nrow; i++)
            {
                jaggedArray[i] = new Paper[ncolumn];
                for (int j = 0; j < ncolumn; j++)
                {
                    jaggedArray[i][j] = new Paper();
                }
            }

            // Измерение времени выполнения операций для одномерного массива
            int start = Environment.TickCount;
            for (int i = 0; i < totalElements; i++)
            {
                oneDimArray[i].Title = "Updated Title";
            }
            int end = Environment.TickCount;
            Console.WriteLine($"Время для одномерного массива: {end - start} мс");

            // Измерение времени выполнения операций для двумерного прямоугольного массива
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

            // Измерение времени выполнения операций для двумерного ступенчатого массива
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

            // Вывод значений nrow и ncolumn
            Console.WriteLine($"\nЧисло строк: {nrow}, Число столбцов: {ncolumn}");
        }
    }
}
