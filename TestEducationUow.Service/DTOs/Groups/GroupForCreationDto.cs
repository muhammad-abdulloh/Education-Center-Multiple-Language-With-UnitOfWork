using System;
using System.ComponentModel.DataAnnotations;
using TestEducationCenterUoW.Domain.Localization;

namespace TestEducationUow.Service.DTOs.Groups
{
    public class GroupForCreationDto : ILocalizationName
    {

        /// <summary>
        /// Multiple language
        /// </summary>

        public string NameUz { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }

        [Required]
        public Guid? TeacherId { get; set; }

        [Required]
        public Guid? CourseId { get; set; }

    }
}
