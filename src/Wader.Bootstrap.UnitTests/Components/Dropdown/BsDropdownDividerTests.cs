using Wader.Bootstrap.Components.Dropdown;

namespace Wader.Bootstrap.UnitTests.Components.Dropdown;

public class BsDropdownDividerTests()
    : BsComponentTests<BsDropdownDivider>("""<li><hr class="dropdown-divider {0}" {1}></hr></li>""");
