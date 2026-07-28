using NSubstitute;
using Wader.Bootstrap.Components.Alert;
using Wader.Bootstrap.Components.Alert.Internals;
using Wader.Bootstrap.Internal.Constants;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Alert;

public class BsAlertTests() : BsComponentTests<BsAlert>("""<div class="alert {0}" {1}></div>""")
{
    private readonly IBsAlertJsInterop _alertJsInteropMock = Substitute.For<IBsAlertJsInterop>();

    protected override string ClassesForDefaultTests => "alert-primary fade show";
    protected override Dictionary<string, string> AttributesForDefaultTests => new() { ["role"] = "alert" };

    [Theory]
    [InlineData(BsAlertVariant.Primary, "alert-primary")]
    [InlineData(BsAlertVariant.Secondary, "alert-secondary")]
    [InlineData(BsAlertVariant.Success, "alert-success")]
    [InlineData(BsAlertVariant.Danger, "alert-danger")]
    [InlineData(BsAlertVariant.Warning, "alert-warning")]
    [InlineData(BsAlertVariant.Info, "alert-info")]
    [InlineData(BsAlertVariant.Light, "alert-light")]
    [InlineData(BsAlertVariant.Dark, "alert-dark")]
    public void VariantAddsCorrectClass(BsAlertVariant variant, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml($"{expectedClass} fade show", AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DismissibleAppliesCorrectClass(bool dismissible)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Dismissable, dismissible));

        // Assert
        var dismissClass = dismissible ? "alert-dismissible" : "";
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {dismissClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AnimateAppliesCorrectClass(bool animate)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Animate, animate));

        // Assert
        var animateClass = animate ? "fade show" : "";
        var expectedMarkupString = GetExpectedHtml($"alert-primary {animateClass}", AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public async Task Dismiss_CallsDismissJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Dismissable, value: true));
        await cut.InvokeAsync(cut.Instance.DismissAsync);

        // Assert
        await _alertJsInteropMock.Received(1).DismissAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public void AlertRoleCanBeOverriden()
    {
        TestForAllowingOverride("role");
    }

    [Fact]
    public void AlertContextIsCascading()
    {
        TestForCascadingValue<IBsAlertContext>(CascadingValueNames.ALERT_CONTEXT);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_alertJsInteropMock);
    }
}
