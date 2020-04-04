using Demo.PayrollCalculation.BenefitsPipeline;
using Demo.PayrollCalculation.DeductionsPipeline;
using Demo.PayrollCalculation.EarningsPipeline;
using Demo.PayrollCalculation.TaxesPipeline;
using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation
{
    public class PaycheckCalculator
    {
        private readonly IServiceProvider _provider;

        public PaycheckCalculator(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// Calculates the paycheck for a given Employee.
        /// </summary>
        /// <remarks>
        /// Assume that the EmployeeContext is already loaded at this point by a repository and it is sent in along with Earnings from paygrid.
        /// </remarks>
        /// <param name="context">The context of the paycheck that will be fully calculated at this end of this calculation.</param>
        /// <param name="cancellationToken">A token that can be used to signal to the Calculator to stop during shut down or failure.</param>
        /// <returns></returns>
        public async Task<PaycheckContext> Calculate(PaycheckContext context, CancellationToken cancellationToken = default)
        {
            var calculator = new Pipeline<PaycheckContext>(_provider);
            calculator
                .Add<CalculateEarnings>()
                .Add<CalculateBenefits>()
                .Add<CalculateTaxes>()
                .Add<CalculateDeductions>();

            return await calculator.ExecuteAsync(context, cancellationToken);
        }
    }
}
