using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {

        private Dictionary<int, List<string>> _dictionary;

        public BadgeRepository()
        {
            _dictionary = new Dictionary<int, List<string>>();
        }

        public Dictionary<int, List<string>> GetDictionary()
        {
            return _dictionary;
        }

        public void AddBadge(int badgeId, List<string> listOfDoors)
        {
           _dictionary.Add(badgeId, listOfDoors);
        }

        public void DeleteAllDoors(int badgeId)
        {
            if (_dictionary.ContainsKey(badgeId))
            {
                _dictionary[badgeId] = new List<string>();
            }
            else
            {
                Console.WriteLine("Failed to delete list of doors. cannot find badge ID "+badgeId);
            }
        }

        public void UpdateBadge(int badgeId, List<string> listOfDoors)
        {
            if (_dictionary.ContainsKey(badgeId))
            {
                _dictionary[badgeId] = listOfDoors;
            }
            else
            {
                Console.WriteLine("Failed to update list of doors. cannot find badge ID " + badgeId);
            }
        }


        public void ShowBadges()
        {
            Console.WriteLine("Key");
            Console.WriteLine("Badge#                Door Access\n");

            foreach(var badge in _dictionary)
            {
                string listOfName = string.Empty;
                foreach (var badgeName in badge.Value)
                {
                    if (!string.IsNullOrEmpty(listOfName))
                        listOfName += ", ";

                    listOfName += badgeName;
                }

                Console.WriteLine(badge.Key + "                "+ listOfName);
            }
        }
    }
}
