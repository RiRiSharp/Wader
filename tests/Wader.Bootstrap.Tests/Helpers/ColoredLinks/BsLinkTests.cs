using Wader.Bootstrap.Helpers.ColoredLinks;
using Wader.Bootstrap.Internal.Exceptions;
using Wader.Bootstrap.Internal.Primitives;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Helpers.ColoredLinks;

public class BsLinkTests() : BsComponentTests<BsLink>("""<a class="{0}" {1}></div>""")
{
    public static TheoryData<int?> AllowedOpacities => [10, 25, 50, 75, 100];
    public static TheoryData<int?> AllowedUnderlineOpacities => [0, 10, 25, 50, 75, 100];
    protected override string ClassesForDefaultTests => "link-primary";

    [Theory]
    [InlineData(BsLinkVariant.Primary, "link-primary")]
    [InlineData(BsLinkVariant.Secondary, "link-secondary")]
    [InlineData(BsLinkVariant.Success, "link-success")]
    [InlineData(BsLinkVariant.Danger, "link-danger")]
    [InlineData(BsLinkVariant.Warning, "link-warning")]
    [InlineData(BsLinkVariant.Info, "link-info")]
    [InlineData(BsLinkVariant.Light, "link-light")]
    [InlineData(BsLinkVariant.Dark, "link-dark")]
    [InlineData(BsLinkVariant.Emphasis, "link-body-emphasis")]
    public void VariantRendersCorrectClass(BsLinkVariant variant, string expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Variant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [MemberData(nameof(AllowedOpacities))]
    public void OpacityRendersCorrectClass(int? opacity)
    {
        // Arrange
        ConfigureTestContext();
        var expectedClass = $"{ClassesForDefaultTests} link-opacity-{opacity}";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Opacity, opacity));

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
        Assert.Throws<BsParameterException>(() => GetCut(parameters => parameters.Add(p => p.Opacity, -1)));
    }

    [Theory]
    [MemberData(nameof(AllowedOpacities))]
    public void HoverOpacityRendersCorrectClass(int? opacity)
    {
        // Arrange
        ConfigureTestContext();
        var expectedClass = $"{ClassesForDefaultTests} link-opacity-{opacity}-hover";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.HoverOpacity, opacity));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void UnsupportedHoverOpacityThrows()
    {
        // Arrange
        ConfigureTestContext();

        // Act + Assert
        Assert.Throws<BsParameterException>(() => GetCut(parameters => parameters.Add(p => p.HoverOpacity, -1)));
    }

    [Theory]
    [InlineData(BsColor.Primary, "link-underline-primary")]
    [InlineData(BsColor.Secondary, "link-underline-secondary")]
    [InlineData(BsColor.Success, "link-underline-success")]
    [InlineData(BsColor.Danger, "link-underline-danger")]
    [InlineData(BsColor.Warning, "link-underline-warning")]
    [InlineData(BsColor.Info, "link-underline-info")]
    [InlineData(BsColor.Light, "link-underline-light")]
    [InlineData(BsColor.Dark, "link-underline-dark")]
    public void UnderlineVariantRendersCorrectClass(BsColor variant, string expectedClass)
    {
        // Arrange
        ConfigureTestContext();
        var classes = $"{ClassesForDefaultTests} {expectedClass}";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.UnderlineVariant, variant));

        // Assert
        var expectedMarkupString = GetExpectedHtml(classes, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [MemberData(nameof(AllowedUnderlineOpacities))]
    public void OffsetRendersCorrectClass(int? underlineOpacity)
    {
        // Arrange
        ConfigureTestContext();
        var expectedClass = $"{ClassesForDefaultTests} link-underline-opacity-{underlineOpacity}";

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.UnderlineOpacity, underlineOpacity));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void UnsupportedUnderlineOpacityThrows()
    {
        // Arrange
        ConfigureTestContext();

        // Act + Assert
        Assert.Throws<BsParameterException>(() => GetCut(parameters => parameters.Add(p => p.UnderlineOpacity, -1)));
    }
}
