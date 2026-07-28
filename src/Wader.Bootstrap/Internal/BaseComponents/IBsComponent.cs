namespace Wader.Bootstrap.Internal.BaseComponents;

public interface IBsComponent
{
    IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}
