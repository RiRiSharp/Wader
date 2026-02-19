using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Accordion;
using Wader.Bootstrap.Components.Accordion.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Accordion;

public class BsAccordionCollapseTests()
    : BsComponentTests<BsAccordionCollapse>("""<div class="accordion-collapse collapse {0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "show";

    private readonly IBsAccordionJsFunctions _accordionJsFunctionsMock = Substitute.For<IBsAccordionJsFunctions>();
    private readonly IBsAccordionItemContext _accordionItemContextMock = Substitute.For<IBsAccordionItemContext>();

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task CollapsedParametersWorksAsExpectedAsync(bool isCollapsed)
    {
        // Arrange
        ConfigureTestContext();
        _ = _accordionItemContextMock.Collapsed.Returns(isCollapsed);

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(() => cut.Instance.UpdateCollapseState(isCollapsed));

        // Assert
        var collapsingClass = isCollapsed ? "" : "show";
        cut.MarkupMatches(GetExpectedHtml(collapsingClass, ""));
    }

    [Fact]
    public async Task OnAfterRenderCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();

        // Assert
        await _accordionJsFunctionsMock
            .Received(1)
            .RegisterCollapseCallbackAsync(cut.Instance.HtmlRef, Arg.Any<DotNetObjectReference<BsAccordionCollapse>>());
    }

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsAccordionCollapse> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(_accordionItemContextMock);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_accordionJsFunctionsMock);
    }
}
