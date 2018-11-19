using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    public class ProgramFlow
    {
        private OutingRepository _outingRepository;

        public ProgramFlow()
        {
            _outingRepository = new OutingRepository();
        }

        public void Run()
        {
            Console.WriteLine("Komodo Outings");
            Console.WriteLine("=====================");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\n--------------------");
                Console.WriteLine("Options:");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Add a new Outing");
                Console.WriteLine("2. Display Outings");
                Console.WriteLine("0. Exit");
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int input))
                {
                    switch (input)
                    {
                        case 1:
                            AddNewOuting();
                            break;
                        case 2:
                            _outingRepository.DisplayOuting();
                            break;
                        case 0:
                            loop = false;
                            break;
                    }
                }
            }
        }

        private void AddNewOuting()
        {
            Outing outing = new Outing();

            Console.WriteLine("Enter Event Type");
            Console.WriteLine($"1 for {Outing.EventTypes.Golf.ToString()}");
            Console.WriteLine($"2 for {Outing.EventTypes.Bowling.ToString()}");
            Console.WriteLine($"3 for {Outing.EventTypes.AmusementPark.ToString()}");
            Console.WriteLine($"4 for {Outing.EventTypes.Concert.ToString()}");
            string typeInput = Console.ReadLine();

            int type;
            while (!int.TryParse(typeInput, out type) && (type < 1 || type > 4))
            {
                Console.WriteLine("Enter a valid type listed above.");
                typeInput = Console.ReadLine();
            }
            outing.EventType = (Outing.EventTypes)type;

            Console.WriteLine("Enter The Number of People");
            outing.NumberOfPeople = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Total Cost per Person per Event");
            outing.TotalCostPerPerson = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date (MM/DD/YYYY)");
            string date = Console.ReadLine();
            outing.Date = Convert.ToDateTime(date);

            _outingRepository.AddOuting(outing);
            Console.WriteLine("Thank you for input a new outing was added.");
        }


    }
}
