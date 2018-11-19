using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    public class OutingRepository
    {
        private List<Outing> _outings;

        public OutingRepository()
        {
            _outings = new List<Outing>();
        }

        public void AddOuting(Outing outing)
        {
            _outings.Add(outing);
        }

        public void DisplayOuting()
        {
            Console.WriteLine("List of Outings:");
            Console.WriteLine("----------------");
            Console.Write(FormatedString("Event Type"));
            Console.Write(FormatedString("Number of People"));
            Console.Write(FormatedString("Date"));
            Console.Write(FormatedString("Total Cost Per Person"));
            Console.Write(FormatedString("Total Cost Per Event"));

            foreach (var outing in _outings)
            {
                Console.Write(FormatedString("\n" + outing.EventType.ToString()));
                Console.Write(FormatedString(outing.NumberOfPeople.ToString()));
                Console.Write(FormatedString(outing.Date.ToString()));
                Console.Write(FormatedString(outing.TotalCostPerPerson.ToString()));
                Console.Write(FormatedString(outing.TotalCostPerEvent.ToString()));
            }

            Console.WriteLine("\n----------------------------------------------------------");
            DisplayTotalPerType(Outing.EventTypes.Bowling);
            DisplayTotalPerType(Outing.EventTypes.Golf);
            DisplayTotalPerType(Outing.EventTypes.Concert);
            DisplayTotalPerType(Outing.EventTypes.AmusementPark);
            Console.WriteLine("All Concert outings cost $" + _outings.Sum(x => x.TotalCostPerEvent));
        }

        private void DisplayTotalPerType(Outing.EventTypes type)
        {
            Console.WriteLine($"All {type.ToString()} outings for the year were ${_outings.Where(x => x.EventType == type).Sum(x => x.TotalCostPerEvent)}");
        }

        private string FormatedString(string str)
        {
            return str.PadRight(25, ' ');
        }
    }
}
