using Demo.PayrollCalculation.BenefitsPipeline;
using Demo.PayrollCalculation.DeductionsPipeline;
using Demo.PayrollCalculation.EarningsPipeline;
using Demo.PayrollCalculation.TaxesPipeline;
using System.Collections.Generic;

namespace Demo.PayrollCalculation
{
    public class PaycheckContext
    {
        public PaycheckContext(EmployeeInfo employeeInfo, Earnings earnings, Deductions deductions, Taxes taxes, Benefits benefits)
        {
            EmployeeInfo = employeeInfo;
            Earnings = earnings;
            Deductions = deductions;
            Taxes = taxes;
            Benefits = benefits;
        }

        public PaycheckContext()
            : this (
                  new EmployeeInfo(), 
                  new Earnings(new List<Earning>()), 
                  new Deductions(new List<Deduction>()), 
                  new Taxes(new List<Tax>()),
                  new Benefits(new List<Benefit>()))
        { }

        public EmployeeInfo EmployeeInfo { get; }
        public Earnings Earnings { get; }
        public Deductions Deductions { get; }
        public Taxes Taxes { get; }
        public Benefits Benefits { get; }
    }
}
