using Wader.Bootstrap.Components.ListGroup;
using Wader.Bootstrap.Tests.TestUtilities;

namespace Wader.Bootstrap.Tests.Components.ListGroup;

public class BsListGroupItemTests() : BsComponentTests<BsListGroupItem>("""<li class="list-group-item {0}" {1}></li>""")
{
    [Theory]
    [InlineData(BsListGroupItemType.ListItem, "li")]
    [InlineData(BsListGroupItemType.Button, "button")]
    [InlineData(BsListGroupItemType.Link, "a")]
    public void ItemTypeCreatesCorrectTag(BsListGroupItemType type, string expectedTag)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ElType, type));

        // Assert
        cut.MarkupMatches($"<{expectedTag} diff:ignoreAttributes></{expectedTag}>");
    }

    [Theory]
    [InlineData(BsListGroupItemType.ListItem, false)]
    [InlineData(BsListGroupItemType.Button, true)]
    [InlineData(BsListGroupItemType.Link, true)]
    public void ItemTypeAddsCorrectActionClass(BsListGroupItemType type, bool classShouldBeThere)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(x => x.ElType, type));
        var element = cut.Find("*");

        // Assert
        Assert.Equal(classShouldBeThere, element.ClassList.Contains("list-group-item-action"));
    }

    [Theory]
    [InlineData(BsListGroupItemVariant.None, "")]
    [InlineData(BsListGroupItemVariant.Primary, "list-group-item-primary")]
    [InlineData(BsListGroupItemVariant.Secondary, "list-group-item-secondary")]
    [InlineData(BsListGroupItemVariant.Success, "list-group-item-success")]
    [InlineData(BsListGroupItemVariant.Danger, "list-group-item-danger")]
    [InlineData(BsListGroupItemVariant.Warning, "list-group-item-warning")]
    [InlineData(BsListGroupItemVariant.Info, "list-group-item-info")]
    [InlineData(BsListGroupItemVariant.Light, "list-group-item-light")]
    [InlineData(BsListGroupItemVariant.Dark, "list-group-item-dark")]
    public void VariantAddsCorrectClass(BsListGroupItemVariant variant, string? expectedClass)
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
    [InlineData(false, "")]
    [InlineData(true, "active")]
    public void ActiveAddsCorrectClass(bool isActive, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Active, isActive));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Theory]
    [InlineData(false, "")]
    [InlineData(true, "disabled")]
    public void DisabledAddsCorrectClass(bool isDisabled, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.Add(p => p.Disabled, isDisabled));

        // Assert
        var expectedMarkupString = GetExpectedHtml(expectedClass, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void ButtonTypeCanBeOverridden()
    {
        const string attributeKey = "type";
        // Arrange
        ConfigureTestContext();
        const string value = "some-unique-value";
        var attributes = AttributesForDefaultTests;
        attributes[attributeKey] = value;

        // Act
        var cut = GetCut(parameters =>
            parameters.Add(p => p.ElType, BsListGroupItemType.Button).AddUnmatched(attributeKey, value)
        );

        // Assert
        cut.MarkupMatches($"""<button class:ignore {attributeKey}="{value}"></button>""");
    }
}
