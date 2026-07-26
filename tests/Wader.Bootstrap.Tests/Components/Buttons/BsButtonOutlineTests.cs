using NSubstitute;
using Wader.Bootstrap.Components.Buttons;
using Wader.Bootstrap.Components.Buttons.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Buttons;

public class BsButtonOutlineTests()
    : BsComponentTests<BsButtonOutline>("""<button type="button" class="btn {0}" {1}></button>""")
{
    private readonly IBsButtonJsInterop _buttonJsInteropMock = Substitute.For<IBsButtonJsInterop>();
    protected override string ClassesForDefaultTests => "btn-outline-primary";

    [Theory]
    [InlineData(BsButtonOutlineVariant.Primary, "btn-outline-primary")]
    [InlineData(BsButtonOutlineVariant.Secondary, "btn-outline-secondary")]
    [InlineData(BsButtonOutlineVariant.Success, "btn-outline-success")]
    [InlineData(BsButtonOutlineVariant.Danger, "btn-outline-danger")]
    [InlineData(BsButtonOutlineVariant.Warning, "btn-outline-warning")]
    [InlineData(BsButtonOutlineVariant.Info, "btn-outline-info")]
    [InlineData(BsButtonOutlineVariant.Light, "btn-outline-light")]
    [InlineData(BsButtonOutlineVariant.Dark, "btn-outline-dark")]
    public void VariantAddsCorrectClass(BsButtonOutlineVariant variant, string? expectedClass)
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
