using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using waypoint_generator.Models.CalibrationPlan;
using waypoint_generator.Models.ScanPlan;

namespace asset_management.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]

    public class CalibrationPlanController : ControllerBase
    {
        private ICalibrationPlanService _calibrationPlanService;

        public CalibrationPlanController(ICalibrationPlanService calibrationPlanService)
        {
            _calibrationPlanService = calibrationPlanService;

        }

        // GET: api/<AntennaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_calibrationPlanService.GetAll()); ;
        }

        // GET api/<AntennaController>/5
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(_calibrationPlanService.GetById(id));
        }

        [HttpGet("mission/{id}")]
        public IActionResult GetByMissionID(int id)
        {
            return Ok(_calibrationPlanService.GetAllByMissionId(id));
        }

        // POST api/<AntennaController>
        [HttpPost]
        public IActionResult Post([FromBody] CalibrationPlanCreateRequest model)
        {
            var drone = _calibrationPlanService.Create(model);

            return Ok(drone);
        }

        // PUT api/<AntennaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CalibrationPlanUpdateRequest model)
        {
            var drone = _calibrationPlanService.Update(id, model);
            return Ok(drone);
        }

        // DELETE api/<AntennaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _calibrationPlanService.Delete(id);
            return Ok(new { message = $"Calibration Plan {id} deleted" });
        }
    }
}