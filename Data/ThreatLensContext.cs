using Microsoft.EntityFrameworkCore;
using ThreatLens.Api.Models;

namespace ThreatLens.Api.Data
{
    public class ThreatLensContext : DbContext
    {
        public ThreatLensContext(DbContextOptions<ThreatLensContext> options): base(options) { }

        public DbSet<ScanRequest> ScanRequests { get; set; }

       
    }
}
