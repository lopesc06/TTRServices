using MAJServices.Entities;
using MAJServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Seeds
{
    [Route("api")]
    public class MyIdentityDataInitializer: Controller
    {
        private readonly UserManager<UserIdentity> _userManager;
        private readonly RoleManager<RoleIdentity> _roleManager;
        private IDepartmentInfoRepository _departmentInfoRepository;

        public MyIdentityDataInitializer(UserManager<UserIdentity> userManager, RoleManager<RoleIdentity> roleManager
            , IDepartmentInfoRepository departmentInfoRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _departmentInfoRepository = departmentInfoRepository;
        }
        
        [HttpGet("Seed")]
        public async Task Seeding()
        {
            List<string> rolesList = new List<string>(new string[] { "SuperAdmin", "Admin", "Subadmin", "General" });
            foreach (string r in rolesList)
            {
                bool x = await _roleManager.RoleExistsAsync(r);
                if (!x)
                {
                    var result = await _roleManager.CreateAsync(new RoleIdentity { Name = r });
                }
            }
            //Seeding users and their roles in the same thread 
            List<UserIdentity> users = new List<UserIdentity>(new UserIdentity[] {
                new UserIdentity
                {
                    Id = "2014630132",
                    UserName = "2014630132",
                    Name = "Arturo",
                    LastName = "Escutia López"
                },
                 new UserIdentity
                {
                    Id = "2014378223",
                    UserName = "2014378223",
                    Name = "Javier",
                    LastName = "Cruz Santiago"
                },
                 new UserIdentity
                {
                    Id = "2014631903",
                    UserName = "2014631903",
                    Name = "Miguel",
                    LastName = "Medina Zarazúa"
                },
                 new UserIdentity
                {
                    Id = "2014193056",
                    UserName = "2014193056",
                    Name = "Axel",
                    LastName = "Servantes Vargas"
                }
            });

            foreach (UserIdentity user in users)
            {
                UserIdentity x = await _userManager.FindByIdAsync(user.Id);
                if (x == null)
                {
                    var result = await _userManager.CreateAsync(user, "Rgibanez+370dxz");
                    if (result.Succeeded)
                    {
                        var res = await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }

        [HttpGet("seeddepartments")]
        public IActionResult seedDpt(){
            List<Department> Departments = new List<Department>(new Department[]
            {
                new Department{
                    Name = "Centro de Lenguajes Extranjeras",
                    Acronym = "CELEX"
                },
                 new Department{
                    Name = "Comisión Académica de Trabajos Terminales",
                    Acronym = "CATT"
                },
                 new Department{
                    Name = "Gestión Escolar",
                    Acronym = "GE"
                },
                 new Department{
                    Name = "Unidad Politécnica de Integración Social",
                    Acronym = "UPIS"
                },
                 new Department{
                    Name = "Departamento de Extensión y Apoyos Educativos",
                    Acronym = "DEAE"
                }
            });
            foreach(Department department in Departments)
            {
                _departmentInfoRepository.AddDepartment(department);
            }
            _departmentInfoRepository.SaveDpmt();
            return NoContent();
        }

    }
}
