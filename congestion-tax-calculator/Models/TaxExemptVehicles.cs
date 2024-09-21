namespace congestion_tax_calculator.Models
{
	public class TaxExemptVehicles
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public bool IsExemptVehicle { get; set; }
        public static TaxExemptVehicles Create(string name , bool IsExemptVehicle)
        {
            var item = new TaxExemptVehicles
            {
               
                Name = name,
                IsExemptVehicle = IsExemptVehicle

            };
            return item;
        }

    }
}
