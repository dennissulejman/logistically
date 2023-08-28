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
}
