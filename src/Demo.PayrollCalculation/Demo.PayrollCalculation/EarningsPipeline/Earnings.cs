using System.Collections.Generic;
using System.Linq;

namespace Demo.PayrollCalculation.EarningsPipeline
{
    public class Earnings : List<Earning>
    {
        public Earnings(List<Earning> earnings)
            : base(earnings)
        { }

        public decimal Total
        {
            get { return this.Sum(x => x.Amount); }
        }

        public decimal YTD { get; set; }
    }
}
