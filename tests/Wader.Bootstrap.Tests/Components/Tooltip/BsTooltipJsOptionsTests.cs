using Wader.Bootstrap.Components.Popover;
using Wader.Bootstrap.Components.Tooltip;
using Wader.Bootstrap.Infrastructure.Exceptions;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Tooltip;

public class BsTooltipJsOptionsTests
{
    [Fact]
    public void Boundary_WhenStringIsNotClippingElement_Throws()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.Throws<BsJsInteropOptionsException>(() => sut.Boundary = "yoink");
    }

    [Fact]
    public void Boundary_WhenStringIsClippingElement_DoesNotThrow()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.DoesNotThrow(() => sut.Boundary = BsTooltipJsOptions.CLIPPING_PARENTS);
    }

    [Fact]
    public void Container_WhenTrue_Throws()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.Throws<BsJsInteropOptionsException>(() => sut.Container = true);
    }

    [Fact]
    public void Container_WhenFalse_DoesNotThrow()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.DoesNotThrow(() => sut.Container = false);
    }

    // Fallbackplacements, offset, selector, trigger

    [Fact]
    public void FallbackPlacements_WhenAutoCombinedWithOthers_Throws()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.Throws<BsJsInteropOptionsException>(() =>
            sut.FallbackPlacements = [BsPopoverPlacement.Auto, BsPopoverPlacement.Bottom]
        );
    }

    [Fact]
    public void FallbackPlacements_WithoutAuto_DoesNotThrow()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.DoesNotThrow(() => sut.FallbackPlacements = [BsPopoverPlacement.Bottom, BsPopoverPlacement.Top]);
    }

    [Fact]
    public void Offset_WhenMoreThanTwo_Throws()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.Throws<BsJsInteropOptionsException>(() => sut.Offset = [0, 6, 7]);
    }

    [Theory]
    [InlineData(6)]
    [InlineData(6, 7)]
    public void Offset_WhenLessOrEqualTwo_DoesNotThrow(params int[] values)
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.DoesNotThrow(() => sut.Offset = values);
    }

    [Fact]
    public void Selector_WhenTrue_Throws()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.Throws<BsJsInteropOptionsException>(() => sut.Selector = true);
    }

    [Fact]
    public void Selector_WhenFalse_DoesNotThrow()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.DoesNotThrow(() => sut.Selector = false);
    }

    [Fact]
    public void Trigger_WhenManualCombinedWithOthers_Throws()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.Throws<BsJsInteropOptionsException>(() =>
            sut.Trigger = [BsPopoverTrigger.Manual, BsPopoverTrigger.Click]
        );
    }

    [Fact]
    public void Trigger_WithoutManual_DoesNotThrow()
    {
        // Arrange
        var sut = new BsTooltipJsOptions();

        // Act + Assert
        Assert.DoesNotThrow(() => sut.Trigger = [BsPopoverTrigger.Click, BsPopoverTrigger.Focus]);
    }
}
