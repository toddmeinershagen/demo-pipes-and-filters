using Microsoft.Extensions.DependencyInjection;
using Patterns.PipesAndFilters;

namespace Demo.PayrollCalculation.Tests
{
    public class MicrosoftServiceProvider : IServiceProvider
    {
        private readonly ServiceProvider _provider;

        public MicrosoftServiceProvider(ServiceProvider provider)
        {
            _provider = provider;
        }

        public T GetService<T>()
        {
            return _provider.GetService<T>();
        }
    }
}