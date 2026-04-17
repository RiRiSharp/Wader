using Wader.Bootstrap.Content.Abbreviations;

namespace Wader.Bootstrap.Tests.Content.Abbreviations;

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
