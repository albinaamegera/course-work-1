namespace Homework6 {
    struct Worker
    {
        #region fields
        private int id; // id
        private DateTime regTime; // note's registration time
        private string fullName; // full name
        private ushort age; // age
        private ushort height; // height
        private DateTime dateOfBirth; // date of birth
        private string homeTown; // hometown

        private string pattern1 = "dd.MM.yyyy HH:mm";
        private string pattern2 = "dd.MM.yyyy";

        #endregion
        #region constructors
        // default worker
        public Worker(int id)
            : this(id, DateTime.Now.ToString("dd.MM.yyyy HH:mm"), "Name" + id, 0, 0, "01.01.2000", "None") { }
        // custom worker
        public Worker(int id, string regTime, string fullName, ushort age, ushort height, string dateOfBirth, string homeTown)
        {
            this.id = id;
            this.regTime = DateTime.ParseExact(regTime, pattern1, null);
            this.fullName = fullName;
            this.age = age;
            this.height = height;
            this.dateOfBirth = DateTime.ParseExact(dateOfBirth, pattern2, null);
            this.homeTown = homeTown;
        }
        #endregion
        #region attributes
        public int Id { get { return id; } }
        public DateTime RegTime { get { return regTime; } }
        public string FullName { get { return fullName; } }
        public ushort Age { get { return age; } }
        public ushort Height { get { return height; } }
        public DateTime DateOfBirth { get { return dateOfBirth; } }
        public string HomeTown { get { return homeTown; } }
        #endregion
        #region methods
        // print to console worker's data
        public void Print()
        {
            Console.WriteLine("{0, 3} {1, 20} {2, 25} {3, 4} {4, 5} {5, 15} {6, 10}",
                              Id,
                              RegTime.ToString(pattern1),
                              FullName,
                              Age,
                              Height,
                              DateOfBirth.ToString(pattern2),
                              HomeTown);
        }
        #endregion
    }
}