using Microsoft.JSInterop;
using NSubstitute;
using Wader.Bootstrap.Components.Accordion;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Accordion;

public class BsAccordionButtonTests()
    : BsComponentTests<BsAccordionButton>("""<button class="accordion-button {0}" {1}></button>""")
{
    private readonly IBsAccordionItemContext _accordionItemContextMock = Substitute.For<IBsAccordionItemContext>();
    private readonly IBsAccordionJsInterop _accordionJsInteropMock = Substitute.For<IBsAccordionJsInterop>();

    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["type"] = "button" };

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
        var collapsingClass = isCollapsed ? "collapsed" : "";
        cut.MarkupMatches(GetExpectedHtml(collapsingClass, AttributesForDefaultTests));
    }

    [Fact]
    public void ButtonTypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }

    [Fact]
    public async Task OnAfterRender_RegistersCollapseCallbackJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();

        // Assert
        await _accordionJsInteropMock
            .Received(1)
            .RegisterCollapseCallbackAsync(cut.Instance.HtmlRef, Arg.Any<DotNetObjectReference<BsAccordionButton>>());
    }

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsAccordionButton> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(CascadingValueNames.ACCORDION_ITEM_CONTEXT, _accordionItemContextMock);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_accordionJsInteropMock);
    }
}
