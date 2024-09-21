using congestion_tax_calculator.Models;
using congestion_tax_calculator.Models.Holidays;
using congestion_tax_calculator.Models.TaxRecords;
using Microsoft.EntityFrameworkCore;

namespace congestion_tax_calculator.Data
{
    public class InitialData
    {
        private  readonly congestion_tax_calculatorContext _context;

        public InitialData(congestion_tax_calculatorContext context)
        {
            _context = context;
        }


        public static IEnumerable<WeekendDays> w =>
     new List<WeekendDays>
     {
      WeekendDays.Create(name:WeekendDaysName.Saturday),
      WeekendDays.Create(name:WeekendDaysName.Monday),
     };
        public static IEnumerable<TaxExemptVehicles> t =>
    new List<TaxExemptVehicles>
    {
      TaxExemptVehicles.Create(Id:new Guid("292bb933-3357-443c-960d-5a6b7afaa9ab"),name:"Personal car",false),
      TaxExemptVehicles.Create(Id:new Guid("e998960d-d158-4a12-80e6-53767c4c05d6"),name:"Bus",true),
    };
        public static IEnumerable<TaxRule> _taxrule =>
    new List<TaxRule>
    {

      TaxRule.Create(FromTime:new TimeOnly(6, 00),ToTime:new TimeOnly(6, 29) , Amount:8),
      TaxRule.Create(FromTime:new TimeOnly(6, 30),ToTime:new TimeOnly(6,59) , Amount:13),
      TaxRule.Create(FromTime:new TimeOnly(7, 00),ToTime:new TimeOnly(7, 59) , Amount:18),
      TaxRule.Create(FromTime:new TimeOnly(8, 00),ToTime:new TimeOnly(8, 29) , Amount:13),
      TaxRule.Create(FromTime:new TimeOnly(8, 30),ToTime:new TimeOnly(14, 59) , Amount:8),
      TaxRule.Create(FromTime:new TimeOnly(15, 00),ToTime:new TimeOnly(15, 29) , Amount:13),
      TaxRule.Create(FromTime:new TimeOnly(15, 30),ToTime:new TimeOnly(16, 59) , Amount:18),
      TaxRule.Create(FromTime:new TimeOnly(17, 00),ToTime:new TimeOnly(17, 59) , Amount:13),
      TaxRule.Create(FromTime:new TimeOnly(18, 00),ToTime:new TimeOnly(18, 29) , Amount:8),
      TaxRule.Create(FromTime:new TimeOnly(18, 30),ToTime:new TimeOnly(5, 59) , Amount:0),
    };

        public static IEnumerable<Month> _month =>
        new List<Month>
        {
      Month.Create(id:new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),number:1),
      Month.Create(id:new Guid("f285d2e0-9e63-4972-b301-2942453a0d1e"),number:2),
      Month.Create(id:new Guid("00ac9cec-7a0e-446a-b0d3-1405c29aca79"),number:3),
      Month.Create(id:new Guid("2b43ffbb-84c0-4fde-9dcb-be530b2359d0"),number:4),
      Month.Create(id:new Guid("dc8ff1f0-6787-4d45-a530-511ace16ae02"),number:5),
      Month.Create(id:new Guid("38812aeb-c379-4c2c-9d53-d7154e134df9"),number:6),
      Month.Create(id:new Guid("02ad783f-511b-4c6e-a9f9-53a6933db145"),number:7),
      Month.Create(id:new Guid("d8760402-f767-4805-8f6d-0637d2f230eb"),number:8),
      Month.Create(id:new Guid("3dbc406a-6981-4d92-a05e-d197ad226e4e"),number:9),
      Month.Create(id:new Guid("be147fdf-4c47-4c11-8c40-812544f542e2"),number:10),
      Month.Create(id:new Guid("bce2a501-f1b1-4db5-a900-b68c8293c1db"),number:11),
      Month.Create(id:new Guid("3ff143a3-52d5-4768-bbf9-399ed046e190"),number:12),

        };

        public static IEnumerable<DaysOfMonth> _daysofmonth =>
        new List<DaysOfMonth>
        {
      DaysOfMonth.Create(number:1,monthid:new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")  ),
  
        };
        public static IEnumerable<TaxRecord> _taxRecord =>
   new List<TaxRecord>
   {
      TaxRecord.Create(Id:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , CarName:"Tesla Luxury Electric Vehicles 2003-Present",LicensePlateNumber:"231Ea54",CarTypeId:new Guid("292bb933-3357-443c-960d-5a6b7afaa9ab")),

   };
        public static IEnumerable<TaxRecordTime> _taxRecordTime =>
      new List<TaxRecordTime>
      {
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,01,14,21,00,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,01,15,21,00,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,07,6,23,27) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,07,15,27,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,06,27,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,06,20,27) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,14,35,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,15,29,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,15,47,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,16,01,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,16,48,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,17,49,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,18,29,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,02,08,18,35,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,03,26,14,25,00) ),
      TaxRecordTime.Create( taxRecordId:new Guid("cd0f0ea7-f620-4bd4-8303-3122998a4ece") , date: new DateTime(2024,03,28,14,07,27) ),


      };


        
    }

    }








