namespace Logistically.WebApi.Data.Models;

public record CreatePackageRequest(int Weight, int Length, int Height, int Width);
