using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Teachers;
using TestEducationUow.Service.DTOs.Teachers;

namespace TestEducationUow.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<BaseResponse<Teacher>> CreateAsync(TeacherForCreationDto teachertDto);
        Task<BaseResponse<Teacher>> GetAsync(Expression<Func<Teacher, bool>> expression);
        Task<BaseResponse<IEnumerable<Teacher>>> GetAllAsync(PaginationParams @params, Expression<Func<Teacher, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Teacher, bool>> expression);
        Task<BaseResponse<Teacher>> UpdateAsync(Guid id, TeacherForCreationDto teachertDto);

        Task<string> SaveFileAsync(Stream file, string fileName);
    }
}
