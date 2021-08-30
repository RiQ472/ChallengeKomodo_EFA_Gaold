using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Komodo_Claims
{
    public class ClaimsUI
    {
        private ClaimsRepository _repo = new ClaimsRepository();
        public void Run()
        {
            Menu();
            SeededContentClaims();
        }
        string input = Console.ReadLine();
        private void Menu()
        {
            Console.ReadLine();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                KomodoClaimsT();
                Console.WriteLine("\n\n\tChoose a menu item" +
                    "\n1. View all claims" +
                    "\n2. Move to next claims" +
                    "\n3. Insert new claims" +
                    "\n4. Exit");
                int choice;
                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AllClaims();
                            break;
                        case 2:
                            NextClaim();
                            break;
                        case 3:
                            NewClaim();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("\n\n\tExiting Komodo Claims...");
                            Thread.Sleep(1000); // sleep
                            keepRunning = false;
                            break;
                        default:
                            Console.WriteLine("Invalid selection Try again");
                            break;
                    }
                }
            }

        }

        private void Continue()
        {
            Console.WriteLine("\n\n\tPress any key to continue...");
            Console.ReadKey();
        }
        private void AllClaims()
        {
            Queue<Claims> allclaims = _repo.AllClaims();
            string headerSize = "{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-10}";

            Console.Write("\t");
            Console.Write(headerSize, "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid\n\n");
            Console.WriteLine("\t");

            foreach (Claims claims in allclaims)
            {
                Console.Write(headerSize, $"{claims.ClaimID}", $"{claims.ClaimType}", $"{claims.ClaimAmount}", $"{claims.DateOfIncident.ToString("MM/dd/yy")}");

            }

            Continue();

        }

        private void NextClaim()
        {
            Console.Clear();
            Console.WriteLine();
            Claims claims = _repo.PeekNextClaim();

            string headerSize = "{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-10}";
            Console.WriteLine("\t");
            Console.WriteLine(headerSize, "ClaimId", "Type", "Description", "Amount", "DateOfClaim", "DateOfClaim");
            Console.WriteLine("\t");
            Console.Write(headerSize, $"{claims.ClaimID}", $"{claims.ClaimType}", $"{claims.ClaimAmount}", $"{claims.DateOfIncident.ToString("MM/dd/yy")}");

            Console.WriteLine("\n\tDo you wish to address the claim now [y]es or [n]o or [r] to return back to menu");
            string input = Console.ReadLine();
            if (input == "y")
            {
                _repo.NextClaim(claims);
                return;
            }
            else if (input == "no")
                return;
            else if (input == "r")
            {
                Console.Clear();
                Menu();
            }
            else
                Console.WriteLine("Option unavailible try again");

        }

        private void NewClaim()
        {
            Claims newClaim = new Claims();
            Console.WriteLine($"\n\tInsert calim ID: ");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());
            bool selectType = true;
            while (selectType)
            {
                Console.WriteLine($"\n\tInsert claim type: \n" +
                    $"\t1. Car\n" +
                    $"\t2. Home\n" +
                    $"\t3. Theft\n");

                int inpu = Convert.ToInt32(Console.ReadLine());
                switch (inpu)
                {
                    case 1:
                        newClaim.ClaimType = (ClaimType)1;
                        break;
                    case 2:
                        newClaim.ClaimType = (ClaimType)2;
                        selectType = false;
                        break;
                    case 3:
                        newClaim.ClaimType = (ClaimType)3;
                        selectType = false;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"\n\tInsert claim description");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine($"\n\tEstimated amount of Damage: ex.( 20.00)");
            newClaim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine($"\n\tInsert Date Of incident: ex.(mm/dd/yyyy)");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine($"Insert Date of claim: ex.(mm/dd/yyyy)");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("\n\tAdd New Claim\n" +
                    "[y]es to Add claim to queue\n" +
                    "[b]ack to return to menu");
            _repo.Addclaim(newClaim);

            string input = Console.ReadLine();
            Console.Clear();
            if (input == "y")
            {
                bool claimUpdate = _repo.Addclaim(newClaim);
                if (claimUpdate)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\tClaim added to queue.\n");
                    string headerSize = "{0,-10}{1,-10}{2,-30}{3,-15}{4,-20}{5,-15}{6,-10}";
                    Console.WriteLine("\t");
                    Console.WriteLine("ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateClaim", "IsValid\n\n");
                    Console.WriteLine($"\t");
                    Console.WriteLine(headerSize, $"{newClaim.ClaimID}", $"{newClaim.Description}", $"{ newClaim.ClaimAmount}", $"{newClaim.DateOfIncident.ToString("MM/dd/yy")}", $"{newClaim.DateOfClaim.ToString("MM/dd/yy")}", $"{newClaim.IsValid}\n\n");
                    Console.WriteLine("");
                }
            }

            else if (input == "b")
            {
                Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine("Claim could not be added to queue");
            }
        }

        private void SeededContentClaims()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Car Accident on 464", 400.00, 4/25/18, 4/27/18, true );
            _repo.Addclaim(claimOne);
            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen", 400.00, 4/11/18, 4/12/18, true);
            _repo.Addclaim(claimTwo);
                Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen pancakes", 4.00, 4/27/18, 6/01/18, false);
            _repo.Addclaim(claimThree);

        }

        private void KomodoClaimsT()
        {
            string title = @"
              _   __                          _         _____ _       _               
             | | / /                         | |       /  __ | |     (_)              
             | |/ /  ___  _ __ ___   ___   __| | ___   | /  \| | __ _ _ _ __ ___  ___ 
             |    \ / _ \| '_ ` _ \ / _ \ / _` |/ _ \  | |   | |/ _` | | '_ ` _ \/ __|
             | |\  | (_) | | | | | | (_) | (_| | (_) | | \__/| | (_| | | | | | | \__ \
             \______\___/|_| |_| |_|\___/ ___,_|\___/   \____|_|\____|_|_| |_| |_|___/
             |  _  \                    | |                      | |                 
             | | | |___ _ __   __ _ _ __| |_ _ __ ___   ___ _ __ | |_                
             | | | / _ | '_ \ / _` | '__| __| '_ ` _ \ / _ | '_ \| __|               
             | |/ |  __| |_) | (_| | |  | |_| | | | | |  __| | | | |_                
             |___/ \___| .__/ \__,_|_|   \__|_| |_| |_|\___|_| |_|\__|               
                       | |                                                           
                       |_|";
            Console.WriteLine(title);          
        }

    }
}
