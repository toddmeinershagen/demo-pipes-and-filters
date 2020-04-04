using Patterns.PipesAndFilters;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.TaxesPipeline
{
    public class CalculateMedicareTax : AsyncFilterBase<PaycheckContext>
    {
        private readonly ITaxRateRepository _repository;

        public CalculateMedicareTax(ITaxRateRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<PaycheckContext> OnExecuteAsync(PaycheckContext input, CancellationToken cancellationToken)
        {
            var info = await _repository.GetMedicareTaxInfo();
            var ytdPlusCheck = input.Earnings.YTD + input.Earnings.Total;
            var tax = input.Earnings.Total * info.Rate1;

            var additionalAmount = ytdPlusCheck - info.Rate2Threshold;
            if (additionalAmount > 0)
            {
                tax += input.Earnings.Total * info.Rate2;
            }

            input.Taxes.Add(new Tax { Type = TaxType.Medicare, Value = tax });

            return input;
        }
    }
}
