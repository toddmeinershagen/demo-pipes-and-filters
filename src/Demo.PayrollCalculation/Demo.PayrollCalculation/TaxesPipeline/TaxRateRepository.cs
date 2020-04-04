using System.Threading.Tasks;

namespace Demo.PayrollCalculation.TaxesPipeline
{
    public class TaxRateRepository : ITaxRateRepository
    {
        public async Task<MedicareTaxInfo> GetMedicareTaxInfo()
        {
            //imagine db call
            var info = new MedicareTaxInfo { Rate1 = .0145m, Rate2 = .009m, Rate2Threshold = 200000 };
            return await Task.FromResult(info);
        }
    }
}
