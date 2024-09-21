namespace congestion_tax_calculator.Models.TaxRecords
{
    public class TaxRecord
    {
        public Guid Id { get; set; }
        public string CarName { get; set; } = string.Empty;
        public string LicensePlateNumber { get; set; } = string.Empty;
        public Guid CarTypeId { get; set; }
        public TaxExemptVehicles CarType { get; set; }
        public  ICollection<TaxRecordTime> TaxRecordTimes { get; set; }
        public static TaxRecord Create(Guid Id,string CarName, string LicensePlateNumber, Guid CarTypeId)
        {
            var item = new TaxRecord
            {
                Id = Id,
                CarName = CarName,
                LicensePlateNumber = LicensePlateNumber,
                CarTypeId = CarTypeId,
            };
            return item;
        }
    }
}
