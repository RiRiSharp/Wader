using Wader.Bootstrap.Components.Toasts;

namespace Wader.Bootstrap.Tests.Components.Toast;

public class BsToastContainerTests()
    : BsComponentTests<BsToastContainer>(htmlFormat: """<div class="toast-container {0}" {1}></div>""");
