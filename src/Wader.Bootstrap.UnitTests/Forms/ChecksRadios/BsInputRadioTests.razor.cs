using Wader.Bootstrap.Forms.ChecksRadios;

namespace Wader.Bootstrap.UnitTests.Forms.ChecksRadios;

public partial class BsInputRadioTests : BsComponentTests<BsInputRadio<string>>
{
    private string? _boundValue = "";
    private const string SOME_VALUE_VAR = "someValue";
    private const string DIFFERENT_VALUE_VAR = "differentValue";

    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "radio" };

    public BsInputRadioTests()
        : base($$"""<input class="form-check-input {0}" name="{{nameof(_boundValue)}}" {1}>""") { }

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

    protected override IRenderedComponent<BsInputRadio<string>> GetCut(
        Action<ComponentParameterCollectionBuilder<BsInputRadio<string>>>? action = null
    )
    {
        var inputGroupComponent = Render<BsInputRadioGroup<string>>(parameters =>
        {
            _ = parameters
                .Add(p => p.Name, nameof(_boundValue))
                .Bind(p => p.Value, _boundValue, newValue => _boundValue = newValue)
                .AddChildContent<BsInputRadio<string>>(pms =>
                {
                    BindParameters(pms);
                    action?.Invoke(pms);
                });
        });
        return inputGroupComponent.FindComponent<BsInputRadio<string>>();
    }
}
