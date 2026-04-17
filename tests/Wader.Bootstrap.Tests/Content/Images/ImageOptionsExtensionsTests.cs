using Wader.Bootstrap.Content.Images;

namespace Wader.Bootstrap.Tests.Content.Images;

public class ImageOptionsExtensionsTests
{
    [Theory]
    [InlineData(BsImageOptions.None, "")]
    [InlineData(BsImageOptions.Fluid, "img-fluid")]
    [InlineData(BsImageOptions.Thumbnail, "img-thumbnail")]
    [InlineData(BsImageOptions.Rounded, "rounded")]
    [InlineData(BsImageOptions.Figure, "figure-img")]
    [InlineData(BsImageOptions.Fluid | BsImageOptions.Rounded, "img-fluid rounded")]
    [InlineData(BsImageOptions.Thumbnail | BsImageOptions.Figure, "img-thumbnail figure-img")]
    [InlineData(
        BsImageOptions.Fluid | BsImageOptions.Thumbnail | BsImageOptions.Rounded | BsImageOptions.Figure,
        "img-fluid img-thumbnail rounded figure-img"
    )]
    public void ImageOptionsGeneratesCorrectClasses(BsImageOptions imageOptions, string? expectedClass)
    {
        var generatedClass = imageOptions.ToBootstrapClass();
        Assert.Equal(expectedClass, generatedClass);
    }
}
