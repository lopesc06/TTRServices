using MAJServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Services
{
    public interface IDepartmentInfoRepository
    {
        Department GetDepartment(string departmentName, bool includeMembers , bool includePosts);
        bool DepartmentExists(string departmentName);
        IEnumerable<Department> GetDepartments(bool includeMembers, bool includePosts);
        void DeleteDepartment(string depaertmentName);
        void AddUserToDepartment(string departmentName, User user);
        void GetSaved();
    }
}
