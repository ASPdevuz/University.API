namespace University.API.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Level { get; set; }
        public string Duration { get; set; }
        public List<Student> Students { get; set; }
    }
}
