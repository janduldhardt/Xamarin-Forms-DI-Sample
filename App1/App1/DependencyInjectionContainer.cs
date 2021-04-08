namespace App1 {
    using Api;
    using Microsoft.Extensions.DependencyInjection;
    using ViewModels;

    public static class DependencyInjectionContainer
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // services.AddSingleton<IRestService, RestService>();
        services.AddSingleton<IRestService, FakeRestService>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<TrackingViewModel>();
        return services;
    }
}
}