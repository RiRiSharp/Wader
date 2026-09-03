using Wader.Bootstrap.Content.Typography.Abbreviations;

namespace Wader.Bootstrap.Tests.Content.Typography.Abbreviations;

public class AbbreviationTypeExtensionsTests
{
    [Theory]
    [InlineData(BsAbbreviationType.Default, null)]
    [InlineData(BsAbbreviationType.Initialism, "initialism")]
    public void AbbreviationTypeGeneratesCorrectClass(BsAbbreviationType abbreviationType, string? expectedClass)
    {
        var generatedClass = abbreviationType.ToBootstrapClass();

        Assert.Equal(expectedClass, generatedClass);
    }
}
