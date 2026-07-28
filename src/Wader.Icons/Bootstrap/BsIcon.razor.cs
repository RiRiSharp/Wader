using Microsoft.AspNetCore.Components;
using Wader.Bootstrap.Internal.BaseComponents;
using Wader.Icons.Internal;

namespace Wader.Icons.Bootstrap;

public partial class BsIcon : BsComponent
{
    protected override string? BsComponentClasses => null;

    [Parameter, EditorRequired]
    public string Name { get; set; }

    private string IconPath => $"{LibraryInfo.RootPath}/sprites/bootstrap/icons.svg#{Name}";
}
