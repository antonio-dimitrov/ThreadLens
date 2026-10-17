
using Microsoft.AspNetCore.Mvc;
using ThreatLens.Api.Models;
using ThreatLens.Api.Services;

namespace ThreatLens.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScansController : ControllerBase
    {


        private readonly ScanService _scanService;

        public ScansController(ScanService scanService)
        {
            _scanService = scanService;
        }
        //private static int idCounter = 0;
        //static private List<ScanRequest> scans = new List<ScanRequest>
        //{
        //    new ScanRequest
        //    {
        //        Target = "example.com"
        //    }
        //};
        [HttpGet]
        public async  Task<ActionResult<List<ScanRequest>>> GetScans()
        {
            var scans = await _scanService.GetAllScansAsync();
            return Ok(scans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScanRequest>> GetScanById(int id)
        {
            var scan = await _scanService.GetScanByIdAsync(id);

            if (scan == null)
            {
                return NotFound();
            }

            return Ok(scan);
        }

        [HttpPost]
        public async Task<ActionResult<ScanRequest>> AddScan(ScanRequest request)
        {
            var scan = await _scanService.CreateScanAsync(request.Target);

            if (scan == null)
                return BadRequest("Invalid IP address or domain.");

            return Ok(scan);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScan(int id)
        {
            var deleted = await _scanService.DeleteScanAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateScan(int id, [FromBody]ScanRequest updateScan)
        //{
        //    var scan = scans.FirstOrDefault(x => x.Id == id);
        //    if (scan == null)
        //        return NotFound();

        //    if (string.IsNullOrWhiteSpace(updateScan.Target))
        //        return BadRequest();


        //    scan.Target = updateScan.Target;

        //    return NoContent();
        //}
    }
}
