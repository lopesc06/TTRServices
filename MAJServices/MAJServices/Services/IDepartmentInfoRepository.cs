using MAJServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services
{
    public interface IDepartmentInfoRepository
    {
        Department GetDepartment(string acronym, bool includeMembers , bool includePosts);
        bool DepartmentExists(string acronym);
        IEnumerable<Department> GetDepartments(bool includeMembers, bool includePosts);
        void DeleteDepartment(Department department);
        void AddUserToDepartment(string acronym, User member);
        void DeleteMemberToDepartment(User member);
        void SaveDpmt();
    }
}
