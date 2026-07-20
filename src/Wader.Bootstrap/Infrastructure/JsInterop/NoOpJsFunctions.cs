using System.Reflection;

// Non-generic outer facade to satisfy CA1000
namespace Wader.Bootstrap.Infrastructure.JsInterop;

public static class NoOpJsFunctions
{
    public static T Create<T>()
        where T : class
    {
        return DispatchProxy.Create<T, NoOpJsFunctionsDispatchProxy>();
    }

    private class NoOpJsFunctionsDispatchProxy : DispatchProxy
    {
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            if (targetMethod is null)
            {
                return null;
            }

            var returnType = targetMethod.ReturnType;

            // Task
            if (returnType == typeof(Task))
            {
                return Task.CompletedTask;
            }

            // Task<T>
            if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                var t = returnType.GenericTypeArguments[0];
                var defaultValue = t.IsValueType ? Activator.CreateInstance(t) : null;

                // Task.FromResult<T>(default(T))
                var taskFromResult = typeof(Task)
                    .GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .First(m => m is { Name: nameof(Task.FromResult), IsGenericMethod: true })
                    .MakeGenericMethod(t);

                return taskFromResult.Invoke(obj: null, [defaultValue]);
            }

            // void or reference returns → null, value returns → default
            if (returnType == typeof(void))
            {
                return null;
            }

            return returnType.IsValueType ? Activator.CreateInstance(returnType) : null;
        }
    }
}
