namespace Logistically.WebApi;

public static class Constants
{
    public static readonly int MaximumPackageWeightInGrams = 20000;
    public static readonly int MaximumPackageLengthInCentimeters = 60;
    public static readonly int MaximumPackageHeightInCentimeters = 60;
    public static readonly int MaximumPackageWidthInCentimeters = 60;

    public static readonly string BaseParcelId = "999000000000000000";
    public static readonly string PackageDb = "PackageDb";
    public static readonly int ParcelIdLength = 18;
    public static readonly string ParcelIdStartingNumbers = "999";

    public static readonly string ValidationErrorMessageWrongParcelIdLength = $"Parcel ID character length has to be {ParcelIdLength}";
    public static readonly string ValidationErrorMessageOnlyNumbersAllowed = "Parcel ID can only contain numbers";
    public static readonly string ValidationErrorMessageWrongStartingNumbers = $"Parcel ID character has start with {ParcelIdStartingNumbers}";
}
