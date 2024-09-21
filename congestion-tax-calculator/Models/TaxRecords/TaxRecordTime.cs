namespace congestion_tax_calculator.Models.TaxRecords
{
    public class TaxRecordTime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TaxRecordId { get; set; }
        public TaxRecord TaxRecord { get; set; }
    }
}
