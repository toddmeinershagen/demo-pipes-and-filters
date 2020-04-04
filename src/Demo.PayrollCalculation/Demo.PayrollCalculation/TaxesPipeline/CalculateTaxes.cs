using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.TaxesPipeline
{
    public class CalculateTaxes : AsyncFilterBase<PaycheckContext>
    {
        private readonly IServiceProvider _provider;

        public CalculateTaxes(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task<PaycheckContext> OnExecuteAsync(PaycheckContext input, CancellationToken cancellationToken)
        {
            var taxCalculator = new Pipeline<PaycheckContext>(_provider)
                .Add<CalculateMedicareTax>();
            return await taxCalculator.ExecuteAsync(input);
        }
    }
}
