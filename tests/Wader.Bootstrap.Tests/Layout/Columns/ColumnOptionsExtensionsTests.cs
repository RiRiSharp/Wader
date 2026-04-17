using Wader.Bootstrap.Layout.Columns;

namespace Wader.Bootstrap.Tests.Layout.Columns;

public class ColumnOptionsExtensionsTests
{
    [Theory]
    [InlineData(BsColumnOptions.Sm, "col-sm")]
    [InlineData(BsColumnOptions.Md, "col-md")]
    [InlineData(BsColumnOptions.Lg, "col-lg")]
    [InlineData(BsColumnOptions.Xl, "col-xl")]
    [InlineData(BsColumnOptions.Xxl, "col-xxl")]
    public void ColumnBreakpointOptionsGenerateCorrectClass(
        BsColumnOptions breakpointColumnOptions,
        string? expectedClass
    )
    {
        var generatedClass = breakpointColumnOptions.ToBootstrapColClass();
        Assert.Equal(expectedClass, generatedClass);
    }

    [Theory]
    [InlineData(BsColumnOptions.Col1, "col-1")]
    [InlineData(BsColumnOptions.Col2, "col-2")]
    [InlineData(BsColumnOptions.Col3, "col-3")]
    [InlineData(BsColumnOptions.Col4, "col-4")]
    [InlineData(BsColumnOptions.Col5, "col-5")]
    [InlineData(BsColumnOptions.Col6, "col-6")]
    [InlineData(BsColumnOptions.Col7, "col-7")]
    [InlineData(BsColumnOptions.Col8, "col-8")]
    [InlineData(BsColumnOptions.Col9, "col-9")]
    [InlineData(BsColumnOptions.Col10, "col-10")]
    [InlineData(BsColumnOptions.Col11, "col-11")]
    [InlineData(BsColumnOptions.Col12, "col-12")]
    [InlineData(BsColumnOptions.ColAuto, "col-auto")]
    public void ColumnWidthOptionsGenerateCorrectClass(BsColumnOptions columnWidthOptions, string? expectedClass)
    {
        var generatedClass = columnWidthOptions.ToBootstrapColClass();
        Assert.Equal(expectedClass, generatedClass);
    }

    [Theory]
    [InlineData(BsColumnOptions.ColSm4, "col-sm-4")]
    [InlineData(BsColumnOptions.ColMd4, "col-md-4")]
    [InlineData(BsColumnOptions.ColMd12, "col-md-12")]
    [InlineData(BsColumnOptions.ColLgAuto, "col-lg-auto")]
    [InlineData(BsColumnOptions.ColLg7, "col-lg-7")]
    [InlineData(BsColumnOptions.ColXl7, "col-xl-7")]
    [InlineData(BsColumnOptions.ColXxl1, "col-xxl-1")]
    public void ComposedColumnOptionsGenerateCorrectClass(BsColumnOptions composedOptions, string? expectedClass)
    {
        var generatedClass = composedOptions.ToBootstrapColClass();
        Assert.Equal(expectedClass, generatedClass);
    }

    [Theory]
    [InlineData(BsColumnOptions.Sm, "offset-sm")]
    [InlineData(BsColumnOptions.Md, "offset-md")]
    [InlineData(BsColumnOptions.Lg, "offset-lg")]
    [InlineData(BsColumnOptions.Xl, "offset-xl")]
    [InlineData(BsColumnOptions.Xxl, "offset-xxl")]
    public void OffsetBreakpointOptionsGenerateCorrectClass(
        BsColumnOptions breakpointColumnOptions,
        string? expectedClass
    )
    {
        var generatedClass = breakpointColumnOptions.ToBootstrapOffsetClass();
        Assert.Equal(expectedClass, generatedClass);
    }

    [Theory]
    [InlineData(BsColumnOptions.Col1, "offset-1")]
    [InlineData(BsColumnOptions.Col2, "offset-2")]
    [InlineData(BsColumnOptions.Col3, "offset-3")]
    [InlineData(BsColumnOptions.Col4, "offset-4")]
    [InlineData(BsColumnOptions.Col5, "offset-5")]
    [InlineData(BsColumnOptions.Col6, "offset-6")]
    [InlineData(BsColumnOptions.Col7, "offset-7")]
    [InlineData(BsColumnOptions.Col8, "offset-8")]
    [InlineData(BsColumnOptions.Col9, "offset-9")]
    [InlineData(BsColumnOptions.Col10, "offset-10")]
    [InlineData(BsColumnOptions.Col11, "offset-11")]
    [InlineData(BsColumnOptions.Col12, "offset-12")]
    [InlineData(BsColumnOptions.ColAuto, "offset-auto")]
    public void OffsetWidthOptionsGenerateCorrectClass(BsColumnOptions columnWidthOptions, string? expectedClass)
    {
        var generatedClass = columnWidthOptions.ToBootstrapOffsetClass();
        Assert.Equal(expectedClass, generatedClass);
    }

    [Theory]
    [InlineData(BsColumnOptions.ColSm4, "offset-sm-4")]
    [InlineData(BsColumnOptions.ColMd4, "offset-md-4")]
    [InlineData(BsColumnOptions.ColMd12, "offset-md-12")]
    [InlineData(BsColumnOptions.ColLgAuto, "offset-lg-auto")]
    [InlineData(BsColumnOptions.ColLg7, "offset-lg-7")]
    [InlineData(BsColumnOptions.ColXl7, "offset-xl-7")]
    [InlineData(BsColumnOptions.ColXxl1, "offset-xxl-1")]
    public void ComposedOffsetOptionsGenerateCorrectClass(BsColumnOptions composedOptions, string? expectedClass)
    {
        var generatedClass = composedOptions.ToBootstrapOffsetClass();
        Assert.Equal(expectedClass, generatedClass);
    }
}
