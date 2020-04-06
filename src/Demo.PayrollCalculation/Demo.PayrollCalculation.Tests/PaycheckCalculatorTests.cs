using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Patterns.PipesAndFilters;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.Tests
{
    [TestFixture]
    public class PaycheckCalculatorTests
    {
        [Test]
        public async Task given_paycheckcontext_with_employeeinfo_when_calculating_then_return_check()
        {
            //This is just a sample of what it would look like in production code to use a real IoC container.
            var services = new ServiceCollection();
            services.Scan(x => x.FromAssemblyOf<PaycheckCalculator>());
            services.Scan(x => 
                x.FromAssemblyOf<PaycheckCalculator>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            services.AddSingleton<IServiceProvider>(x => new MicrosoftServiceProvider(services.BuildServiceProvider()));
            var provider = services.BuildServiceProvider();

            var context = new PaycheckContext();
            var calculator = provider.GetService<PaycheckCalculator>();
            var result = await calculator.ExecuteAsync(context);

            result.Should().BeEquivalentTo(context);
        }
    }
}