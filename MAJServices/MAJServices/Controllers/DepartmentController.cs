
using MAJServices.Models;
using MAJServices.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class DepartmentController : Controller
    {
        //private IDepartmentInfoRepository _dpmtInfoRepository;
        //private IUserInfoRepository _userInfoRepository;
        //private DepartmentController(IDepartmentInfoRepository departmentInfoRepository , IUserInfoRepository userInfoRepository)
        //{
        //    _dpmtInfoRepository = departmentInfoRepository;
        //    _userInfoRepository = userInfoRepository;
        //}

        //[HttpPost("department/{acronym}")]
        //public ActionResult AddUserToDepartment(string idDepartment , [FromBody]UserForUpdateDto userForUpdateDto)
        //{
        //    if (!_dpmtInfoRepository.DepartmentExists(idDepartment)){
        //        return NotFound();
        //    }
        //    if (!ModelState.IsValid || userForUpdateDto == null)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var add
        //}
    }
}
