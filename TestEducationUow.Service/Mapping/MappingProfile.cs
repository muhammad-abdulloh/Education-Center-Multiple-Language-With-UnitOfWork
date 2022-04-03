using AutoMapper;
using TestEducationCenterUoW.Domain.Entities.Students;
using TestEducationCenterUoW.Service.DTOs.Students;

namespace TestEducationUow.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentForCreationDto, Student>().ReverseMap();
        }
    }
}
