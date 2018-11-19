using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    public class ClaimRepository
    {
        private Queue<Claim> claims;
        public ClaimRepository()
        {
            claims = new Queue<Claim>();

        }

        public void QueueNewClaim(Claim claim)
        {
            claims.Enqueue(claim);
        }
        public void HandleNextClaim()
        {
            claims.Dequeue();
        }

        public Claim GetNextClaim()
        {
            return claims.First();
        }
        public void DisplayClaims()
        {
            Console.WriteLine("List of Claims:");
            Console.WriteLine("----------------");
            Console.Write(FormatedString("ClaimID"));
            Console.Write(FormatedString("Type"));
            Console.Write(FormatedString("Description"));
            Console.Write(FormatedString("Amount"));
            Console.Write(FormatedString("DateOfAccident"));
            Console.Write(FormatedString("DateOfClaim"));
            Console.Write(FormatedString("IsValid"));

            foreach (var claim in claims)
            {
                Console.Write(FormatedString("\n" + claim.ClaimID.ToString()));
                Console.Write(FormatedString(claim.ClaimType.ToString()));
                Console.Write(FormatedString(claim.Description.ToString()));
                Console.Write(FormatedString("$" + claim.ClaimAmount.ToString()));
                Console.Write(FormatedString(claim.DateOfAccident.ToString("MM/dd/yyyy")));
                Console.Write(FormatedString(claim.DateOfClaim.ToString("MM/dd/yyyy")));
                Console.Write(FormatedString(claim.IsValid.ToString()));
            }

            Console.WriteLine("\n----------------------------------------------------------");
        }

        private string FormatedString(string str)
        {
            return str.PadRight(25, ' ');
        }
    }
}
