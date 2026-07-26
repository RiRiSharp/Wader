using NSubstitute;
using Wader.Bootstrap.Components.Accordion;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Infrastructure.Constants;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Accordion;

public class BsAccordionItemTests()
    : BsComponentTests<BsAccordionItem>("""<div class="accordion-item {0}" {1}></div>""")
{
    private readonly IBsAccordionContext _accordionContextMock = Substitute.For<IBsAccordionContext>();
    private readonly IBsAccordionJsInterop _accordionJsInteropMock = Substitute.For<IBsAccordionJsInterop>();

    [Fact]
    public void SettingInitialCollapsedCommunicatesToContext()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.InitialCollapsed, value: true));

        // Assert
        Assert.True(cut.Instance.AccordionItemContext.Collapsed);
    }

    [Fact]
    public async Task Toggle_CallsToggleJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ToggleAsync);

        // Assert
        await _accordionJsInteropMock.Received(1).ToggleAsync(cut.Instance.HtmlRef, Arg.Any<bool>());
    }

    [Fact]
    public async Task ShowCallJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ShowAsync);

        // Assert
        await _accordionJsInteropMock.Received(1).ShowAsync(cut.Instance.HtmlRef, Arg.Any<bool>());
    }

    [Fact]
    public async Task CollapseCallJsCorrectlyAsync()
    {
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.CollapseAsync);

        // Assert
        await _accordionJsInteropMock.Received(1).CollapseAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public void AccordionItemContextIsCascading()
    {
        TestForCascadingValue<IBsAccordionItemContext>(CascadingValueNames.ACCORDION_ITEM_CONTEXT);
    }

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsAccordionItem> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(CascadingValueNames.ACCORDION_CONTEXT, _accordionContextMock);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_accordionJsInteropMock);
    }
}
