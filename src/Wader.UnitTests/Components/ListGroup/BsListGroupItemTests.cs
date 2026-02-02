using Wader.Components.ListGroup;

namespace Wader.UnitTests.Components.ListGroup;

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
        var cut = GetCut(parameters => parameters.Add(x => x.ItemType, type));

        // Assert
        cut.MarkupMatches($"<{expectedTag} diff:ignoreAttributes></{expectedTag}>");
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
            parameters.Add(p => p.ItemType, BsListGroupItemType.Button).AddUnmatched(attributeKey, value)
        );

        // Assert
        cut.MarkupMatches($"""<button class:ignore {attributeKey}="{value}"></button>""");
    }
}
