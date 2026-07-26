using Wader.Bootstrap.Forms.Validation;

namespace Wader.Bootstrap.Tests.Forms.Validation;

public class BsEditContextBuilderTests
{
    [Fact]
    public void DoesNotThrowException()
    {
        // Arrange
        var obj = new TestObject();

        // Act
        var exception = Record.Exception(() => BsEditContextBuilder.Build(obj));

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void SetsForCorrectObject()
    {
        // Arrange
        var obj = new TestObject();

        // Act
        var sut = BsEditContextBuilder.Build(obj);

        // Assert
        Assert.Equal(obj, sut.Model);
    }

    private sealed class TestObject
    {
        public string? SomeProperty { get; set; }
    }
}
