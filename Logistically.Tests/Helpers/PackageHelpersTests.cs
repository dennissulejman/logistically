using System.Globalization;
using System.Linq;
using Logistically.WebApi;
using Logistically.WebApi.Data.Contexts;
using Logistically.WebApi.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logistically.Tests.Helpers;

[TestClass]
public class PackageHelpersTests
{
    private readonly PackageDbContext _packageDbContext;

    public PackageHelpersTests()
    {
        _packageDbContext = new();

        if (_packageDbContext.Packages.Any() == false)
        {
            _packageDbContext.Packages.Add(
                new(Constants.BaseParcelId, 1, 1, 1, 1)
            );

            _packageDbContext.SaveChanges();
        }
    }

    [TestMethod]
    public void NewParcelId_IsOneIncrementOfHighestParcelId()
    {
        string highestParcelId = _packageDbContext.Packages
            .OrderByDescending(x =>
                long.Parse(x.ParcelId)
            )
            .First()
            .ParcelId;

        string expected = (long.Parse(highestParcelId, CultureInfo.InvariantCulture) + 1).ToString();
        string actual = PackageHelpers.GetNewParcelId(_packageDbContext);

        Assert.AreEqual(expected, actual);
    }
}
