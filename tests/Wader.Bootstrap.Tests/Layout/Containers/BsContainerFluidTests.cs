using Wader.Bootstrap.Layout.Containers;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Layout.Containers;

public class BsContainerFluidTests()
    : BsComponentTests<BsContainerFluid>("""<div class="container-fluid {0}" {1}></div>""");
