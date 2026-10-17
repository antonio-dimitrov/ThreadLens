namespace ThreatLens.Api.Models
{
    public class ScanRequest
    {
        public int Id { get; set; }
        public string Target { get; set; } = string.Empty;
    }
}
