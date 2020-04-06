using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.TaxesPipeline
{
    public class CalculateTaxes : Pipeline<PaycheckContext>
    {
        public CalculateTaxes(IServiceProvider provider)
            : base(provider)
        {
            this
                .Add<CalculateMedicareTax>();
        }
    }
}
