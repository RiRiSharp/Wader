using Wader.Layout.Containers;

namespace Wader.UnitTests.Layout.Containers;

public class BsContainerFluidTests()
    : BsComponentTests<BsContainerFluid>("""<div class="container-fluid {0}" {1}></div>""");
