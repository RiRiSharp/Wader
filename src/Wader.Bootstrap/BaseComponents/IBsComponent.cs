namespace Wader.Bootstrap.BaseComponents;

public interface IBsComponent
{
    IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}
