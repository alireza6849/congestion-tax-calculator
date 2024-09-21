namespace congestion_tax_calculator.Models.Holidays
{
    public class DaysOfMonth
    {
        public int Id {  get; set; }
        public int Number { get; set; }
        public Guid MonthId { get; set; }
        public Month Month { get; set; }
        public static DaysOfMonth Create(int number, Guid monthid)
        {
            var item = new DaysOfMonth
            {
                Number = number,
                MonthId = monthid

            };
            return item;
        }
    }
}
