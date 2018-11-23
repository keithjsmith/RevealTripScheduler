using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.DomainRepositories;
using DAL.RepositoryClasses;
using DomainModels.DAL;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RevealTripScheduler.Controllers
{
    [Produces("application/json")]
    [Route("travelapi/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        //Could certainly just use DI here instead
        private ITripRepository _trips;
        private readonly ILogger<TripsController> _log;

        public TripsController(ILogger<TripsController> log)
        {
            _trips = new TripRepository();
            _log = log;
        }


        // GET api/trips
        // Used JsonResult here just to show it can be done.  Trickier to manage the http status codes though
        // These are both 200, which made it easy.

        /// <summary>
        /// Gets a list of all uncanceled trips
        /// </summary>
        /// <returns>All uncanceled trips</returns>
        [HttpGet]
        public JsonResult Get()
        {
            if (_trips.All.Count() > 0 && _trips.All.Where(s => s.TripStatusId != 2).Count() > 0)
            {
                return new JsonResult(_trips.All.Where(s => s.TripStatusId != 2));
            }
            else
            {
                _log.LogWarning("No active results found");
                return new JsonResult(new { message = "No active results" });
            }
        }

        // GET api/trips/3

        /// <summary>
        /// Returns a single trip object based on Id
        /// </summary>
        /// <param name="id">id of the trip to be found</param>
        /// <returns>Single Trip Object based on Id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tripById = _trips.All.FirstOrDefault(s => s.Id == id && s.TripStatusId != 2);
            if (tripById != null)
            {
                return Ok(tripById);
            }
            else
            {
                _log.LogWarning("No active result found");
                return Ok(new { message = "No active result" });
            }
        }

        // POST api/trips

        /// <summary>
        /// Adds a trip object with a tripstatus of active
        /// </summary>
        /// <remarks>
        /// Sample:
        /// {
        /// "id": 3,
        /// "riderId": 5,
        /// "pickupLocationId": 2,
        /// "pickupDateTime": "2018-11-14T17:57:21.6457065-06:00",
        /// "dropOffLocationId": 1,
        /// "tripStatusId": 4
        /// }
        /// </remarks>
        [HttpPost]
        public IActionResult Post([FromBody] Trip tripValues)
        {
            try
            {
                _trips.Add(tripValues);
                return Ok(new { message = "Creation of Trip successful", tripValues });
            }
            catch (Exception)
            {
                //would certainly want to beef this up so that it would more useful for debugging
                _log.LogError("Invalid trip information", tripValues);
                return BadRequest(new { message = "Invalid trip information", tripValues });//400 status code
            }
        }

        // DELETE api/trips/5

        /// <summary>
        /// Updates tripstatus of a trip object to canceled
        /// </summary>
        /// <param name="id"></param>
        [HttpPost("{id}")]
        public IActionResult Cancel(int id)
        {
            try
            {
                _trips.Cancel(id);
                return Ok(new { message = "Cancelation of Trip successful", id });
            }
            catch (Exception)
            {
                _log.LogError("Invalid cancelation Id, {Id}", id);
                return BadRequest(new { message = "Invalid cancelation Id", id });//400 status code
            }
        }
    }
}
