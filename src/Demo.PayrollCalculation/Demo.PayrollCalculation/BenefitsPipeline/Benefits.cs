using System.Collections.Generic;

namespace Demo.PayrollCalculation.BenefitsPipeline
{
    public class Benefits : List<Benefit>
    {
        public Benefits(List<Benefit> benefits)
            : base(benefits)
        { }
    }
}
