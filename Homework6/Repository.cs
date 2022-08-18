namespace Homework6
{
    struct Repository
    {
        private int index;
        private Worker[] workers;
        private string path; // path to file

        public Repository(string path)
        {
            this.path = path;
            index = 0;
            workers = new Worker[1];

            Load();
        }
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref workers, workers.Length * 2);
            }
        }
        // create a new worker
        public void Add(bool save, Worker concreteWorker)
        {
            Resize(index >= workers.Length);
            workers[index] = concreteWorker;
            index++;
            if (save) Save(concreteWorker);
        }
        // delete worker by index
        public void Delete(int id)
        {
            for (int i = id - 1; i < index - 1; i++)
            {
                workers[i] = new Worker(i + 1,
                                        workers[i + 1].RegTime.ToString("g"),
                                        workers[i + 1].FullName,
                                        workers[i + 1].Age,
                                        workers[i + 1].Height,
                                        workers[i + 1].DateOfBirth.ToString("d"),
                                        workers[i + 1].HomeTown);
            }
            index--;
            File.Delete(path);
            for (int i = 0; i < index; i++) Save(workers[i]);
        }
        // edit worker by index
        public void Edit(int id, Worker concreteWorker)
        {
            workers[id - 1] = concreteWorker;
            File.Delete(path);
            for (int i = 0; i < index; i++) Save(workers[i]);
        }
        // generates an amount of workers with default fields
        public void GenerateWorkers(int count)
        {
            for (int i = 0; i < count; i++)
                Add(true, new Worker(index + 1));
        }
        // reads data from file
        private void Load()
        {
            using(StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string[] str = line.Split('#');
                    Add(false, new Worker(int.Parse(str[0]),
                                   str[1],
                                   str[2],
                                   ushort.Parse(str[3]),
                                   ushort.Parse(str[4]),
                                   str[5],
                                   str[6]));
                }
            }
        }
        // writes a new worker in the end of file
        private void Save(Worker worker)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                string note = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                            worker.Id,
                                            worker.RegTime.ToString("dd.MM.yyyy HH:mm"),
                                            worker.FullName,
                                            worker.Age,
                                            worker.Height,
                                            worker.DateOfBirth.ToString("d"),
                                            worker.HomeTown);
                sw.WriteLine(note);
            }
        }
        // returns a list of workers between two dates of registration 
        // inclusive from and inclusive to
        public void GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            int count = 0;
            for (int i = 0; i < index; i++)
            {
                if (workers[i].RegTime.CompareTo(dateFrom) >= 0 && workers[i].RegTime.CompareTo(dateTo) <= 0)
                    count++;
            }
            if (count == 0)
                Console.WriteLine("not found");
            else
            {
                Worker[] w = new Worker[count];
                count = 0;
                for (int i = 0; i < index; i++)
                {
                    if (workers[i].RegTime.CompareTo(dateFrom) >= 0 && workers[i].RegTime.CompareTo(dateTo) <= 0) 
                    { 
                        w[count] = workers[i];
                        count++;
                    }
                }
                foreach (Worker worker in w) worker.Print();
            } 
        }
        // prints data base on the screen
        public void PrintToConsole()
        {
            for (int i = 0; i < index; i++) workers[i].Print();
        }
        public int Count { get { return index; } }

        public Worker[] Workers { get { Worker[] w = new Worker[index];
                                        for (int i = 0; i < index; i++)
                                            w[i] = workers[i];
                                        return w; } }
    }
}