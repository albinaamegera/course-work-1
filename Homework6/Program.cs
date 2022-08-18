using System.IO;
using System.Linq;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            // the path to file
            string path = @"staff.txt";

            // check if file does not exist create & add a first note
            if (!File.Exists(path))
            {
                Console.WriteLine("file is empty , add a first note :");
                using (StreamWriter sw = new StreamWriter(path))
                {
                    string note = string.Empty;
                    string[] n = NewWorker();
                    char c = '#';
                    note += 1; // id
                    note += c + n[0]; // date & time
                    note += c + n[1]; // full name
                    note += c + n[2]; // age
                    note += c + n[3]; // height
                    note += c + n[4]; // date of birth
                    note += c + n[5]; // place of birth

                    sw.WriteLine(note);
                }
            // loading data from not empty file
            Repository repository = new Repository(path);
            // program menu
            int a;
            do
            {
                Console.WriteLine("to output data on the screen press 1" +
                    "\nto input new data press 2" +
                    "\nto delete a note press 3" +
                    "\nto edit a note press 4" +
                    "\nto get notes between two dates press 5" +
                    "\nto sort notes by field press 6" +
                    "\nto generate a list of workers press 7" +
                    "\nto exit press 8");
                a = int.Parse(Console.ReadLine());

                switch (a)
                {
                    case 1: repository.PrintToConsole(); break;

                    case 2: string[] stats = NewWorker();
                            repository.Add(true, new Worker(repository.Count + 1,
                                                            stats[0],
                                                            stats[1],
                                                            ushort.Parse(stats[2]),
                                                            ushort.Parse(stats[3]),
                                                            stats[4],
                                                            stats[5])); break;

                    case 3: Console.WriteLine("enter note's id to delete :");
                            repository.Delete(int.Parse(Console.ReadLine())); break;

                    case 4: Console.WriteLine("enter note's id to edit :");
                            int id = int.Parse(Console.ReadLine());
                            string[] stts = NewWorker();
                            repository.Edit(id, new Worker(id,
                                                           stts[0],
                                                           stts[1],
                                                           ushort.Parse(stts[2]),
                                                           ushort.Parse(stts[3]),
                                                           stts[4],
                                                           stts[5])); break;

                    case 5: Console.WriteLine("enter date from (dd.mm.yyyy hh:mm format) :");
                            DateTime from = DateTime.ParseExact(Console.ReadLine(), "g", null);
                            Console.WriteLine("enter date to (dd.mm.yyyy hh:mm format) :");
                            DateTime to = DateTime.ParseExact(Console.ReadLine(), "g", null);
                            repository.GetWorkersBetweenTwoDates(from, to); break;

                    case 6: Console.WriteLine("choose the option :" +
                                              "\nto order by name press 0" +
                                              "\nto order by age press 1" +
                                              "\nto order by height press 2" +
                                              "\nto order by date of birth press 3" +
                                              "\nto order by hometown press 4");
                            int k = int.Parse(Console.ReadLine());
                            OrderWorkersBy(k, repository.Workers); break;

                    case 7: Console.WriteLine("enter a number of workers you want to generate :"); 
                            int count = int.Parse(Console.ReadLine()); 
                            repository.GenerateWorkers(count); break;

                    default: break;
                }
            } while (a != 8);            
        }
        // method to enter worker fields 
        // returns string array
        public static string[] NewWorker()
        {
            string[] str = new string[6];
            str[0] = DateTime.Now.ToString("g");
            Console.WriteLine("enter the full name :");
            str[1] = Console.ReadLine();
            Console.WriteLine("enter the age :");
            str[2] = Console.ReadLine();
            Console.WriteLine("enter the height :");
            str[3] = Console.ReadLine();
            Console.WriteLine("enter the date of birth (dd.mm.yyyy format) :");
            str[4] = Console.ReadLine();
            Console.WriteLine("enter the hometown :");
            str[5] = Console.ReadLine();

            return str;
        }
        // method to order workers by choosen field
        // outputs on the screen ordered list
        public static void OrderWorkersBy(int option, Worker[] workers)
        {
            Worker[] orderedWorkers = workers;
            IEnumerable<Worker> query;
            switch (option)
            {
                case 0: query = orderedWorkers.OrderBy(w => w.FullName); break;
                case 1: query = orderedWorkers.OrderBy(w => w.Age); break;
                case 2: query = orderedWorkers.OrderBy(w => w.Height); break;
                case 3: query = orderedWorkers.OrderBy(w => w.DateOfBirth); break;
                case 4: query = orderedWorkers.OrderBy(w => w.HomeTown); break;
                default: Console.WriteLine("wrong option !"); return; break;
            }
            foreach (Worker w in query) 
                Console.WriteLine("{0, 3} {1, 20} {2, 25} {3, 4} {4, 5} {5, 15} {6, 10}",
                                            w.Id,
                                            w.RegTime.ToString("g"),
                                            w.FullName,
                                            w.Age,
                                            w.Height,
                                            w.DateOfBirth.ToString("d"),
                                            w.HomeTown);
        }
    }
}