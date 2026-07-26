using NSubstitute;
using Wader.Bootstrap.Components.Buttons;
using Wader.Bootstrap.Components.Buttons.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Buttons;

public class BsButtonTests() : BsComponentTests<BsButton>("""<button type="button" class="btn {0}" {1}></button>""")
{
    private readonly IBsButtonJsInterop _buttonJsInteropMock = Substitute.For<IBsButtonJsInterop>();
    protected override string ClassesForDefaultTests => "btn-primary";

    [Theory]
    [InlineData(BsButtonVariant.Primary, "btn-primary")]
    [InlineData(BsButtonVariant.Secondary, "btn-secondary")]
    [InlineData(BsButtonVariant.Success, "btn-success")]
    [InlineData(BsButtonVariant.Danger, "btn-danger")]
    [InlineData(BsButtonVariant.Warning, "btn-warning")]
    [InlineData(BsButtonVariant.Info, "btn-info")]
    [InlineData(BsButtonVariant.Light, "btn-light")]
    [InlineData(BsButtonVariant.Dark, "btn-dark")]
    [InlineData(BsButtonVariant.Link, "btn-link")]
    public void VariantAddsCorrectClass(BsButtonVariant variant, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void ButtonTypeGetsTransferredToBase()
    {
        // Arrange
        ConfigureTestContext();
        const BsButtonType type = BsButtonType.Link;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.ButtonType, type));

        // Assert
        var baseComponent = cut.FindComponent<BsButtonBase>();
        Assert.Equal(type, baseComponent.Instance.ButtonType);
    }

    [Fact]
    public void SizeGetsTransferredToBase()
    {
        // Arrange
        ConfigureTestContext();
        const BsButtonSize size = BsButtonSize.Large;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Size, size));

        // Assert
        var baseComponent = cut.FindComponent<BsButtonBase>();
        Assert.Equal(size, baseComponent.Instance.Size);
    }

    [Fact]
    public void ActiveGetsTransferredToBase()
    {
        // Arrange
        ConfigureTestContext();
        const bool active = true;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Active, active));

        // Assert
        var baseComponent = cut.FindComponent<BsButtonBase>();
        Assert.Equal(active, baseComponent.Instance.Active);
    }

    [Fact]
    public void DisabledGetsTransferredToBase()
    {
        // Arrange
        ConfigureTestContext();
        const bool disabled = true;

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Disabled, disabled));

        // Assert
        var baseComponent = cut.FindComponent<BsButtonBase>();
        Assert.Equal(disabled, baseComponent.Instance.Disabled);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_buttonJsInteropMock);
    }
}
