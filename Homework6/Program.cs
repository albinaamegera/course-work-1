using System.IO;

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            // by default file does not exist
            // to create file - create first note (to input new data press 2)
            // if file exists but is empty - the program will report
            // to close program press 3

            string path = @"staff.txt";
            int a;
            do
            {
                Console.WriteLine("to output data on the screen press 1" +
                    "\nto input new data press 2" +
                    "\nto exit press 3");
                a = int.Parse(Console.ReadLine());

                switch (a)
                {
                    case 1: OutputData(path); break;
                    case 2: InputData(path); break;
                    default: break;
                }
            } while (a != 3);            
        }
        public static void InputData(string path)
        {
            
            string c = "#";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    string note = string.Empty;
                    note += c + 1; // id
                    note += c + DateTime.Now.ToString("dd.MM.yyyy HH.mm"); // date & time
                    note += c + Console.ReadLine(); // full name
                    note += c + Console.ReadLine(); // age
                    note += c + Console.ReadLine(); // height
                    note += c + Console.ReadLine(); // date of birth
                    note += c + Console.ReadLine(); // place of birth

                    sw.WriteLine(note);
                }
                return;
            }

            int id = 1;
            StreamReader sr = new StreamReader(path);
            if (!String.IsNullOrWhiteSpace(sr.ReadLine()) || !String.IsNullOrEmpty(sr.ReadLine()))
            {
                do id++;
                while (sr.ReadLine() != null);
                sr.Close();
            }
            else
            {
                sr.Close();
                File.Delete(path);
                InputData(path);
                return;
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                string note = string.Empty;

                note += c + id; // id
                note += c + DateTime.Now.ToString("dd.MM.yyyy HH.mm"); // date & time
                note += c + Console.ReadLine(); // full name
                note += c + Console.ReadLine(); // age
                note += c + Console.ReadLine(); // height
                note += c + Console.ReadLine(); // date of birth
                note += c + Console.ReadLine(); // place of birth

                sw.WriteLine(note);

            }
        }
        
        public static void OutputData(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("file does not exist !");
                return;
            }
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split("#");
                    if (data.Length <= 1 && i == 0)
                    {
                        Console.WriteLine("file is empty");
                        break;
                    }
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",
                        data[1],
                        data[2],
                        data[3],
                        data[4],
                        data[5],
                        data[6],
                        data[7]);
                    i++;
                }
            }
        }
    }
}