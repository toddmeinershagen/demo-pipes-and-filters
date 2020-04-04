using System.Threading.Tasks;

namespace Demo.PayrollCalculation.TaxesPipeline
{
    public interface ITaxRateRepository
    {
        Task<MedicareTaxInfo> GetMedicareTaxInfo();
    }
}