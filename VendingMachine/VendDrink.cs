using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VendingMachine
{
    class VendDrink
    {
        static void Main(string[] args)
        {
            List<Drink> drinkList = MakeDrinkList();
            Console.WriteLine("Welcome to CPI VendPoint. Please make your selection");
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 0; i < drinkList.Count; i++)
            {
                Console.WriteLine(alphabet[i] + i + ": " + drinkList[i].DrinkName);
            }

            string vendString = Console.ReadLine();
            Drink vendItem = null;
            while (vendItem == null)
            {
                //This is far from the quickest verification method but I wanted to show off a little 
                Regex vendPattern = new Regex("[A,B,C]([1,2,3])");
                Match vendMatch = vendPattern.Match(vendString);

                while (!vendMatch.Success)
                {
                    Console.WriteLine("Item ID not recognized. Please enter a valid item code A1, B2, or C3");
                    vendString = Console.ReadLine();
                    vendMatch = vendPattern.Match(vendString);
                }
                Int32.TryParse(vendMatch.Groups[1].Value, out int vendID);
                Drink maybeVend = drinkList[vendID];

                Console.WriteLine("Selected " + vendItem.GetDescription());
                Console.WriteLine("Vend? Y/N");

                string confirm = Console.ReadLine();
                
                //A switch case is also too much computing for 2 cases but I have to display my "prowess"
                switch (confirm)
                {
                    case "Y":
                        vendItem = maybeVend;
                        Console.WriteLine("Vending...");
                        break;
                    case "N":
                        Console.WriteLine("Cancelled. Please make another selection");
                        break;
                }
            }

            if (vendItem is Beer)
            {
                Console.WriteLine("Age restricted item selected. Please enter your Date of Birth in MM/DD/YY format.");
                string ageString = Console.ReadLine();
                DateTime userDOB;
                while (!DateTime.TryParse(ageString, out userDOB)) //This is the preferred way of checking simple strings
                {
                    Console.WriteLine("Could not read age. Please re-enter in MM/DD/YYYY format.");
                    ageString = Console.ReadLine();
                }
                TimeSpan ageDifference = userDOB - DateTime.Now;
                if (ageDifference.TotalDays < 7665) //7665 days in 21 years
                {
                    Console.WriteLine("Unauthorized purchase. You are too young to be drinking alcohol. Local authorities have been alerted and are on their way. Goodbye!");
                }
            }
            else
            {
                Console.WriteLine("Enjoy your ice cold pepsi product, and please remember to recycle!");
            }

        }

        private static List<Drink> MakeDrinkList(){
            Juice orangeJuice = new Juice("Orange Juice", "not carbonated", "Oranges");
            Soda pepsi = new Soda("Pepsi", "carbonated");
            Beer budweiser = new Beer("Budweiser", "carbonated", 5);
            List<Drink> returnList = new ArrayList<Drink>();
            returnList.Add(orangeJuice);
            returnList.Add(pepsi);
            returnList.Add(budweiser);
            return returnList;
        }
    }
}
