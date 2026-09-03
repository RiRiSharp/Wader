using Wader.Bootstrap.Content.Typography.Blockquotes;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Content.Typography.Blockquotes;

public class BsBlockquoteTests()
    : BsComponentTests<BsBlockquote>("""<blockquote class="blockquote {0}" {1}></blockquote>""");
