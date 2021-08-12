using System;

namespace CrudSeries
{
    class Program
    {
        static Repository repository = new Repository();
        static void Main(string[] args)
        {
            string userChoice = UserChoice();

            while (userChoice.ToUpper() != "X")
            {
                switch (userChoice)
                {
                    case "1":
                        SeriesList();
                        break;
                    case "2":
                        Insert();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        GetById();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userChoice = UserChoice();
            }
        }

        private static void GetById()
        {
            Console.WriteLine("Choose the id of the series you want to delete: ");
            int idEntry = int.Parse(Console.ReadLine());
            Console.WriteLine(repository.GetById(idEntry).ToString());
        }

        private static void Delete()
        {

            Console.WriteLine("Delete series");
            Console.WriteLine("Choose the id of the series you want to delete: ");
            int idEntry = int.Parse(Console.ReadLine());
            repository.Delete(idEntry);
        }

        private static void Update()
        {
            foreach (int i in Enum.GetValues(typeof(Type)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Type), i));
            }
            Console.Write("Choose the category of the series from the options above: ");
            int categoryEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert series name: ");
            string nameEntry = Console.ReadLine();

            Console.Write("Insert the year the series debuted: ");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert a descripton for the series: ");
            string descriptionEntry = Console.ReadLine();

            Console.WriteLine("Choose the id of the series you want to update: ");
            int idEntry = int.Parse(Console.ReadLine());

            Series updatedEntry = new Series(idEntry,
                                            (Type)categoryEntry,
                                            nameEntry,
                                            descriptionEntry,
                                            yearEntry);
            repository.Update(idEntry, updatedEntry);


        }

        private static void Insert()
        {
            Console.WriteLine("Add new series");

            foreach (int i in Enum.GetValues(typeof(Type)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Type), i));
            }
            Console.Write("Choose the category of the series from the options above: ");
            int categoryEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert series name: ");
            string nameEntry = Console.ReadLine();

            Console.Write("Insert the year the series debuted: ");
            int yearEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert a descripton for the series: ");
            string descriptionEntry = Console.ReadLine();

            Series newEntry = new Series(repository.NextId(),
                                            (Type)categoryEntry,
                                            nameEntry,
                                            descriptionEntry,
                                            yearEntry);
            repository.Insert(newEntry);

        }

        private static void SeriesList()
        {
            Console.WriteLine("List of Series");
            var list = repository.SeriesList();

            if (list.Count == 0)
            {
                Console.WriteLine("No series found!");
                return;
            }

            foreach (var series in list)
            {
                var deleted = series.Deleted;
                if (deleted)
                    Console.WriteLine("#Id {0}: - {1} is deleted", series.returnId(), series.returnTitle());
                else
                    Console.WriteLine("#Id {0}: - {1}", series.returnId(), series.returnTitle());

            }
        }

        private static string UserChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to SeriesSelect!");
            Console.WriteLine("Choose an option: ");

            Console.WriteLine("1 - List all series");
            Console.WriteLine("2 - Insert new series");
            Console.WriteLine("3 - Update series");
            Console.WriteLine("4 - Delete series");
            Console.WriteLine("5 - View selected series");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");

            string userChoice = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userChoice;
        }
    }
}
