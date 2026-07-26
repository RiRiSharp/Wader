using Wader.Bootstrap.Content.TextDecorations;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Content.TextDecorations;

public class BsStrikethroughTextTests()
    : BsComponentTests<BsStrikethroughText>("""<span class="text-decoration-line-through {0}" {1}></span>""");
