namespace congestion_tax_calculator.Models.TaxRecords
{
    public class TaxRecordTime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Guid TaxRecordId { get; set; }
        public TaxRecord TaxRecord { get; set; }
        public static TaxRecordTime Create( DateTime date, Guid taxRecordId)
        {
            var item = new TaxRecordTime
            {
                Date = date,
                TaxRecordId = taxRecordId,
            };
            return item;
        }
    }
}
