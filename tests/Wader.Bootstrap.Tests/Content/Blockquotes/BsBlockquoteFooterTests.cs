using Wader.Bootstrap.Content.Blockquotes;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Content.Blockquotes;

public class BsBlockquoteFooterTests()
    : BsComponentTests<BsBlockquoteFooter>("""<figcaption class="blockquote-footer {0}" {1}></figcaption>""");
