namespace MySimpleCalculator.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class CalculatorEx
    {
        public static IServiceCollection AddCalculatorService(this IServiceCollection services)
        {
            services.AddSingleton<ICalculator, Calculator>();

            return services;
        }
    }
}
