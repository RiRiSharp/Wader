using Wader.Bootstrap.Components.Dropdown;

namespace Wader.Bootstrap.Tests.Components.Dropdown;

public class BsDropdownDividerTests()
    : BsComponentTests<BsDropdownDivider>("""<li><hr class="dropdown-divider {0}" {1}></hr></li>""");
