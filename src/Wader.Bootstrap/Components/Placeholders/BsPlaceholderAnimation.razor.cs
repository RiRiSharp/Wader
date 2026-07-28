using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;

namespace Wader.Bootstrap.Components.Placeholders;

public partial class BsPlaceholderAnimation : BsChildContentComponent
{
    protected override string? BsComponentClasses => AnimationClass;

    [Parameter]
    public BsPlaceholderAnimationType Animation { get; set; } = BsPlaceholderAnimationType.Glow;

    private string AnimationClass => Animation.ToBootstrapClass();
}
