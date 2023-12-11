namespace University.API.Dtos
{
    public class CreateStudentDto
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Direction { get; set; }
        public int Degree { get; set; }
        public int FacultyId { get; set; }
    }
}
