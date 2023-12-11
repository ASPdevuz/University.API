using University.API.Entities;

namespace University.API.Dtos
{
    public class GetCuorseDto
    {
        public GetCuorseDto(Course entity)
        {         
            Id = entity.Id;
            Name = entity.Name;
            Level = entity.Level;
            Duration = entity.Duration; 
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Level { get; set; }
        public string Duration { get; set; }
    }
}
