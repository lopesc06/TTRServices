using AutoMapper;
using Cityinfo.API.Entities;
using Cityinfo.API.Models;
using Cityinfo.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cityinfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        //method injection
        private ICityInfoRepository _cityInfoRepository;
        public PointsOfInterestController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        //Gets all Points of interest from a city
        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            var pointsOfInterestForCity = _cityInfoRepository.GetPointsOfInterestForCity(cityId);
            var pointsOfInterestresults = Mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity);
            return Ok(pointsOfInterestresults);
        }

        //Gets a specific point of interest from a city
        [HttpGet("{cityId}/pointsofinterest/{pointId}", Name = "GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int pointId)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            var pointOfInterestForCity = _cityInfoRepository.GetPointOfInterestForCity(cityId, pointId);
            if (pointOfInterestForCity == null)
            {
                return NotFound();
            }
            var pointOfInterestResult = Mapper.Map<PointOfInterestDto>(pointOfInterestForCity);
            return Ok(pointOfInterestResult);
        }

        //Creates a new point of interest in a city
        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) //Input Validation
            {
                return BadRequest(ModelState); //Return Bad request with the corresponding messages
            }
            
            if(!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var finalPointOfInterest = Mapper.Map<PointOfInterest>(pointOfInterest);
            _cityInfoRepository.AddPointOfInterestForCity(cityId, finalPointOfInterest);
            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            var createdPointOfInterest = Mapper.Map<PointOfInterestDto>(finalPointOfInterest);
            return CreatedAtRoute("GetPointOfInterest", new
            { cityId = cityId, pointId = createdPointOfInterest.Id }, createdPointOfInterest);
        }

        //It makes a full update of the city 
        [HttpPut("{cityId}/pointsofinterest/{pointId}")]
        public IActionResult UpdatePointOfInterest(int cityId, int pointId, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid) //Input Validation
            {
                return BadRequest(ModelState); //Return Bad request with the corresponding messages
            }

            if (!_cityInfoRepository.CityExists(cityId) )
            {
                return NotFound();
            }

            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterestForCity(cityId, pointId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(pointOfInterest, pointOfInterestEntity);
            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }
            return NoContent();
        }

        //Partial Update from a  point of interest
        [HttpPatch("{cityId}/pointsofinterest/{pointId}")]
        public  IActionResult PartialUpdatePointOfInterest (int cityId, int pointId, [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto> patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest();
            }
            
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }

            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterestForCity(cityId, pointId);
            if(pointOfInterestEntity == null)
            {
                return NotFound();
            }

            var pointOfInterestToPatch = Mapper.Map<PointOfInterestForUpdateDto>(pointOfInterestEntity);
            patchDoc.ApplyTo(pointOfInterestToPatch,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(pointOfInterestToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);
            if (!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }

        //Delete a Point Of interest from a city
        [HttpDelete("{cityId}/pointsofinterest/{pointId}")]
        public IActionResult DeletePointOfInterest (int cityId, int pointId)
        {
            if (!_cityInfoRepository.CityExists(cityId))
            {
                return NotFound();
            }
            var pointOfInterestEntity = _cityInfoRepository.GetPointOfInterestForCity(cityId, pointId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);
            if(!_cityInfoRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }
    }
}
