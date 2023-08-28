namespace Logistically.WebApi.Data.Models;

public record Package(
    string ParcelId,
    int WeightInGrams,
    int LengthInCentimeters,
    int HeightInCentimeters,
    int WidthInCentimeters
)
{
    public bool IsValid =>
        WeightInGrams <= Constants.MaximumPackageWeightInGrams
        && LengthInCentimeters <= Constants.MaximumPackageLengthInCentimeters
        && HeightInCentimeters <= Constants.MaximumPackageHeightInCentimeters
        && WidthInCentimeters <= Constants.MaximumPackageWidthInCentimeters;
}
