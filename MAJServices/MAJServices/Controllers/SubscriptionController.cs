﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MAJServices.Entities;
using MAJServices.Models.User;
using MAJServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace MAJServices.Controllers
{
    [Route("api/users")]
    public class SubscriptionController : Controller
    {
        private IUserInfoRepository _userInfoRepository;

        public SubscriptionController(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        [HttpPost("{iduser}/subscriptions")]
        public IActionResult AddUserSubscriptions(string iduser, [FromBody]IEnumerable<UserSubscriptionDto> subscriptionsDto)
        {
            if(!_userInfoRepository.UserExists(iduser))
            {
                return NotFound();
            }
            if(subscriptionsDto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var suscriptionsEntity = Mapper.Map<IEnumerable<UserSubscription>>(subscriptionsDto);
            foreach(UserSubscription suscription in suscriptionsEntity)
            {
                _userInfoRepository.AddUserSubscription(suscription);
            }
            if (!_userInfoRepository.SaveUser())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

        [HttpGet("{iduser}/subscriptions")]
        public IActionResult GetUserSubscriptions(string iduser)
        {
            if (!_userInfoRepository.UserExists(iduser))
            {
                return NotFound();
            }
            var subscriptionsEntity = _userInfoRepository.GetUserSubscription(iduser);
            var subscriptionsDto = Mapper.Map<IEnumerable<UserSubscriptionDto>>(subscriptionsEntity);
            return Ok(subscriptionsDto);
        }

        [HttpDelete("{iduser}/subscriptions")]
        public IActionResult DeleteUserSubscriptions(string iduser, [FromBody]IEnumerable<UserSubscriptionDto> subscriptionsDto)
        {
            if (!_userInfoRepository.UserExists(iduser))
            {
                return NotFound();
            }
            if (subscriptionsDto == null)
            {
                return BadRequest();
            }

            var suscriptionsEntity = Mapper.Map<IEnumerable<UserSubscription>>(subscriptionsDto);
            foreach (UserSubscription suscription in suscriptionsEntity)
            {
                _userInfoRepository.DeleteUserSubscription(suscription);
            }
            if (!_userInfoRepository.SaveUser())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

    }
}