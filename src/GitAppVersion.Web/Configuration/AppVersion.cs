using System;

namespace GitAppVersion.Web.Configuration
{
    public class AppVersion
    {
        public string ShortHash { get; set; } = "000000";
        public DateTime DeploymentUtc { get; set; } = DateTime.UtcNow;
    }
}
