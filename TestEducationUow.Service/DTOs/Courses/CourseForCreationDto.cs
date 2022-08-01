using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TestEducationCenterUoW.Domain.Localization;

namespace TestEducationUow.Service.DTOs.Courses
{
    public class CourseForCreationDto : ILocalizationName
    {
        [Required]
        public string NameUz { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public decimal Price { get; set; }
        public ushort Duration { get; set; }
        public string CourseForId { get; set; }
        public string CourseType { get; set; }
        public string CourseAuthor { get; set; }
        public IFormFile CourseImageUrl { get; set; }
        public string CourseDescription { get; set; }
        public int Star { get; set; }

    }
}
