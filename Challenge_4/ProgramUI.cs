using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepository;

        public ProgramUI()
        {
            _badgeRepository = new BadgeRepository();
        }

        internal void Run()
        {
            Console.WriteLine("Welcome to Komodo Insurance badging system");
            Console.WriteLine("What do you want to do today?");
            bool askAgain = true;

            while (askAgain)
            {
                string stringInput = GetUserInput();

                if (int.TryParse(stringInput, out int parsedInput))
                {
                    switch (parsedInput)
                    {
                        case 1:
                            CreateBadge();
                            break;
                        case 2:
                            UpdateExistingBadge();
                            break;
                        case 3:
                            DeleteAllDoorsOfExistingBadge();
                            break;
                        case 4:
                            ListAll();
                            break;
                        case 0:
                            askAgain = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid option. Try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Your input was not a valid mumber. please try again.");
                }
            }
        }

        private void ListAll()
        {
            _badgeRepository.ShowBadges();
            NextMessage();
        }

        private static void NextMessage()
        {
            Console.WriteLine("\n------------------");
            Console.WriteLine("What else do you want to do?");
        }

        private void DeleteAllDoorsOfExistingBadge()
        {
            Console.WriteLine("Please provide badge Id to delete list of doors");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int badgeId))
            {
                _badgeRepository.DeleteAllDoors(badgeId);
            }
            else
            {
                Console.WriteLine("That was not a valid ID");
            }
            NextMessage();
        }

        private void UpdateExistingBadge()
        {
            Console.WriteLine("Please enter badge ID");

            string inputBadgeId = Console.ReadLine();
            int badgeId;
            while (!int.TryParse(inputBadgeId, out badgeId))
            {
                Console.WriteLine("Please enter a valid number for Badge ID");
                inputBadgeId = Console.ReadLine();
            }
            Dictionary<int, List<string>> dictionary = _badgeRepository.GetDictionary();

            Console.WriteLine("how many doors can this badge open?");
            string inputNumberOfDoor = Console.ReadLine();
            int numberOfDoors;
            while (!int.TryParse(inputNumberOfDoor, out numberOfDoors) || numberOfDoors < 1)
            {
                Console.WriteLine("Please enter a valid number greater than zero (0) for number of doors");
                inputNumberOfDoor = Console.ReadLine();
            }
            List<string> listOfDoors = new List<string>();

            for (int i = 0; i < numberOfDoors; i++)
            {
                Console.WriteLine("Enter door name for door #" + (i + 1));
                string doorName = Console.ReadLine();
                listOfDoors.Add(doorName);
            }

            _badgeRepository.UpdateBadge(badgeId, listOfDoors);
            NextMessage();
        }

        private void CreateBadge()
        {

            Console.WriteLine("Please enter badge ID");

            string inputBadgeId = Console.ReadLine();
            int badgeId;
            while (!int.TryParse(inputBadgeId, out badgeId))
            {
                Console.WriteLine("Please enter a valid number for Badge ID");
                inputBadgeId = Console.ReadLine();
            }
            Dictionary<int, List<string>> dictionary = _badgeRepository.GetDictionary();

            if (dictionary.ContainsKey(badgeId))
            {
                Console.WriteLine("badge ID " + badgeId + " already exist.");
            }
            else
            {
                Console.WriteLine("how many doors can this badge open?");
                string inputNumberOfDoor = Console.ReadLine();
                int numberOfDoors;
                while (!int.TryParse(inputNumberOfDoor, out numberOfDoors) || numberOfDoors < 1)
                {
                    Console.WriteLine("Please enter a valid number greater than zero (0) for number of doors");
                    inputNumberOfDoor = Console.ReadLine();
                }
                List<string> listOfDoors = new List<string>();

                for (int i = 0; i < numberOfDoors; i++)
                {
                    Console.WriteLine("Enter door name for door #" + (i + 1));
                    string doorName = Console.ReadLine();
                    listOfDoors.Add(doorName);
                }

                _badgeRepository.AddBadge(badgeId, listOfDoors);
            }
            NextMessage();
        }

        private string GetUserInput()
        {
            Console.WriteLine("1. Create a new Badge");
            Console.WriteLine("2. Update doors on an existing badge.");
            Console.WriteLine("3. Delete all doors from an existing badge.");
            Console.WriteLine("4. List All");
            Console.WriteLine("0. Exist");
            Console.WriteLine("Please keyin option number:");
            return Console.ReadLine();
        }
    }
}
