using NSubstitute;
using Wader.Bootstrap.Components.Accordion;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Accordion;

public class BsAccordionTests() : BsComponentTests<BsAccordion>("""<div class="accordion {0}" {1}></div>""")
{
    private readonly IBsAccordionJsInterop _accordionJsInteropMock = Substitute.For<IBsAccordionJsInterop>();

    [Theory]
    [InlineData(BsAccordionDisplayStyle.Regular, "")]
    [InlineData(BsAccordionDisplayStyle.Flush, "accordion-flush")]
    public void DisplayStyleWorksCorrectly(BsAccordionDisplayStyle displayStyle, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.DisplayStyle, displayStyle));

        // Assert
        cut.MarkupMatches(GetExpectedHtml(expectedClass));
    }

    [Fact]
    public void AlwaysOpenSetsCommunicatesToContext()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.AlwaysOpen, value: true));

        // Assert
        Assert.True(cut.Instance.AccordionContext.AlwaysOpen);
    }

    [Fact]
    public async Task CollapseAll_CallsCollapseAllJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.CollapseAllAsync);

        // Assert
        await _accordionJsInteropMock.Received(1).CollapseAllAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task ShowAll_CallsShowAllJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ShowAllAsync);

        // Assert
        await _accordionJsInteropMock.Received(1).ShowAllAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task CollapseAllButOne_CallsCollapseAllButOneJsInterop()
    {
        // Arrange
        ConfigureTestContext();
        var accordionItem = Substitute.For<BsAccordionItem>();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(() => cut.Instance.CollapseAllButOneAsync(accordionItem));

        // Assert
        await _accordionJsInteropMock.Received(1).CollapseAllButOneAsync(cut.Instance.HtmlRef, accordionItem.HtmlRef);
    }

    [Fact]
    public void AccordionContextIsCascading()
    {
        TestForCascadingValue<IBsAccordionContext>(CascadingValueNames.ACCORDION_CONTEXT);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_accordionJsInteropMock);
    }
}
