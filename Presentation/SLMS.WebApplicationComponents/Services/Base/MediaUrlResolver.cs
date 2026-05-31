using Microsoft.Extensions.Configuration;
using SLMS.WebApplicationComponents.Services.Base.Interfaces;

namespace SLMS.WebApplicationComponents.Services.Base
{
    public class MediaUrlResolver:IMediaUrlResolver
    {
        private readonly IConfiguration _config;
        public MediaUrlResolver(IConfiguration config) => _config = config;

        public string Resolve(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return "";

            if (Uri.TryCreate(path, UriKind.Absolute, out _)) return path;

            var baseUrl = _config["Media:PublicBaseUrl"] ?? _config["Api:BaseUrl"]
                          ?? throw new InvalidOperationException("Media/PublicBaseUrl is not configured.");

            return $"{baseUrl.TrimEnd('/')}/{path.TrimStart('/')}";
        }
    }
}
