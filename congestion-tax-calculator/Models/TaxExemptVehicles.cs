namespace congestion_tax_calculator.Models
{
	public class TaxExemptVehicles
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public bool IsExemptVehicle { get; set; }
        public static TaxExemptVehicles Create(Guid Id,string name , bool IsExemptVehicle)
        {
            var item = new TaxExemptVehicles
            {
               Id = Id,
                Name = name,
                IsExemptVehicle = IsExemptVehicle

            };
            return item;
        }

    }
}
