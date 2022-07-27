using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {

        private const string DoughExceptionMessage = "Invalid type of dough.";
        private const string weightExceptionMessage = "Dough weight should be in the range [1..200].";

        private Dictionary<string, double> flourTypeCalories = new Dictionary<string, double>
        {
            { "white" , 1.5 },
            { "wholegrain" , 1 },
        };

        private Dictionary<string, double> bakingTechniqueCalories = new Dictionary<string, double>
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1 },
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType
        {
            get 
            { 
                return flourType; 
            }
            private set 
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                flourType = value; 
            }
        }
     
        public string BakingTechnique
        {
            get 
            { 
                return bakingTechnique; 
            }
            private set 
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                bakingTechnique = value;
            }
        }

        public double Weight
        {
            get 
            { 
                return weight; 
            }
            private set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(weightExceptionMessage);
                }

                weight = value; 
            }
        }

        public double Calories
            => 2 * Weight * flourTypeCalories[this.FlourType.ToLower()] * bakingTechniqueCalories[this.BakingTechnique.ToLower()];
    }
}
