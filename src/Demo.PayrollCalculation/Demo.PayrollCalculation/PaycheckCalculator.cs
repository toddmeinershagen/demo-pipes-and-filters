using Demo.PayrollCalculation.BenefitsPipeline;
using Demo.PayrollCalculation.DeductionsPipeline;
using Demo.PayrollCalculation.EarningsPipeline;
using Demo.PayrollCalculation.TaxesPipeline;
using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation
{
    public class PaycheckCalculator : Pipeline<PaycheckContext>
    {
        public PaycheckCalculator(IServiceProvider provider)
            : base(provider)
        {
            this
                .Add<CalculateEarnings>()
                .Add<CalculateBenefits>()
                .Add<CalculateTaxes>()
                .Add<CalculateDeductions>();
        }
    }
}
