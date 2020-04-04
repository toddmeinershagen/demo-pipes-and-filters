using System.Collections.Generic;

namespace Demo.PayrollCalculation.TaxesPipeline
{
    public class Taxes : List<Tax>
    {
        public Taxes(List<Tax> taxes)
            : base(taxes)
        { }
    }
}
