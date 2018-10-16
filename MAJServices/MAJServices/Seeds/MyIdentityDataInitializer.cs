using MAJServices.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Seeds
{
    [Route("api/seed")]
    public class MyIdentityDataInitializer : Controller
    {

        private readonly UserManager<UserIdentity> _userManager;
        public MyIdentityDataInitializer(UserManager<UserIdentity> userManager){
            _userManager = userManager;
        }

        [HttpGet("roles")]
        public async Task<IActionResult> SeedUsers(UserManager<UserIdentity> userManager)
        {
            List<UserIdentity> users = new List<UserIdentity>(){
                new UserIdentity
                {
                    Id = "2014630132",
                    UserName = "2014630132",
                    Name = "Arturo",
                    LastName = "Escutia López",
                    DepartmentAcronym = "CATT",
                },
                 new UserIdentity
                 {
                     Id = "2014378223",
                     UserName = "2014378223",
                     Name = "Javier",
                     LastName = "Cruz Santiago",
                     DepartmentAcronym = "CELEX"
                 },
                 new UserIdentity
                 {
                     Id = "2014631903",
                     UserName = "2014631903",
                     Name = "Miguel",
                     LastName = "Medina Zarazúa",
                     DepartmentAcronym = "UPIS"
                 },
                 new UserIdentity
                 {
                     Id = "2014193056",
                     UserName = "2014193056",
                     Name = "Axel",
                     LastName = "Servantes Vargas",
                     DepartmentAcronym = "GE"
                }};

            foreach(UserIdentity user in users){
                var isInRole = await _userManager.GetRolesAsync(user);
                if(isInRole == null){
                    await _userManager.AddToRoleAsync(user, "Admin");
                    var hasPassword = await _userManager.HasPasswordAsync(user);
                    if(!hasPassword){
                        await _userManager.AddPasswordAsync(user, "Rgibanez+370dxz");
                    }
                }
            }
            return NoContent();
        }


    }
}
