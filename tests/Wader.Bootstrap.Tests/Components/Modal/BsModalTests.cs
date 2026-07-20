using NSubstitute;
using Wader.Bootstrap.Components.Modal;
using Wader.Bootstrap.Components.Modal.Internals;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Primitives;

namespace Wader.Bootstrap.Tests.Components.Modal;

public class BsModalTests() : BsComponentTests<BsModal>("""<div class="modal {0}" {1}></div>""")
{
    private readonly IBsModalJsInterop _modalJsInteropMock = Substitute.For<IBsModalJsInterop>();
    protected override string ClassesForDefaultTests => "fade";

    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new() { ["tabindex"] = "-1", ["aria-hidden"] = "true" };

    [Theory]
    [InlineData(BsBackdrop.Regular, null, null)]
    [InlineData(BsBackdrop.Static, "static", "false")]
    public void BackdropAddsCorrectDataBsAttributes(
        BsBackdrop backdrop,
        string? backdropAttributeValue,
        string? keyboardAttributeValue
    )
    {
        // Arrange
        ConfigureTestContext();

        var attributes = AttributesForDefaultTests;
        if (backdropAttributeValue is not null)
        {
            attributes["data-bs-backdrop"] = backdropAttributeValue;
        }

        if (keyboardAttributeValue is not null)
        {
            attributes["data-bs-keyboard"] = keyboardAttributeValue;
        }

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Backdrop, backdrop));

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, attributes);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(true, "fade")]
    [InlineData(false, "")]
    public void FadingAddsCorrectClass(bool fade, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Fade, fade));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public async Task Toggle_CallsToggleJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ToggleAsync();

        // Assert
        await _modalJsInteropMock.Received(1).ToggleAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task Show_CallsShowJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ShowAsync();

        // Assert
        await _modalJsInteropMock.Received(1).ShowAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task Close_CallsCloseJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.CloseAsync();

        // Assert
        await _modalJsInteropMock.Received(1).CloseAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public void TabIndexCanBeOverriden()
    {
        TestForAllowingOverride("tab-index");
    }

    [Fact]
    public void AriaHiddenCanBeOverriden()
    {
        TestForAllowingOverride("aria-hidden");
    }

    [Fact]
    public void ModalContextIsCascading()
    {
        TestForCascadingValue<IBsModalContext>(CascadingValueNames.MODAL_CONTEXT);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_modalJsInteropMock);
    }
}
