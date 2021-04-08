namespace App1 {
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public static class Startup {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init() {
            var serviceProvider =
                new ServiceCollection().ConfigureServices().BuildServiceProvider();
            ServiceProvider = serviceProvider;

            return serviceProvider;
        }

    }
}