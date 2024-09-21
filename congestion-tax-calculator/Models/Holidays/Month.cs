namespace congestion_tax_calculator.Models.Holidays
{
    public class Month
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
       
        public ICollection<DaysOfMonth> DaysOfMonth { get; set; }

        public static Month Create(Guid id,int number)
        {
            var item = new Month
            {
                Number = number,
                Id = id,
            };
            return item;
        }
    }
}
