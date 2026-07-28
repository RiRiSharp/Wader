using Microsoft.JSInterop;

namespace Wader.Bootstrap.Internal.JsInterop;

internal class BsJsObjectReference : IJSObjectReference
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    internal BsJsObjectReference(IJSRuntime jsRuntime, string filePath)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(() =>
            jsRuntime.InvokeAsync<IJSObjectReference>(identifier: "import", filePath).AsTask()
        );
    }

    public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, params object?[]? args)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<TValue>(identifier, args);
    }

    public async ValueTask<TValue> InvokeAsync<TValue>(
        string identifier,
        CancellationToken cancellationToken,
        object?[]? args
    )
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<TValue>(identifier, cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }

    private async Task Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        if (!_moduleTask.IsValueCreated)
        {
            return;
        }

        var module = await _moduleTask.Value;
        await module.DisposeAsync();
    }
}
