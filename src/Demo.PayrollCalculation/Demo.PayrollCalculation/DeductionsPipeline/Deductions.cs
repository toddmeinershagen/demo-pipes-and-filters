using System.Collections.Generic;

namespace Demo.PayrollCalculation.DeductionsPipeline
{
    public class Deductions : List<Deduction>
    {
        public Deductions(List<Deduction> deductions)
            : base(deductions)
        { }
    }
}
