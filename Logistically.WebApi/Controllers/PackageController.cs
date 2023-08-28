using Logistically.WebApi.Data.Models;
using Logistically.WebApi.Services;
using Logistically.WebApi.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Logistically.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController : ControllerBase
{
    private readonly PackageService _packageService;

    public PackageController(PackageService packageService)
    {
        _packageService = packageService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Package>), StatusCodes.Status200OK)]
    public IActionResult GetAllPackages()
    {
        return Ok(_packageService.GetAllPackages());
    }

    [HttpGet]
    [Route("{parcelId}")]
    [ProducesResponseType(typeof(Package), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    public IActionResult GetPackageById([FromRoute] string parcelId)
    {
        // Validate parcelId before calling the database to ensure no unnecessary calls are being made
        if (PackageValidator.TryValidateParcelId(parcelId, out string validationErrorMessage) == false)
        {
            return BadRequest(validationErrorMessage);
        }

        Package? packageResult = _packageService.GetPackageById(parcelId);

        return packageResult is null
            ? Ok("No package matches the requested package ID")
            : Ok(packageResult);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Package), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Package), StatusCodes.Status400BadRequest)]
    public IActionResult CreatePackage([FromBody] CreatePackageRequest createPackageRequest)
    {
        Package? newPackage = _packageService.CreatePackage(createPackageRequest);

        if (newPackage?.IsValid == true)
        {
            return CreatedAtRoute(nameof(Package), newPackage);
        }
        else
        {
            return BadRequest(newPackage);
        }
    }
}
