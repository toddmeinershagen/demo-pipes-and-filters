using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.DeductionsPipeline
{
    public class CalculateDeductions : AsyncFilterBase<PaycheckContext>
    {
        protected override async Task<PaycheckContext> OnExecuteAsync(PaycheckContext input, CancellationToken cancellationToken)
        {
            return await Task.FromResult(input);
        }
    }
}
