using System.Collections.Generic;
using System.Linq;
using Logistically.WebApi;
using Logistically.WebApi.Data.Contexts;
using Logistically.WebApi.Data.Models;
using Logistically.WebApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logistically.Tests.Services;

[TestClass]
public class PackageServiceTests
{
    private readonly PackageService _packageService;

    public PackageServiceTests()
    {
        PackageDbContext packageDbContext = new();
        _packageService = new(packageDbContext);
    }

    [TestMethod]
    public void GetAllPackages_ReturnsAtLeastOneResult()
    {
        IEnumerable<Package> result = _packageService.GetAllPackages();

        Assert.IsTrue(result.Any());
    }

    [TestMethod]
    public void GetPackageById_FromExistingId_ReturnsPackage()
    {
        Package? result = _packageService.GetPackageById(Constants.BaseParcelId);

        Assert.IsInstanceOfType(result, typeof(Package));
    }

    [TestMethod]
    public void GetPackageById_FromNonExistingId_ReturnsNull()
    {
        Package? result = _packageService.GetPackageById("1a");

        Assert.IsNull(result);
    }

    [TestMethod]
    public void CreatePackage_ReturnsPackage()
    {
        Package? result = _packageService.CreatePackage(new(1, 1, 1, 1));

        Assert.IsInstanceOfType(result, typeof(Package));
    }
}
