using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace GitAppVersion.Web.Configuration
{
    public class AppVersionService : IAppVersionService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public AppVersionService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
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