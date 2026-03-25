using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Components.Alert.Internals;
using Wader.Bootstrap.Components.Buttons.Internals;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Components.Collapse.Internals;
using Wader.Bootstrap.Components.Modal.Internals;
using Wader.Bootstrap.Components.Offcanvas.Internals;
using Wader.Bootstrap.Components.Popover.Internals;
using Wader.Bootstrap.Forms.ChecksRadios.Internals;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap;

public static class BsStartupExtensions
{
    public static IServiceCollection AddWaderServerJsFallbacks(this IServiceCollection services)
    {
        return services.AddWaderJs(true);
    }

    public static IServiceCollection AddWaderWasmJsInterop(this IServiceCollection services)
    {
        return services.AddWaderJs(false);
    }

    private static IServiceCollection AddWaderJs(this IServiceCollection services, bool useNoOp)
    {
        return services
            .AddWaderJsSingle<IBsAccordionJsFunctions, BsAccordionJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsAlertJsFunctions, BsAlertJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsButtonJsFunctions, BsButtonJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsCarouselJsFunctions, BsCarouselJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsCheckboxJsFunctions, BsCheckboxJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsCollapseJsFunctions, BsCollapseJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsModalJsFunctions, BsModalJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsOffcanvasJsFunctions, BsOffcanvasJsFunctions>(useNoOp)
            .AddWaderJsSingle<IBsPopoverJsFunctions, BsPopoverJsFunctions>(useNoOp);
    }

    private static IServiceCollection AddWaderJsSingle<TService, TImpl>(this IServiceCollection services, bool useNoOp)
        where TService : class
        where TImpl : class, TService, IBsJsFunctionsWrapper
    {
        return useNoOp ? services.AddNoOpJs<TService>() : services.AddFunctionalJs<TService, TImpl>();
    }

    private static IServiceCollection AddFunctionalJs<TService, TImpl>(this IServiceCollection services)
        where TService : class
        where TImpl : class, TService, IBsJsFunctionsWrapper
    {
        var filePath = $"./_content/{typeof(TImpl).Assembly.GetName().Name}/js/{TImpl.JsFileName}";
        return services.AddSingleton<TService>(sp =>
        {
            var jsRuntime = sp.GetRequiredService<IJSRuntime>();
            var bsJsObjectRef = new BsJsObjectReference(jsRuntime, filePath);
            return ActivatorUtilities.CreateInstance<TImpl>(sp, bsJsObjectRef);
        });
    }

    private static IServiceCollection AddNoOpJs<T>(this IServiceCollection services)
        where T : class
    {
        return services.AddScoped<T>(_ => NoOpJsFunctions.Create<T>());
    }
}
