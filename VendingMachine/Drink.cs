using System;
using System.Collections.Generic;
using System.Text;

/* Class definitions for base "Drink" class and all derivatives.
 */
namespace VendingMachine
{
    public abstract class Drink
    {
        public string DrinkName { get; set; }
        //I could have picked a boolean here but then I'd have to parse it to and from "not carbonated" and "carbonated." Simpler = better
        protected string CarbonatedString { get; set; }
        abstract public string GetDescription();
    }
    public class Beer : Drink
    {
        int ABV;
        public override string GetDescription()
        {
            string description = DrinkName + ", " + CarbonatedString + ", " + ABV + "%.";

            return description;
        }
        public Beer(string name, string carbonated, int abv)
        {
            DrinkName = name;
            ABV = abv;
            CarbonatedString = carbonated;
        }
    }
    public class Juice : Drink
    {
        private string FruitName;
        public override string GetDescription()
        {
            string description = DrinkName + ", " + CarbonatedString + ", made from " + FruitName + ".";

            return description; throw new NotImplementedException();
        }

        public Juice(string name, string isCarbonated, string madeFrom)
        {
            DrinkName = name;
            CarbonatedString = isCarbonated;
            FruitName = madeFrom;
        }
    }
    public class Soda : Drink
    {

        public Soda(string name, string isCarbonated)
        {
            DrinkName = name;
            CarbonatedString = isCarbonated;
        }
        public override string GetDescription()
        {
            string description = DrinkName + ", " + CarbonatedString + ". ";

            return description;
        }
    }
}
