using Wader.Bootstrap.Forms.Validation;

namespace Wader.Bootstrap.Tests.Forms.Validation;

public class BsFieldCssClassProviderTests
{
    public static TheoryData<
        BsFieldCssClassProvider.InteractionMode,
        ValidationMessageShowMode,
        bool
    > BsFieldCssClassProviderTestsData =>
        [
            (BsFieldCssClassProvider.InteractionMode.Touched, ValidationMessageShowMode.Never, false),
            (BsFieldCssClassProvider.InteractionMode.Touched, ValidationMessageShowMode.WhenTouched, true),
            (BsFieldCssClassProvider.InteractionMode.Touched, ValidationMessageShowMode.WhenModified, false),
            (BsFieldCssClassProvider.InteractionMode.Touched, ValidationMessageShowMode.WhenTouchedOrModified, true),
            (BsFieldCssClassProvider.InteractionMode.Modified, ValidationMessageShowMode.Never, false),
            (BsFieldCssClassProvider.InteractionMode.Modified, ValidationMessageShowMode.WhenTouched, false),
            (BsFieldCssClassProvider.InteractionMode.Modified, ValidationMessageShowMode.WhenModified, true),
            (BsFieldCssClassProvider.InteractionMode.Modified, ValidationMessageShowMode.WhenTouchedOrModified, true),
        ];

    [Theory]
    [MemberData(nameof(BsFieldCssClassProviderTestsData))]
    public void FieldCssClassProvider_ShowsInvalidClass_WhenInteractionSpecified(
        BsFieldCssClassProvider.InteractionMode interaction,
        ValidationMessageShowMode invalidMessagesMode,
        bool showCssClass
    )
    {
        // Arrange
        var sut = new BsFieldCssClassProvider(invalidMessages: invalidMessagesMode);
        var expectedClass = showCssClass ? "is-invalid" : "";

        // Act
        var res = sut.DetermineClass(isInvalid: true, interaction);

        // Assert
        Assert.Equal(expectedClass, res);
    }

    [Theory]
    [MemberData(nameof(BsFieldCssClassProviderTestsData))]
    public void FieldCssClassProvider_ShowsValidClass_WhenInteractionSpecified(
        BsFieldCssClassProvider.InteractionMode interaction,
        ValidationMessageShowMode invalidMessagesMode,
        bool showCssClass
    )
    {
        // Arrange
        var sut = new BsFieldCssClassProvider(validMessages: invalidMessagesMode);
        var expectedClass = showCssClass ? "is-valid" : "";

        // Act
        var res = sut.DetermineClass(isInvalid: false, interaction);

        // Assert
        Assert.Equal(expectedClass, res);
    }
}
