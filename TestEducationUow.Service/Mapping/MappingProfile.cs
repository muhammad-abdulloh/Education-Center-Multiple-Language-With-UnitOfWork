using AutoMapper;
using TestEducationCenterUoW.Domain.Entities.Courses;
using TestEducationCenterUoW.Domain.Entities.Students;
using TestEducationCenterUoW.Domain.Entities.Teachers;
using TestEducationCenterUoW.Service.DTOs.Students;
using TestEducationUow.Service.DTOs.Courses;
using TestEducationUow.Service.DTOs.Teachers;

namespace TestEducationUow.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentForCreationDto, Student>().ReverseMap();
            CreateMap<CourseForCreationDto, Course>().ReverseMap();
            CreateMap<TeacherForCreationDto, Teacher>().ReverseMap();
        }
    }
}
