using Wader.Bootstrap.Layout.Containers;

namespace Wader.Bootstrap.Tests.Layout.Containers;

public class BsContainerFluidTests()
    : BsComponentTests<BsContainerFluid>("""<div class="container-fluid {0}" {1}></div>""");
