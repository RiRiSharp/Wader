using Wader.Bootstrap.Content.Blockquotes;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Content.Blockquotes;

public class BsBlockquoteTests()
    : BsComponentTests<BsBlockquote>("""<blockquote class="blockquote {0}" {1}></blockquote>""");
