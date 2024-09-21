namespace congestion_tax_calculator.Models
{
    public class TaxRule
    {
        public int Id { get; set; }
        public TimeOnly FromTime {  get; set; }
        public TimeOnly ToTime { get; set; }

        public int Amount { get; set; }

        public static TaxRule Create(TimeOnly FromTime, TimeOnly ToTime, int Amount)
        {
            var item = new TaxRule
            {
                FromTime = FromTime,
                ToTime = ToTime,
                Amount = Amount

            };
            return item;
        }
    }
}
