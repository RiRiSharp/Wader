using Wader.Bootstrap.Layout.GridColumns;

namespace Wader.Bootstrap.UnitTests.Layout.GridColumns;

public class GridColumnOptionsExtensionsTests
{
    [Theory]
    [InlineData(BsGridColumnOptions.Sm, "g-col-sm")]
    [InlineData(BsGridColumnOptions.Md, "g-col-md")]
    [InlineData(BsGridColumnOptions.Lg, "g-col-lg")]
    [InlineData(BsGridColumnOptions.Xl, "g-col-xl")]
    [InlineData(BsGridColumnOptions.Xxl, "g-col-xxl")]
    public void GridBreakpointGenerateCorrectClass(BsGridColumnOptions gridColumnOptions, string? expectedClass)
    {
        var generatedClass = gridColumnOptions.ToBootstrapClass();
        Assert.Equal(expectedClass, generatedClass);
    }

    [Theory]
    [InlineData(BsGridColumnOptions.GCol1, "g-col-1")]
    [InlineData(BsGridColumnOptions.GCol2, "g-col-2")]
    [InlineData(BsGridColumnOptions.GCol3, "g-col-3")]
    [InlineData(BsGridColumnOptions.GCol4, "g-col-4")]
    [InlineData(BsGridColumnOptions.GCol5, "g-col-5")]
    [InlineData(BsGridColumnOptions.GCol6, "g-col-6")]
    [InlineData(BsGridColumnOptions.GCol7, "g-col-7")]
    [InlineData(BsGridColumnOptions.GCol8, "g-col-8")]
    [InlineData(BsGridColumnOptions.GCol9, "g-col-9")]
    [InlineData(BsGridColumnOptions.GCol10, "g-col-10")]
    [InlineData(BsGridColumnOptions.GCol11, "g-col-11")]
    [InlineData(BsGridColumnOptions.GCol12, "g-col-12")]
    [InlineData(BsGridColumnOptions.GColAuto, "g-col-auto")]
    public void GridColumnWidthsGenerateCorrectClass(BsGridColumnOptions gridColumnOptions, string? expectedClass)
    {
        var generatedClass = gridColumnOptions.ToBootstrapClass();
        Assert.Equal(expectedClass, generatedClass);
    }

    [Theory]
    [InlineData(BsGridColumnOptions.GColSm4, "g-col-sm-4")]
    [InlineData(BsGridColumnOptions.GColMd4, "g-col-md-4")]
    [InlineData(BsGridColumnOptions.GColMd12, "g-col-md-12")]
    [InlineData(BsGridColumnOptions.GColLgAuto, "g-col-lg-auto")]
    [InlineData(BsGridColumnOptions.GColLg7, "g-col-lg-7")]
    [InlineData(BsGridColumnOptions.GColXl7, "g-col-xl-7")]
    [InlineData(BsGridColumnOptions.GColXxl1, "g-col-xxl-1")]
    public void ComposedGridColumnOptionsGenerateCorrectClass(
        BsGridColumnOptions gridColumnOptions,
        string? expectedClass
    )
    {
        var generatedClass = gridColumnOptions.ToBootstrapClass();
        Assert.Equal(expectedClass, generatedClass);
    }
}
