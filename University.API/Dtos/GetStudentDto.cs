using University.API.Entities;

namespace University.API.Dtos
{
    public class GetStudentDto
    {
        public GetStudentDto(Student entity)
        {
            Id = entity.Id;
            Fullname = entity.Fullname;
            PhoneNumber = entity.PhoneNumber;
            Age = entity.Age;
            Direction = entity.Direction;
            Degree = entity.Degree;
            FacultyId = entity.FacultyId;

        }
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Direction { get; set; }
        public int Degree { get; set; }
        public int FacultyId { get; set; }
    }
}
