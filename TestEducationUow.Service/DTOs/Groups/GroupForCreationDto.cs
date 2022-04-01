using System;
using System.ComponentModel.DataAnnotations;

namespace TestEducationUow.Service.DTOs.Groups
{
    public class GroupForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid? TeacherId { get; set; }

        [Required]
        public Guid? CourseId { get; set; }
    }
}
