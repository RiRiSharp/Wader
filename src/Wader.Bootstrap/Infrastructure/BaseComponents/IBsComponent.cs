namespace Wader.Bootstrap.Infrastructure.BaseComponents;

public interface IBsComponent
{
    IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
}
