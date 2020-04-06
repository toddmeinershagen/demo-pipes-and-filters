using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.TaxesPipeline
{
    public class CalculateRemainingTaxesAsMonolith : AsyncFilterBase<PaycheckContext>
    {
        protected override Task<PaycheckContext> OnExecuteAsync(PaycheckContext input, CancellationToken cancellationToken)
        {
            input = Method1(input);
            input = Method2(input);
            input = Method3(input);

            return Task.FromResult(input);
        }

        public PaycheckContext Method1(PaycheckContext context)
        {
            return context;
        }

        public PaycheckContext Method2(PaycheckContext context)
        {
            return context;
        }

        public PaycheckContext Method3(PaycheckContext context)
        {
            return context;
        }
    }
}
