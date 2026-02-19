using NSubstitute;
using Wader.Bootstrap.Components.Accordion;
using Wader.Bootstrap.Components.Accordion.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Accordion;

public class BsAccordionTests() : BsComponentTests<BsAccordion>("""<div class="accordion {0}" {1}></div>""")
{
    private readonly IBsAccordionJsFunctions _accordionJsFunctionsMock = Substitute.For<IBsAccordionJsFunctions>();

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
        var cut = GetCut(parameters => parameters.Add(p => p.AlwaysOpen, true));

        // Assert
        Assert.True(cut.Instance.AccordionContext.AlwaysOpen);
    }

    [Fact]
    public async Task CollapseAllCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.CollapseAllAsync);

        // Assert
        await _accordionJsFunctionsMock.Received(1).CollapseAllAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task ShowAllCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ShowAllAsync);

        // Assert
        await _accordionJsFunctionsMock.Received(1).ShowAllAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task CollapseAllButOneCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();
        var accordionItem = Substitute.For<BsAccordionItem>();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(() => cut.Instance.CollapseAllButOneAsync(accordionItem));

        // Assert
        await _accordionJsFunctionsMock.Received(1).CollapseAllButOneAsync(cut.Instance.HtmlRef, accordionItem.HtmlRef);
    }

    [Fact]
    public void AccordionContextIsCascading()
    {
        TestForCascadingValue<IBsAccordionContext>();
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_accordionJsFunctionsMock);
    }
}
