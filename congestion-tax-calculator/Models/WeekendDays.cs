namespace congestion_tax_calculator.Models
{
    public class WeekendDays
    {
        public int Id { get; set; } 
        public WeekendDaysName Name { get; set; }
        public static WeekendDays Create(WeekendDaysName name)
        {
            var item = new WeekendDays
            {

                Name = name,

            };
            return item;
        }
    }
    public enum WeekendDaysName {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        sunday,
    }

  



}

