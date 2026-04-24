using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.BaseComponents;
using Wader.Bootstrap.Components.Scrollspy.Internals;

namespace Wader.Bootstrap.Components.Scrollspy;

public partial class BsScrollspy : BsChildContentComponent
{
    protected override string? BsComponentClasses => null;

    [Parameter, EditorRequired]
    public ElementReference Target { get; set; }

    private ElementReference? _oldTarget;

    [Parameter]
    public double? Threshold { get; set; }

    [Parameter]
    public string? RootMargin { get; set; }

    [Parameter]
    public bool SmoothScroll { get; set; }

    [Inject]
    public IBsScrollspyJsInterop BsScrollspyJsInterop { get; set; } = null!;

    internal ElementReference HtmlRef;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        if (_oldTarget is null || _oldTarget.Value.Id != Target.Id)
        {
            await BsScrollspyJsInterop.CreateAsync(HtmlRef, new ScrollspyJsOptions { TargetRef = Target });
            _oldTarget = Target;
        }
    }
}
