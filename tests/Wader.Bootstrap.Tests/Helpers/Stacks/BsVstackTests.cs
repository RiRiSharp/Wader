using Wader.Bootstrap.Helpers.Stacks;
using Wader.Bootstrap.Internal.Exceptions;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.Stacks;

public class BsVstackTests() : BsComponentTests<BsVstack>("""<div class="vstack {0}" {1}></div>""")
{
    public static TheoryData<int?> AllowedGaps => [1, 2, 3];

    [Theory]
    [MemberData(nameof(AllowedGaps))]
    public void GapRendersCorrectClass(int? gap)
    {
        // Arrange
        ConfigureTestContext();
        var expectedClass = $"{ClassesForDefaultTests} gap-{gap}";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Gap, gap));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void UnsupportedOpacityThrows()
    {
        // Arrange
        ConfigureTestContext();

        // Act + Assert
        var ex = Assert.Throws<BsParameterException>(() => GetCut(parameters => parameters.Add(p => p.Gap, -1)));
        Assert.Contains(nameof(BsHstack.Gap), ex.Message);
    }
}
