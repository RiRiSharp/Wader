using NSubstitute;
using Wader.Bootstrap.Components.Toasts;
using Wader.Bootstrap.Components.Toasts.Internals;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.Toast;

public class BsToastTests() : BsComponentTests<BsToast>("""<div class="toast {0}" {1}></div>""")
{
    private readonly IBsToastJsInterop _toastJsInteropMock = Substitute.For<IBsToastJsInterop>();

    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new()
        {
            ["role"] = "alert",
            ["aria-live"] = "assertive",
            ["aria-atomic"] = "true",
        };

    [Fact]
    public void RoleAttribute_CanBeOverridden()
    {
        TestForAllowingOverride("role");
    }

    [Fact]
    public void AriaLiveAttribute_CanBeOverridden()
    {
        TestForAllowingOverride("aria-live");
    }

    [Fact]
    public void AriaAtomicAttribute_CanBeOverridden()
    {
        TestForAllowingOverride("aria-atomic");
    }

    [Fact]
    public async Task Show_CallsShowJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.ShowAsync();

        // Assert
        await _toastJsInteropMock.Received(1).ShowAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task Hide_CallsShowJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.HideAsync();

        // Assert
        await _toastJsInteropMock.Received(1).HideAsync(cut.Instance.HtmlRef);
    }

    [Fact]
    public async Task Dispose_CallsDisposeElementJsInterop()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut();
        await cut.Instance.DisposeAsync();

        // Assert
        await _toastJsInteropMock.Received(1).DisposeReferenceAsync(cut.Instance.HtmlRef);
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_toastJsInteropMock);
    }
}
