using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreatLens.Api.Modules;

namespace ThreatLens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScansController : ControllerBase
    {
        private static int idCounter = 0;
        static private List<ScanRequest> scans = new List<ScanRequest>
        {
            new ScanRequest
            {
                Target = "example.com"
            }
        };
        [HttpGet]
        public ActionResult<List<ScanRequest>> GetScans()
        {
            return Ok(scans);
        }

        [HttpGet("{id}")]
        public ActionResult<List<ScanRequest>> GetScanById(int id)
        {
            var scan = scans.FirstOrDefault(x => x.Id == id);
            if (scan == null)
                return NotFound();

            return Ok(scan);
        }

        [HttpPost]
        public ActionResult<ScanRequest> addScan(ScanRequest scan)
        {
            if (string.IsNullOrWhiteSpace(scan.Target))
                return BadRequest();


            scan.Id = ++idCounter;
            scans.Add(scan);
            

            return Ok(scan);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteScan(int id)
        {
            var scan = scans.FirstOrDefault(x => x.Id == id);
            if (scan == null)
                return NotFound();

            scans.Remove(scan);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateScan(int id, [FromBody]ScanRequest updateScan)
        {
            var scan = scans.FirstOrDefault(x => x.Id == id);
            if (scan == null)
                return NotFound();

            if (string.IsNullOrWhiteSpace(updateScan.Target))
                return BadRequest();


            scan.Target = updateScan.Target;

            return NoContent();
        }
    }
}
