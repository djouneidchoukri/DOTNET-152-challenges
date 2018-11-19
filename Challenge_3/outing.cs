using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    public class Outing
    {
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCostPerPerson { get; set; }

        public decimal TotalCostPerEvent
        {
            get { return TotalCostPerPerson * NumberOfPeople; }
        }

        public EventTypes EventType { get; set; }

        public enum EventTypes
        {
            Golf = 1,
            Bowling,
            AmusementPark,
            Concert
        }
    }

}
