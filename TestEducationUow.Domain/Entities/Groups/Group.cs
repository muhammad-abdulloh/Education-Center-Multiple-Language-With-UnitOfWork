using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Entities.Courses;
using TestEducationCenterUoW.Domain.Entities.Students;
using TestEducationCenterUoW.Domain.Entities.Teachers;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Domain.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace TestEducationCenterUoW.Domain.Entities.Groups
{
    public class Group : IAuditable, ILocalizationName
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Multilanguage names
        /// </summary>
        [JsonIgnore]
        public string NameUz { get; set; }

        [JsonIgnore]
        public string NameRu { get; set; }

        [JsonIgnore]
        public string NameEn { get; set; }

        [NotMapped]
        public string Name { get; set; }

        public Guid TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }

        public Guid CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
