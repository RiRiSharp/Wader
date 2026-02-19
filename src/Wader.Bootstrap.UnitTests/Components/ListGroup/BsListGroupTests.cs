using Wader.Bootstrap.Components.ListGroup;

namespace Wader.Bootstrap.UnitTests.Components.ListGroup;

public class BsListGroupTests() : BsComponentTests<BsListGroup>("""<div class="list-group {0}" {1}></div>""")
{
    [Theory]
    [InlineData(BsListType.ContentDivision, "div")]
    [InlineData(BsListType.UnorderedList, "ul")]
    [InlineData(BsListType.OrderedList, "ol")]
    public void TypeCreatesCorrectTag(BsListType type, string expectedTag)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.Type, type));

        // Assert
        cut.MarkupMatches($"<{expectedTag} diff:ignoreAttributes></{expectedTag}>");
    }

    [Theory]
    [InlineData(BsListGroupDirection.Vertical, "")]
    [InlineData(BsListGroupDirection.Horizontal, "list-group-horizontal")]
    public void DirectionAddsCorrectClass(BsListGroupDirection direction, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Direction, direction));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(BsListGroupMode.Regular, "")]
    [InlineData(BsListGroupMode.Flush, "list-group-flush")]
    public void ModeAddsCorrectClass(BsListGroupMode dropdownMode, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Mode, dropdownMode));

        // Assert
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }
}
