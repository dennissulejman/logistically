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

    [TestMethod]
    public void GetPackageById_FromInvalidParcelId_ReturnsBadRequestResult()
    {
        IActionResult result = _packageController.GetPackageById("1a");

        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }

    [TestMethod]
    public void GetPackageById_ValidParcelId_ReturnsOkObjectResult()
    {
        IActionResult result = _packageController.GetPackageById("999000000000000000");

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public void CreatePackage_FromValidCreatePackageRequest_ReturnsCreatedAtRouteResult()
    {
        IActionResult result = _packageController.CreatePackage(
            new(
                1,
                1,
                1,
                1
            )
        );

        Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult));
    }

    [TestMethod]
    public void CreatePackage_FromInvalidCreatePackageRequest_ReturnsBadRequstObjectResult()
    {
        IActionResult result = _packageController.CreatePackage(
            new(
                30000,
                1,
                1,
                1
            )
        );

        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }
}