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
    }
}
