namespace Wader.Icons.Phosphor;

public enum PhosphorIconWeight
{
    Thin = 0,
    Light = 1,
    Regular = 2,
    Bold = 3,
    Fill = 4,
    DuoTone = 5,
}

public static class PhosphorIconWeightExtensions
{
    public static string ToSpriteFileName(this PhosphorIconWeight weight)
    {
        const string baseName = "icons";
        return weight switch
        {
            PhosphorIconWeight.Thin => $"{baseName}-thin",
            PhosphorIconWeight.Light => $"{baseName}-light",
            PhosphorIconWeight.Regular => $"{baseName}-regular",
            PhosphorIconWeight.Bold => $"{baseName}-bold",
            PhosphorIconWeight.Fill => $"{baseName}-fill",
            PhosphorIconWeight.DuoTone => $"{baseName}-duotone",
            _ => throw new ArgumentOutOfRangeException(nameof(weight), weight, null),
        };
    }
}
