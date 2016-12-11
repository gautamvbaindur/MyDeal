using MyDeal.WebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyDeal.WebApi.PassengerService
{
    public class PassengerLocatorService : IPassengerLocator
    {
        public IList GetPassengers(PassengerLocator passengerList)
        {
            var stringArray = passengerList.passengerList.Trim().Split(new String[] { "\r\n" }, StringSplitOptions.None);
            var passengersOnly = stringArray.Where(item => item.StartsWith("1") && (string.IsNullOrEmpty(passengerList.searchText) ? true : item.IndexOf(passengerList.searchText, StringComparison.OrdinalIgnoreCase) > -1));
            var records = new List<dynamic>();
            passengersOnly.ToList().ForEach(record =>
            {
                var id = record.Substring(record.LastIndexOf("/") + 1, 6);
                var name = record.Substring(1, record.LastIndexOf(" ")).Split(new String[] { " ", "-" }, StringSplitOptions.RemoveEmptyEntries)[0];
                records.Add(new { ID = id, Name = name });
            });

            return (from data in records
                    group data by new { data.ID }
                     into grp
                    select new
                    {
                        ID = grp.Key.ID,
                        Names = grp.Select(item => item.Name)
                    }).ToList();
        }
    }
}