﻿using System;
using System.Collections.Generic;
using System.Linq;
using MAJServices.Entities;
using Microsoft.EntityFrameworkCore;

namespace MAJServices.Services
{
    public class DepartmentInfoRepository:IDepartmentInfoRepository
    {
        private InfoContext _infoContext;
        public DepartmentInfoRepository(InfoContext infoContext)
        {
            _infoContext = infoContext;
        }

        public void AddUserToDepartment(string acronym, UserIdentity member)
        {
            var department = _infoContext.Departments.Where(dpt => dpt.DepartmentAcronym == acronym).FirstOrDefault();
            department.Members.Add(member);
        }

        public void DeleteDepartment(Department department)
        {
            _infoContext.Departments.Remove(department);
        }

        public void DeleteMemberToDepartment(UserIdentity member)
        {
            _infoContext.Users.Remove(member);
        }

        public bool DepartmentExists(string acronym)
        {
            return _infoContext.Departments.Any(dpt => dpt.DepartmentAcronym == acronym);
        }

        public Department GetDepartment(string acronym, bool includeMembers, bool includePosts)
        {
            if( includeMembers && includePosts){
                return _infoContext.Departments.Include(dpt => dpt.Members).ThenInclude(Users => Users.AsQueryable().Include(p=>p.Posts)).Where(dpt => dpt.DepartmentAcronym == acronym).FirstOrDefault();

            }
            else if(includeMembers && includePosts == false){
                return _infoContext.Departments.Include(dpt => dpt.Members).Where(dpt => dpt.DepartmentAcronym == acronym).FirstOrDefault();
            }
            return _infoContext.Departments.Where(dpt => dpt.DepartmentAcronym == acronym).FirstOrDefault();
        }
        
        public IEnumerable<Department> GetDepartments(bool includeMembers, bool includePosts)
        {
            throw new NotImplementedException();
        }

        public void SaveDpmt()
        {
            throw new NotImplementedException();
        }
    }
}
