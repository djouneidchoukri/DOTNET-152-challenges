using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    public class ProgramFlow
    {
        private ClaimRepository _claimRepository;

        public ProgramFlow()
        {
            _claimRepository = new ClaimRepository();
        }

        public void Run()
        {
            Console.WriteLine("Komodo Claims Department");
            Console.WriteLine("=====================");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("\n--------------------");
                Console.WriteLine("Choose a menu item:");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. See all claims");
                Console.WriteLine("2. Take care of next claim");
                Console.WriteLine("3. Enter a new claim");
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int input))
                {
                    switch (input)
                    {
                        case 1:
                            _claimRepository.DisplayClaims();
                            break;
                        case 2:
                            DisplayNextClaim();
                            break;
                        case 3:
                            AddNewClaim();
                            break;
                    }
                }
            }
        }
        private void DisplayNextClaim()
        {
            var claim = _claimRepository.GetNextClaim();
            Console.WriteLine("Here are the details for the next claim to be handled:");
            Console.WriteLine("ClaimID : " + claim.ClaimID);
            Console.WriteLine("Type : " + claim.ClaimType.ToString());
            Console.WriteLine("Description : " + claim.Description);
            Console.WriteLine("Amount : $" + claim.ClaimAmount);
            Console.WriteLine("DateOfAccident : " + claim.DateOfAccident.ToString("MM/dd/yyyy"));
            Console.WriteLine("DateOfClaim : " + claim.DateOfClaim.ToString("MM/dd/yyyy"));
            Console.WriteLine("IsValid : " + claim.IsValid.ToString());

            Console.WriteLine("Do you want to deal with this claim now(y/n)? ");
            while (true)
            {
                var input = Console.ReadKey();
                if (input.KeyChar == 'y')
                {
                    _claimRepository.HandleNextClaim();
                    break;
                }
                else if (input.KeyChar == 'n')
                {
                    Console.WriteLine("You chose not to handle this claim at the moment.");
                    break;
                }
                else
                    Console.WriteLine("wrong input. type 'y' for yes or 'n' for no");
            }
        }
        private void AddNewClaim()
        {
            Console.Write("Enter the claim id: ");
            string claimId = Console.ReadLine();
            Console.Write("Enter the claim type: ");
            var type = Console.ReadLine();
            Console.Write("Enter a claim description: ");
            var description = Console.ReadLine();
            Console.Write("Amount of Damage: $");
            var amount = Console.ReadLine();
            Console.Write("Date Of Accident: ");
            var dateOfAccident = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Date of Claim: ");
            var dateOfClaim = Convert.ToDateTime(Console.ReadLine());

            bool isValid = true;

            if ((dateOfClaim - dateOfAccident).Days > 30 || (dateOfClaim - dateOfAccident).Days < 0)
            {
                Console.Write("This claim is invalid.");
                isValid = false;
            }
            else
            {
                Console.Write("This claim is valid.");
            }


            Claim claim = new Claim
            {
                ClaimID = int.Parse(claimId),
                ClaimType = type,
                Description = description,
                ClaimAmount = decimal.Parse(amount),
                DateOfAccident = dateOfAccident,
                DateOfClaim = dateOfClaim,
                IsValid = isValid
            };

            _claimRepository.QueueNewClaim(claim);
        }


    }
}
