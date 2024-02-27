using Bit.Core.Enums;
using Bit.Core.Models.Data;

namespace Bit.Core.Utilities
{
    public static class RegionExtensions
    {
        public static EnvironmentUrlData GetUrls(this Region region)
        {
            switch (region)
            {
                
                case Region.vBoxx:
                    return EnvironmentUrlData.DefaultvBoxx;
                default:
                    return null;
            }
        }

        public static string BaseUrl(this Region region)
        {
            switch (region)
            {
              
                case Region.vBoxx:
                    return EnvironmentUrlData.DefaultvBoxx.Base;
                default:
                    return null;
            }
        }

        public static string Domain(this Region region)
        {
            switch (region)
            {
               
                case Region.vBoxx:
                    return EnvironmentUrlData.DefaultvBoxx.Domain;
                default:
                    return null;
            }
        }

    }
}

