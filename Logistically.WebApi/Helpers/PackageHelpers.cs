using System.Globalization;
using Logistically.WebApi.Data.Contexts;

namespace Logistically.WebApi.Helpers;

public static class PackageHelpers
{
    public static string GetNewParcelId(PackageDbContext packageDbContext)
    {
        string newParcelId = Constants.BaseParcelId;

        while (packageDbContext.Packages.Any(x => x.ParcelId == newParcelId))
        {
            newParcelId = (long.Parse(newParcelId, CultureInfo.InvariantCulture) + 1).ToString();
        }

        return newParcelId;
    }
}
