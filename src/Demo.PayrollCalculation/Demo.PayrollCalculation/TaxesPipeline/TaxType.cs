namespace Demo.PayrollCalculation.TaxesPipeline
{
    public class TaxType
    {
        private TaxType(string code)
        {
            Code = code;
        }

        public static TaxType Medicare = new TaxType("MDCR");
        public static TaxType MedicareAdditional = new TaxType("MDCR+");

        public string Code { get; private set; }
    }
}
