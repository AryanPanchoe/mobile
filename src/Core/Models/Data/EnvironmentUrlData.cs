using System.Text.RegularExpressions;
using Bit.Core.Enums;
using Bit.Core.Utilities;

namespace Bit.Core.Models.Data
{
    public class EnvironmentUrlData
    {
 

        public static EnvironmentUrlData DefaultvBoxx = new EnvironmentUrlData
        {
            Base = "https://vault.vboxx.nl",
            Api = "https://vault.vboxx.nl",
            Identity = "https://vault.vboxx.nl",
            Icons = "https://vault.vboxx.nl",
            WebVault = "https://vault.vboxx.nl",
            Notifications = "https://vault.vboxx.nl",
            Events = "https://vault.vboxx.nl",
            Domain = "vboxx.nl"
        };

        public string Base { get; set; }
        public string Api { get; set; }
        public string Identity { get; set; }
        public string Icons { get; set; }
        public string Notifications { get; set; }
        public string WebVault { get; set; }
        public string Events { get; set; }
        public string Domain { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(Base)
                && string.IsNullOrEmpty(Api)
                && string.IsNullOrEmpty(Identity)
                && string.IsNullOrEmpty(Icons)
                && string.IsNullOrEmpty(Notifications)
                && string.IsNullOrEmpty(WebVault)
                && string.IsNullOrEmpty(Events);

        public Region Region
        {
            get
            {
                return Region.vBoxx;

            }
        }
        

        public EnvironmentUrlData FormatUrls()
        {
            return new EnvironmentUrlData
            {
                Base = FormatUrl(Base),
                Api = FormatUrl(Api),
                Identity = FormatUrl(Identity),
                Icons = FormatUrl(Icons),
                Notifications = FormatUrl(Notifications),
                WebVault = FormatUrl(WebVault),
                Events = FormatUrl(Events)
            };
        }

        private string FormatUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }
            url = Regex.Replace(url, "\\/+$", string.Empty);
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = string.Concat("https://", url);
            }
            return url.Trim();
        }

        public string GetDomainOrHostname()
        {
            var url = WebVault ?? Base ?? Api ?? Identity;
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }
            if (url.Contains(Region.vBoxx.Domain()))
            {
                return CoreHelpers.GetDomain(url);
            }
            return CoreHelpers.GetHostname(url);
        }
    }
}
