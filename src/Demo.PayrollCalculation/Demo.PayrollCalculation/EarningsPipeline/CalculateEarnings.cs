using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.EarningsPipeline
{
    public class CalculateEarnings : AsyncFilterBase<PaycheckContext>
    {
        private readonly IServiceProvider _provider;

        public CalculateEarnings(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task<PaycheckContext> OnExecuteAsync(PaycheckContext input, CancellationToken cancellationToken)
        {
            var pipeline = new Pipeline<PaycheckContext>(_provider);
            return await pipeline.ExecuteAsync(input, cancellationToken);
        }
    }
}
