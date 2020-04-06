using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.BenefitsPipeline
{
    public class CalculateBenefits : Pipeline<PaycheckContext>
    {
        public CalculateBenefits(IServiceProvider provider)
        {
            //add filters
        }
    }
}
