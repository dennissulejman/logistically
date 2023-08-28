namespace Logistically.WebApi.Validation;

public static class PackageValidator
{
    public static bool TryValidateParcelId(string parcelId, out string validationErrorMessage)
    {
        List<string> validationErrorMessages = new();

        if (parcelId.Length != Constants.ParcelIdLength)
        {
            validationErrorMessages.Add(Constants.ValidationErrorMessageWrongParcelIdLength);
        }
        if (parcelId.Any(x => char.IsNumber(x) == false))
        {
            validationErrorMessages.Add(Constants.ValidationErrorMessageOnlyNumbersAllowed);
        }
        if (parcelId.StartsWith(Constants.ParcelIdStartingNumbers) == false)
        {
            validationErrorMessages.Add(Constants.ValidationErrorMessageWrongStartingNumbers);
        }

        validationErrorMessage = string.Join(Environment.NewLine, validationErrorMessages);
        return validationErrorMessages.Any() == false;
    }
}
