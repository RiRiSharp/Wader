using Wader.Bootstrap.Components.Modal;

namespace Wader.Bootstrap.UnitTests.Components.Modal;

public class BsModalDialogTests() : BsComponentTests<BsModalDialog>("""<div class="modal-dialog {0}" {1}></div>""")
{
    [Theory]
    [InlineData(BsModalScrollOptions.WholePage, "")]
    [InlineData(BsModalScrollOptions.DialogOnly, "modal-dialog-scrollable")]
    public void ScrollableAddsCorrectClass(BsModalScrollOptions scrollOptions, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ScrollOptions, scrollOptions));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsModalPosition.Top, "")]
    [InlineData(BsModalPosition.VerticallyCentered, "modal-dialog-centered")]
    public void VerticallyCenteredAddsCorrectClass(BsModalPosition position, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Position, position));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsModalFullScreenOptions.Disable, "")]
    [InlineData(BsModalFullScreenOptions.Enable, "modal-fullscreen")]
    public void FullscreenAddsCorrectClass(BsModalFullScreenOptions fullScreenOptions, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.FullScreen, fullScreenOptions));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
