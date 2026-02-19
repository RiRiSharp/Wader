using NSubstitute;
using Wader.Bootstrap.Components.Buttons;
using Wader.Bootstrap.Components.Buttons.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Buttons;

public class BsButtonBaseTests() : BsComponentTests<BsButtonBase>("""<button class="btn {0}" {1}></button>""")
{
    private readonly IBsButtonJsFunctions _buttonJsFunctionsMock = Substitute.For<IBsButtonJsFunctions>();
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "button" };

    [Theory]
    [InlineData(BsButtonType.Button, "button")]
    [InlineData(BsButtonType.Link, "a")]
    [InlineData(BsButtonType.Label, "label")]
    public void ButtonTypeCreatesCorrectTag(BsButtonType type, string expectedTag)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ButtonType, type));

        // Assert
        cut.MarkupMatches($"<{expectedTag} diff:ignoreAttributes></{expectedTag}>");
    }

    [Theory]
    [InlineData(BsButtonSize.Regular, null)]
    [InlineData(BsButtonSize.Small, "btn-sm")]
    [InlineData(BsButtonSize.Large, "btn-lg")]
    public void SizeAddsCorrectClass(BsButtonSize size, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Size, size));

        // Assert
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(true, "active")]
    public void ActiveAddsCorrectClass(bool active, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Active, active));

        // Assert
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(false, null)]
    [InlineData(true, "disabled")]
    public void DisabledAddsCorrectClass(bool disabled, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();
        var attributes = AttributesForDefaultTests;
        attributes["disabled"] = "";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Disabled, disabled));

        // Assert
        var expectedMarkupString = GetExpectedHtml($"{ClassesForDefaultTests} {expectedClass}", attributes);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public async Task ToggleCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ToggleAsync);

        // Assert
        await _buttonJsFunctionsMock.Received(1).ToggleAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public void ButtonTypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_buttonJsFunctionsMock);
    }
}
