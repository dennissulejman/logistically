using Logistically.WebApi.Controllers;
using Logistically.WebApi.Data.Contexts;
using Logistically.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Logistically.Tests.Controllers;

[TestClass]
public class PackageControllerTests
{
    private readonly PackageController _packageController;
    public PackageControllerTests()
    {
        PackageDbContext packageDbContext = new();
        PackageService packageService = new(packageDbContext);
        _packageController = new PackageController(packageService);
    }

    [TestMethod]
    public void GetAllPackages_ReturnsOkObjectResult()
    {
        IActionResult result = _packageController.GetAllPackages();

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

}