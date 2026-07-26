namespace Wader.Bootstrap.Tests.TestUtilities;

public static class AssertExtensions
{
    extension(Assert)
    {
        public static void DoesNotThrow(Func<object> testCode)
        {
            var exception = Record.Exception(testCode);

            Assert.Null(exception);
        }
    }
}
