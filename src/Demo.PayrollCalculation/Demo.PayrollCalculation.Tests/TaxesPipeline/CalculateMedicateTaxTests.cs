using Demo.PayrollCalculation.EarningsPipeline;
using Demo.PayrollCalculation.TaxesPipeline;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.PayrollCalculation.Tests.TaxesPipeline
{
    [TestFixture]
    public class CalculateMedicateTaxTests
    { 
        [TestCase(.1, .01, 100, 90, 5, 9.5, Description = "Under threshold")]
        [TestCase(.1, .01, 100, 95, 5, 10, Description = "At threshold")]
        [TestCase(.1, .01, 100, 100, 15, 11.65, Description = "Above threshold")]
        public async Task given_ytdearningspluspayrunearnings_greaterthan_threshold_when_calculating_then_should_use_rate1_and_rate2(
            decimal rate1, decimal rate2, decimal threshold, decimal ytdEarnings, decimal payrunEarnings, decimal expected)
        {
            var repository = Substitute.For<ITaxRateRepository>();
            var info = new MedicareTaxInfo { Rate1 = rate1, Rate2 = rate2, Rate2Threshold = threshold };

            repository.GetMedicareTaxInfo().Returns(info);

            var calculator = new CalculateMedicareTax(repository);
            var context = new PaycheckContext();

            context.Earnings.Add(new Earning { Amount = payrunEarnings });
            context.Earnings.YTD = ytdEarnings;
            var result = await calculator.ExecuteAsync(context, CancellationToken.None);

            var medicareTax = result.Taxes.SingleOrDefault(x => x.Type == TaxType.Medicare);
            medicareTax.Should().NotBeNull();
            medicareTax.Value.Should().Be(expected);
        }
    }
}
