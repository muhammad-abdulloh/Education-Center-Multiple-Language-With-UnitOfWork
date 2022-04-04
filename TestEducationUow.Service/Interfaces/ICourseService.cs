using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Courses;
using TestEducationUow.Service.DTOs.Courses;

namespace TestEducationUow.Service.Interfaces
{
    public interface ICourseService
    {
        Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto courseDto);
        Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression);
        Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression);
        Task<BaseResponse<Course>> UpdateAsync(Guid id, CourseForCreationDto courseDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
