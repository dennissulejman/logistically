using Logistically.WebApi.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Logistically.Tests.Data.Models;

[TestClass]
public class PackageTests
{
    [TestMethod]
    public void ValidPackage_HasIsValidEqualsTrue()
    {
        Package validPackage = new("", 1, 1, 1, 1);

        Assert.IsTrue(validPackage.IsValid);
    }

    [TestMethod]
    public void InvalidPackage_HasIsValidEqualsFalse()
    {
        Package validPackage = new("", 30000, 1, 1, 1);

        Assert.IsFalse(validPackage.IsValid);
    }
}
