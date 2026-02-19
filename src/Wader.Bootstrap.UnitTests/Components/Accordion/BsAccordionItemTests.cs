using NSubstitute;
using Wader.Bootstrap.Components.Accordion;
using Wader.Bootstrap.Components.Accordion.Internals;

namespace Wader.Bootstrap.UnitTests.Components.Accordion;

public class BsAccordionItemTests()
    : BsComponentTests<BsAccordionItem>("""<div class="accordion-item {0}" {1}></div>""")
{
    private readonly IBsAccordionJsFunctions _accordionJsFunctionsMock = Substitute.For<IBsAccordionJsFunctions>();
    private readonly IBsAccordionContext _accordionItemContextMock = Substitute.For<IBsAccordionContext>();

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsAccordionItem> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.AddCascadingValue(_accordionItemContextMock);
    }

    [Fact]
    public void SettingInitialCollapsedCommunicatesToContext()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.InitialCollapsed, true));

        // Assert
        Assert.True(cut.Instance.AccordionItemContext.Collapsed);
    }

    [Fact]
    public async Task ToggleCallsJsCorrectlyAsync()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.ToggleAsync);

        // Assert
        await _accordionJsFunctionsMock.Received(1).ToggleAsync(cut.Instance.HtmlRef, Arg.Any<bool>());
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
        await _accordionJsFunctionsMock.Received(1).ShowAsync(cut.Instance.HtmlRef, Arg.Any<bool>());
    }

    [Fact]
    public async Task CollapseCallJsCorrectlyAsync()
    {
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.InvokeAsync(cut.Instance.CollapseAsync);

        // Assert
        await _accordionJsFunctionsMock.Received(1).CollapseAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public void AccordionItemContextIsCascading()
    {
        TestForCascadingValue<IBsAccordionItemContext>();
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_accordionJsFunctionsMock);
    }
}
