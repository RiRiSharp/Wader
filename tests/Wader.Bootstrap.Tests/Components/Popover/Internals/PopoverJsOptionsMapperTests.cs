using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Components.Popover;
using Wader.Bootstrap.Components.Popover.Internals;

namespace Wader.Bootstrap.Tests.Components.Popover.Internals;

public class PopoverJsOptionsMapperTests
{
    [Fact]
    public void PopoverMapperMapsSimplePropertiesCorrectly()
    {
        var input = new BsPopoverOptions
        {
            Animation = true,
            ContainerString = "body",
            ContainerRef = null,
            CustomClass = "my-class",
            HideDelay = 150,
            ShowDelay = 250,
            Distance = 10,
            Skidding = 5,
            Placement = BsPopoverPlacement.Top,
            Trigger = BsPopoverTrigger.Click,
        };

        var titleRef = new ElementReference("title");
        var contentRef = new ElementReference("content");

        var result = input.ToPopoverJsOptions(titleRef, contentRef);

        Assert.True(result.Animation);
        Assert.Equal("body", result.ContainerString);
        Assert.Equal(expected: "my-class", result.CustomClass);
        Assert.Equal(titleRef, result.Title);
        Assert.Equal(contentRef, result.ContentRef);
    }

    [Fact]
    public void PopoverMapperAppliesCorrectDefaults()
    {
        var input = new BsPopoverOptions();

        var result = input.ToPopoverJsOptions(titleRef: null, contentRef: null);

        Assert.True(result.Html);
        Assert.False(result.Sanitize);
        Assert.NotNull(result.Delay);
        Assert.Equal(expected: "", result.CustomClass);
    }

    [Fact]
    public void PopoverMapperMapsDelayCorrectly()
    {
        var input = new BsPopoverOptions { HideDelay = 100, ShowDelay = 200 };

        var result = input.ToPopoverJsOptions(titleRef: null, contentRef: null);

        Assert.NotNull(result.Delay);
        Assert.Equal(expected: 100, result.Delay.Hide);
        Assert.Equal(expected: 200, result.Delay.Show);
    }

    [Fact]
    public void PopoverMapsOffsetInCorrectOrder()
    {
        var input = new BsPopoverOptions { Distance = 12, Skidding = 7 };

        var result = input.ToPopoverJsOptions(titleRef: null, contentRef: null);

        Assert.Equal(expected: 2, result.Offset.Count);
        Assert.Equal(expected: 12, result.Offset[0]);
        Assert.Equal(expected: 7, result.Offset[1]);
    }

    [Fact]
    public void PopoverDoesNotMutateInput()
    {
        var input = new BsPopoverOptions { Distance = 10, Skidding = 5 };

        _ = input.ToPopoverJsOptions(titleRef: null, contentRef: null);

        Assert.Equal(expected: 10, input.Distance);
        Assert.Equal(expected: 5, input.Skidding);
    }
}
