using Wader.Bootstrap.Layout.GridColumns;

namespace Wader.Bootstrap.UnitTests.Layout.GridColumns;

public class GridStartOptionsExtensionsTests
{
    [Theory]
    [InlineData(BsGridStartOptions.Start1, "g-start-1")]
    [InlineData(BsGridStartOptions.Start2, "g-start-2")]
    [InlineData(BsGridStartOptions.Start3, "g-start-3")]
    [InlineData(BsGridStartOptions.Start4, "g-start-4")]
    [InlineData(BsGridStartOptions.Start5, "g-start-5")]
    [InlineData(BsGridStartOptions.Start6, "g-start-6")]
    [InlineData(BsGridStartOptions.Start7, "g-start-7")]
    [InlineData(BsGridStartOptions.Start8, "g-start-8")]
    [InlineData(BsGridStartOptions.Start9, "g-start-9")]
    [InlineData(BsGridStartOptions.Start10, "g-start-10")]
    [InlineData(BsGridStartOptions.Start11, "g-start-11")]
    [InlineData(BsGridStartOptions.Start12, "g-start-12")]
    public void ColWidthsWork(BsGridStartOptions gridStartOptions, string? expectedClass)
    {
        var generatedClass = gridStartOptions.ToBootstrapClass();
        Assert.Equal(expectedClass, generatedClass);
    }
}
