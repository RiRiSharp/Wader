using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Wader.Bootstrap.Components.Accordion.Internals;
using Wader.Bootstrap.Components.Alert.Internals;
using Wader.Bootstrap.Components.Buttons.Internals;
using Wader.Bootstrap.Components.Carousel.Internals;
using Wader.Bootstrap.Components.Collapse.Internals;
using Wader.Bootstrap.Components.Modal.Internals;
using Wader.Bootstrap.Components.Offcanvas.Internals;
using Wader.Bootstrap.Forms.ChecksRadios.Internals;
using Wader.Bootstrap.Internals;

namespace Wader.Bootstrap;

public static class BsStartupExtensions
{
    public static IServiceCollection AddWaderServerJsFallbacks(this IServiceCollection services)
    {
        return services
            .AddNoOpJs<IBsAccordionJsFunctions>()
            .AddNoOpJs<IBsAlertJsFunctions>()
            .AddNoOpJs<IBsButtonJsFunctions>()
            .AddNoOpJs<IBsCarouselJsFunctions>()
            .AddNoOpJs<IBsCheckboxJsFunctions>()
            .AddNoOpJs<IBsCollapseJsFunctions>()
            .AddNoOpJs<IBsModalJsFunctions>()
            .AddNoOpJs<IBsOffcanvasJsFunctions>();
    }

    public static IServiceCollection AddWaderWasmJsInterop(this IServiceCollection services)
    {
        return services
            .AddBootstrapJs<IBsAccordionJsFunctions, BsAccordionJsFunctions>()
            .AddBootstrapJs<IBsAlertJsFunctions, BsAlertJsFunctions>()
            .AddBootstrapJs<IBsButtonJsFunctions, BsButtonJsFunctions>()
            .AddBootstrapJs<IBsCarouselJsFunctions, BsCarouselJsFunctions>()
            .AddBootstrapJs<IBsCheckboxJsFunctions, BsCheckboxJsFunctions>()
            .AddBootstrapJs<IBsCollapseJsFunctions, BsCollapseJsFunctions>()
            .AddBootstrapJs<IBsModalJsFunctions, BsModalJsFunctions>()
            .AddBootstrapJs<IBsOffcanvasJsFunctions, BsOffcanvasJsFunctions>();
    }

    private static IServiceCollection AddBootstrapJs<TService, TImpl>(this IServiceCollection services)
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
