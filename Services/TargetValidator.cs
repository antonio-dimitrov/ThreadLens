using System.Net;
using System.Text.RegularExpressions;

namespace ThreatLens.Api.Services
{
    public class TargetValidator
    {
        public static bool IsValidTarget(string? target) //<-input can be null
        {
            if (string.IsNullOrWhiteSpace(target))
                return false;

            target = target.Trim();

            return IsValidIpAddress(target)
                || IsValidDomain(target);
        }


        private static bool IsValidIpAddress(string target)
        {
            return IPAddress.TryParse(target, out _);
        }

        // add internationalized dns validation
        // this is simple validation
        private static bool IsValidDomain(string target)
        {
            if (target.Length > 253)
                return false;

            const string domainPattern =
                @"^(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,63}$";

            return Regex.IsMatch(target, domainPattern);
        }
    }
}

