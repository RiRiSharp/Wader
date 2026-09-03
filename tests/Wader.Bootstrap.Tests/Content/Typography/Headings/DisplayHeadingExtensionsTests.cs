using Wader.Bootstrap.Content.Typography.Headings;

namespace Wader.Bootstrap.Tests.Content.Typography.Headings;

public class DisplayHeadingExtensionsTests
{
    [Theory]
    [InlineData(BsDisplayHeadingType.Display1, "display-1")]
    [InlineData(BsDisplayHeadingType.Display2, "display-2")]
    [InlineData(BsDisplayHeadingType.Display3, "display-3")]
    [InlineData(BsDisplayHeadingType.Display4, "display-4")]
    [InlineData(BsDisplayHeadingType.Display5, "display-5")]
    [InlineData(BsDisplayHeadingType.Display6, "display-6")]
    public void DisplayHeadingGeneratesCorrectClass(BsDisplayHeadingType displayHeadingType, string? expectedClass)
    {
        var generatedClass = displayHeadingType.ToBootstrapClass();

        Assert.Equal(expectedClass, generatedClass);
    }
}
