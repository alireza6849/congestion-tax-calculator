namespace congestion_tax_calculator.Models.TaxRecords
{
    public class TaxRecord
    {
        public int Id { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string LicensePlateNumber { get; set; } = string.Empty;
        public int CarTypeId { get; set; }
        public TaxExemptVehicles CarType { get; set; }
        public ICollection<TaxRecordTime> TaxRecordTimes { get; set; }
     
    }
}
