using System;
using Logistically.WebApi;
using Logistically.WebApi.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logistically.Tests.Validation;

[TestClass]
public class PackageValidatorTests
{
    [TestMethod]
    public void ParcelId_WithWrongLength_ReturnsWrongParcelIdLengthMessage()
    {
        bool result = PackageValidator.TryValidateParcelId("9990", out string validationErrorMessage);

        Assert.IsFalse(result);
        Assert.IsTrue(validationErrorMessage.Contains(Constants.ValidationErrorMessageWrongParcelIdLength));
    }

    [TestMethod]
    public void ParcelId_WithLetters_ReturnsOnlyNumbersAllowedMessage()
    {
        bool result = PackageValidator.TryValidateParcelId("a", out string validationErrorMessage);

        Assert.IsFalse(result);
        Assert.IsTrue(validationErrorMessage.Contains(Constants.ValidationErrorMessageOnlyNumbersAllowed));
    }

    [TestMethod]
    public void ParcelId_WithWrongStartingNumbers_ReturnsWrongStartingNumbersMessage()
    {
        bool result = PackageValidator.TryValidateParcelId("1", out string validationErrorMessage);

        Assert.IsFalse(result);
        Assert.IsTrue(validationErrorMessage.Contains(Constants.ValidationErrorMessageWrongStartingNumbers));
    }

    [TestMethod]
    public void ValidParcelId_ReturnsEmptyValidationErrorMessage()
    {
        bool result = PackageValidator.TryValidateParcelId(Constants.BaseParcelId, out string validationErrorMessage);

        Assert.IsTrue(result);
        Assert.IsTrue(string.IsNullOrWhiteSpace(validationErrorMessage));
    }
}
