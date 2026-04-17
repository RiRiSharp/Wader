using Wader.Bootstrap.Components.Placeholders;

namespace Wader.Bootstrap.Tests.Components.Placeholders;

public class BsPlaceholderAnimationTests() : BsComponentTests<BsPlaceholderAnimation>("""<div class="{0}" {1}></div>""")
{
    protected override string ClassesForDefaultTests => "placeholder-glow";

    [Theory]
    [InlineData(BsPlaceholderAnimationType.Glow, "placeholder-glow")]
    [InlineData(BsPlaceholderAnimationType.Wave, "placeholder-wave")]
    public void AnimationAddsCorrectClass(BsPlaceholderAnimationType animation, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Animation, animation));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }
}
