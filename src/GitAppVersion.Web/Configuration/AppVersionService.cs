using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GitAppVersion.Web.Configuration
{
    public class AppVersionService : IAppVersionService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public AppVersionService(IHostingEnvironment hostingEnvironment, ILogger<AppVersionService> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        private AppVersion _appVersion;
        public AppVersion AppVersion
        {
            get
            {
                if (_appVersion != null)
                {
                    return _appVersion;
                }

                var path = Path.Combine(_hostingEnvironment.WebRootPath, "version.json");

                _logger.LogInformation(path);

                if (path == null || !File.Exists(path))
                {
                    _appVersion = new AppVersion();
                }
                else
                {
                    using (var sr = File.OpenText(path))
                    {
                        _appVersion = JsonConvert.DeserializeObject<AppVersion>(sr.ReadToEnd());
                    }
                }

                return _appVersion;
            }
        }
    }
}