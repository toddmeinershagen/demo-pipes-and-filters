using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.EarningsPipeline
{
    public class CalculateEarnings : Pipeline<PaycheckContext>
    {
        public CalculateEarnings(IServiceProvider provider)
            : base(provider)
        {
            //add filters
        }
    }
}
