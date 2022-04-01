using System.ComponentModel.DataAnnotations;

namespace TestEducationUow.Service.DTOs.Courses
{
    public class CourseForCreationDto
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ushort Duration { get; set; }

    }
}
