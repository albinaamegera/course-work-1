namespace Homework6 {
    struct Worker
    {
        #region fields
        private int id;
        private DateTime regTime;
        private string fullName;
        private ushort age;
        private ushort height;
        private DateTime dateOfBirth;
        private string homeTown;
        #endregion
        #region constructor
        public Worker(int id, DateTime regTime, string fullName, ushort age, ushort height, DateTime dateOfBirth, string homeTown)
        {
            this.id = id;
            this.regTime = regTime;
            this.fullName = fullName;
            this.age = age;
            this.height = height;
            this.dateOfBirth = dateOfBirth;
            this.homeTown = homeTown;
        }
        #endregion
        #region attributes
        public int Id { get { return id; } }
        public DateTime RegTime { get { return regTime; } }
        public string FullName { get { return fullName; } }
        public ushort Age { get { return age; } }
        public ushort Height { get { return height} }
        public DateTime DateOfBirth { get { return dateOfBirth} }
        public string HomeTown { get { return homeTown} }
        #endregion
    }
}