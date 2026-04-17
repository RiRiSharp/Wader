using Wader.Bootstrap.Forms.ChecksRadios;

namespace Wader.Bootstrap.Tests.Forms.ChecksRadios;

public partial class BsButtonCheckInputRadioTests : BsComponentTests<BsButtonCheckInputRadio<string>>
{
    private const string SOME_VALUE_VAR = "someValue";
    private const string DIFFERENT_VALUE_VAR = "differentValue";
    private string? _boundValue = "";

    public BsButtonCheckInputRadioTests()
        : base("""<input class="btn-check {0}" {1}>""") { }

    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new() { ["type"] = "radio", ["name"] = nameof(_boundValue) };

    [Fact]
    public void MatchingValuesChecksTheRadio()
    {
        // Arrange
        _boundValue = SOME_VALUE_VAR;
        var attributeDict = AttributesForDefaultTests;
        attributeDict["value"] = SOME_VALUE_VAR;
        // One might ask why a? And there's a (no pun intended) super obscure reason for it.
        // This can be found here: https://github.com/dotnet/aspnetcore/blob/main/src/Components/Web/src/Forms/InputRadio.cs#L78-L95
        attributeDict["checked"] = "a";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Value, SOME_VALUE_VAR));

        // Assert

        var expectedMarkupString = GetExpectedHtml("", attributeDict);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void InputTypeCannotBeOverriden()
    {
        TestForDisallowingOverride("type");
    }

    protected override IRenderedComponent<BsButtonCheckInputRadio<string>> GetCut(
        Action<ComponentParameterCollectionBuilder<BsButtonCheckInputRadio<string>>>? action = null
    )
    {
        var inputGroupComponent = Render<BsInputRadioGroup<string>>(parameters =>
        {
            _ = parameters
                .Add(p => p.Name, nameof(_boundValue))
                .Bind(p => p.Value, _boundValue, newValue => _boundValue = newValue)
                .AddChildContent<BsButtonCheckInputRadio<string>>(pms =>
                {
                    BindParameters(pms);
                    action?.Invoke(pms);
                });
        });
        return inputGroupComponent.FindComponent<BsButtonCheckInputRadio<string>>();
    }
}
