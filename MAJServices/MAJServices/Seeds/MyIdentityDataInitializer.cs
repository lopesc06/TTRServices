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
        public async Task<IActionResult> SeedUsers()
        {
            List<string> idUsers = new List<string>() { "2014630132", "2014378223","2014631903","2014193056" };
                
            foreach(string idUser in idUsers){
                var user = await _userManager.FindByIdAsync(idUser);
                var isInRole = await _userManager.GetRolesAsync(user);
                if(isInRole.Count == 0){
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
