using Microsoft.JSInterop;
using NSubstitute;

namespace Wader.Bootstrap.Tests;

public static class AssertJsInterop
{
    public static void Calls(IJSObjectReference jsObj, string expectedIdentifier, params object[] expectedArgs)
    {
        var calls = jsObj.ReceivedCalls().ToList();
        _ = Assert.Single(calls);

        var call = calls.Single();
        Assert.Equal(expectedIdentifier, call.GetArguments()[0]);
        Assert.Equal(expectedArgs, (IEnumerable<object>)call.GetArguments()[1]!);
    }

    public static async Task DisposeDisposesUnderlyingJsReferenceAsync(IAsyncDisposable sut, IJSObjectReference jsObj)
    {
        // Act
        await sut.DisposeAsync();

        // Assert
        await jsObj.Received(1).DisposeAsync();
    }
}
