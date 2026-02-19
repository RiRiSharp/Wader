using NSubstitute;
using Wader.Bootstrap.Components.Buttons;
using Wader.Bootstrap.Components.Buttons.Internals;
using Wader.Bootstrap.Components.Dropdown;
using Wader.Bootstrap.Internals.Exceptions;

namespace Wader.Bootstrap.UnitTests.Components.Dropdown;

public class BsDropdownToggleTests()
    : BsComponentTests<BsDropdownToggle>(
        """<button class="btn dropdown-toggle {0}" data-bs-toggle="dropdown" {1}></div>"""
    )
{
    private readonly IBsButtonJsFunctions _buttonJsFunctionsMock = Substitute.For<IBsButtonJsFunctions>();

    protected override Dictionary<string, string> AttributesForDefaultTests =>
        new() { ["type"] = "button", ["aria-expanded"] = "false" };

    protected override string ClassesForDefaultTests => "btn-primary";

    protected override void BindParameters(ComponentParameterCollectionBuilder<BsDropdownToggle> parameterBuilder)
    {
        base.BindParameters(parameterBuilder);
        _ = parameterBuilder.Add(p => p.Variant, BsButtonVariant.Primary);
    }

    [Theory]
    [InlineData(BsDropdownMode.Regular, "")]
    [InlineData(BsDropdownMode.Split, "dropdown-toggle-split")]
    public void ModeAddsCorrectClass(BsDropdownMode dropdownMode, string? expectedClass)
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = GetCut(parameters => parameters.AddCascadingValue(dropdownMode));

        // Assert
        var expectedMarkupString = GetExpectedHtml(
            $"{ClassesForDefaultTests} {expectedClass}",
            AttributesForDefaultTests
        );
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void OutlineToggleAddsCorrectClass()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = Render<BsDropdownToggle>(parameters =>
            parameters.Add(p => p.OutlineVariant, BsButtonOutlineVariant.Primary)
        );

        // Assert
        var expectedMarkupString = GetExpectedHtml("btn-outline-primary", AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void SettingBothVariablesPrefersNonOutline()
    {
        // Arrange
        ConfigureTestContext();

        // Act
        var cut = Render<BsDropdownToggle>(parameters =>
            parameters
                .Add(p => p.OutlineVariant, BsButtonOutlineVariant.Primary)
                .Add(p => p.Variant, BsButtonVariant.Primary)
        );

        // Assert
        var expectedMarkupString = GetExpectedHtml(ClassesForDefaultTests, AttributesForDefaultTests);
        cut.MarkupMatches(expectedMarkupString);
    }

    [Fact]
    public void SettingBothVariablesNullThrowsException()
    {
        // Arrange
        ConfigureTestContext();

        // Act + Assert
        _ = Assert.Throws<BsMissingParameterException>(() =>
            Render<BsDropdownToggle>(parameters =>
                parameters.Add(p => p.OutlineVariant, null).Add(p => p.Variant, null)
            )
        );
    }

    [Fact]
    public void ButtonTypeCanBeOverriden()
    {
        TestForAllowingOverride("type");
    }

    [Fact]
    public void AriaExpandedCanBeOverriden()
    {
        TestForAllowingOverride("aria-expanded");
    }

    [Fact]
    public void DataBsToggleCannotBeOverridden()
    {
        TestForDisallowingOverride("data-bs-toggle");
    }

    protected override void ConfigureTestContext()
    {
        _ = Services.AddSingleton(_buttonJsFunctionsMock);
    }
}
