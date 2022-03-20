using CreciSP.Domain.Enum;
using CreciSP.Domain.Models;
using CreciSP.Repository.Context;
using CreciSP.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Domain.Services.UserRepository
{
    public class UserRepository : Persist, IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<ICollection<User>> GetUsersByFilters(string nome, string email, UserTypeEnum type)
        {
            //var cmd = $@"";
            //var result = await GetListResultByQueryAsync<TermCourseOfferingGroupDto>(sql, new { academicTermId, classLevelId });
            return null;
        }
    }
}
