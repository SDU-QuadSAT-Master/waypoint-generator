using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using waypoint_generator.Models.ScanPlan;

namespace asset_management.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ScanPlanController : ControllerBase
    {
        private IScanPlanService _scanPlanService;

        public ScanPlanController(IScanPlanService scanPlanService)
        {
            _scanPlanService = scanPlanService;

        }

        // GET: api/<AntennaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_scanPlanService.GetAll()); ;
        }

        // GET api/<AntennaController>/5
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(_scanPlanService.GetById(id));
        }

        [HttpGet("mission/{id}")]
        public IActionResult GetByMissionID(int id)
        {
            return Ok(_scanPlanService.GetAllByMissionId(id));
        }

        // POST api/<AntennaController>
        [HttpPost]
        public IActionResult Post([FromBody] ScanPlanCreateRequest model)
        {
            var drone = _scanPlanService.Create(model);

            return Ok(drone);
        }

        // PUT api/<AntennaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ScanPlanUpdateRequest model)
        {
            var drone = _scanPlanService.Update(id, model);
            return Ok(drone);
        }

        // DELETE api/<AntennaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _scanPlanService.Delete(id);
            return Ok(new { message = $"Scan Plan {id} deleted" });
        }
    }
}