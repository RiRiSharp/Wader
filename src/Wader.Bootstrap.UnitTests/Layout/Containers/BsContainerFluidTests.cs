using Wader.Bootstrap.Layout.Containers;

namespace Wader.Bootstrap.UnitTests.Layout.Containers;

public class BsContainerFluidTests()
    : BsComponentTests<BsContainerFluid>("""<div class="container-fluid {0}" {1}></div>""");
