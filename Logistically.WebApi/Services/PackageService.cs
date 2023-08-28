using Logistically.WebApi.Data.Contexts;
using Logistically.WebApi.Data.Models;
using Logistically.WebApi.Helpers;

namespace Logistically.WebApi.Services;

public class PackageService
{
    private readonly PackageDbContext _packageDbContext;

    public PackageService(PackageDbContext packageDbContext)
    {
        _packageDbContext = packageDbContext;

        if (_packageDbContext.Packages.Any() == false)
        {
            _packageDbContext.Packages.Add(
                new(
                    PackageHelpers.GetNewParcelId(_packageDbContext),
                    1000,
                    30,
                    30,
                    30
                )
            );

            _packageDbContext.SaveChanges();

            _packageDbContext.Packages.Add(
                new(
                    PackageHelpers.GetNewParcelId(_packageDbContext),
                    1500,
                    40,
                    30,
                    30
                )
            );

            _packageDbContext.SaveChanges();
        }
    }

    public IEnumerable<Package> GetAllPackages()
    {
        return _packageDbContext.Packages.ToList();
    }

    public Package? GetPackageById(string parcelId)
    {
        return _packageDbContext.Packages.Find(parcelId);
    }

}
