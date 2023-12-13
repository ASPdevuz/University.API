namespace University.API.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Direction { get; set; }
        public int Degree { get; set; }
        public int FacultyId { get; set; }
        public List<Course> Courses { get; set; }
        public virtual Faculty Faculty { get; set; }
        public object Course { get; internal set; }
    }
}
