using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.DeductionsPipeline
{
    public class CalculateDeductions : Pipeline<PaycheckContext>
    {
        public CalculateDeductions(IServiceProvider provider)
            : base(provider)
        {
            //add filters
        }
    }
}
