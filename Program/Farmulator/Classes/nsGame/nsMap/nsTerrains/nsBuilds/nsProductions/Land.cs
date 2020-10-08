using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions
{
    class Land:Production
    {
        private Seed seed;
        private int nutrients;
        private bool worms;
        private bool undergrowth;

        public Land(string name,int buyPrice, int sellPrice, int health, int water, int maturity, double finalProduction, bool disease, Seed seed, int nutrients, bool worms, bool undergrowth)
        {
            this.name = name;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.health = health;
            this.water = water;
            this.maturity = maturity;
            this.finalProduction = finalProduction;
            this.disease = disease;
            this.seed = seed;
            this.nutrients = nutrients;
            this.worms = worms;
            this.undergrowth = undergrowth;

        }

        //ACCESO
        public string GetName()
        {
            return this.name;
        }

        public int GetBuyPrice()
        {
            return this.buyPrice;
        }

        public int GetSellPrice()
        {
            return this.sellPrice;
        }

        public int GetHealth()
        {
            return this.health;
        }

        public int GetWater()
        {
            return this.water;
        }

        public int GetMaturity()
        {
            return this.maturity;
        }

        public double GetFinalProduction()
        {
            return this.finalProduction;
        }

        public bool GetDisease()
        {
            return this.disease;
        }

        public Seed GetSeed()
        {
            return this.seed;
        }

        public int GetNutrients()
        {
            return this.nutrients;
        }

        public bool GetWorms()
        {
            return this.worms;
        }

        public bool GetUndergrowth()
        {
            return this.undergrowth;
        }

        public void ToMature()
        {
            this.maturity += 1;
            return;
        }

        public void HealthPenalty()
        {
            if (this.water < this.seed.GetMinWater())
            {
                if (this.health - this.seed.GetWaterPenalty() >= 0)
                {
                    this.health -= this.seed.GetWaterPenalty();
                }
            }

            if (this.nutrients < this.seed.GetMinNutrients())
            {
                if (this.health - this.seed.GetNutrientsPenalty() >= 0)
                {
                    this.health -= this.seed.GetNutrientsPenalty();
                }
            }

            if (this.disease == true)
            {
                if (this.health - this.seed.GetDiseasePenalty() >= 0)
                {
                    this.health -= this.seed.GetDiseasePenalty();
                }
            }

            if (this.worms == true)
            {
                if (this.health - this.seed.GetWormsPenalty() >= 0)
                {
                    this.health -= this.seed.GetWormsPenalty();
                }
            }

            if (this.undergrowth == true)
            {
                if (this.health - this.seed.GetUndergrowthPenalty() >= 0)
                {
                    this.health -= this.seed.GetUndergrowthPenalty();
                }
            }

            return;
        }

        public void FoodWaterConsumption()
        {
            int nutrientConsumption = this.seed.GetNutrientsConsumption();
            int waterConsumption = this.seed.GetWaterConsumption();

            if (this.nutrients - nutrientConsumption >= 0)
            {
                this.nutrients -= nutrientConsumption;
            }

            if (this.water - waterConsumption >= 0)
            {
                this.water -= waterConsumption;
            }
        }

        public void DiseaseProbability()
        {
            Random rnd = new Random();

            if(this.disease == false)
            {
                int probability = this.seed.GetDiseaseProbability() - 1;

                if (probability >= rnd.Next(100))
                {
                    this.disease = true;
                }
            }

            if (this.worms == false)
            {
                int probability = this.seed.GetWormsProbabiity() - 1;

                if (probability >= rnd.Next(100))
                {
                    this.worms = true;
                }
            }

            if (this.undergrowth == false)
            {
                int probability = this.seed.GetUndergrowthProbability() - 1;

                if (probability >= rnd.Next(100))
                {
                    this.undergrowth = true;
                }
            }
        }
    }
}
