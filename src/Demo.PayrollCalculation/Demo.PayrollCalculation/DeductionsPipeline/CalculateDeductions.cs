using Patterns.PipesAndFilters;

namespace Demo.PayrollCalculation.DeductionsPipeline
{
    public class CalculateDeductions : Pipeline<PaycheckContext>
    {
        public CalculateDeductions(IServiceProvider provider)
            : base(provider)
        {
            this.Add<CalculateRemainingDeductionsAsMonolith>();
        }
    }
}
