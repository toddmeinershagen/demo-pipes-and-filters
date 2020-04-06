using Patterns.PipesAndFilters;

namespace Demo.PayrollCalculation.BenefitsPipeline
{
    public class CalculateBenefits : Pipeline<PaycheckContext>
    {
        public CalculateBenefits(IServiceProvider provider)
        {
            this.Add<CalculateRemainingBenefitsAsMonolith>();
        }
    }
}
