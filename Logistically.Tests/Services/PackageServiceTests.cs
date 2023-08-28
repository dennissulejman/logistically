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
}
