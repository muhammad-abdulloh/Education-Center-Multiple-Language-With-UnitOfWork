using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestEducationCenterUoW.Domain.Commons;
using TestEducationCenterUoW.Domain.Configurations;
using TestEducationCenterUoW.Domain.Entities.Groups;
using TestEducationUow.Service.DTOs.Groups;
using TestEducationUow.Service.Interfaces;

namespace TestEducationUow.Service.Services
{
    public class GroupService : IGroupService
    {
        public Task<BaseResponse<Group>> CreateAsync(GroupForCreationDto groupDto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Group, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<Group>>> GetAllAsync(PaginationParams @params, Expression<Func<Group, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Group>> GetAsync(Expression<Func<Group, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Group>> UpdateAsync(Guid id, GroupForCreationDto groupDto)
        {
            throw new NotImplementedException();
        }
    }
}
