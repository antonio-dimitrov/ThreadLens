using Microsoft.EntityFrameworkCore;
using ThreatLens.Api.Data;
using ThreatLens.Api.Models;

namespace ThreatLens.Api.Services
{
    public class ScanService
    {
        private readonly ThreatLensContext _context;

        public ScanService(ThreatLensContext context)
        {
            _context = context;
        }


        public async Task<List<ScanRequest>> GetAllScansAsync()
        {
            return await _context.ScanRequests.ToListAsync();
        }


        public async Task<ScanRequest?> GetScanByIdAsync(int id)
        {
            return await _context.ScanRequests
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ScanRequest?> CreateScanAsync(
           string? target)
        {
            if (!TargetValidator.IsValidTarget(target))
                return null;

            var scan = new ScanRequest
            {
                Target = target!.Trim()
            };

            _context.ScanRequests.Add(scan);

            await _context.SaveChangesAsync();

            return scan;
        }

        public async Task<bool> DeleteScanAsync(int id)
        {
            var scan = await _context.ScanRequests.FindAsync(id);

            if (scan == null)
            {
                return false;
            }

            _context.ScanRequests.Remove(scan);
            await _context.SaveChangesAsync();

            return true;
        }

        
    }
}
