using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Enums;
using TestEducationCenterUoW.Domain.Localization;

namespace TestEducationCenterUoW.Domain.Entities.Courses
{
    public class Course : IAuditable, ILocalizationName
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

        public decimal Price { get; set; }
        public ushort Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
