using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions
{
    class Ranch:Production
    {
        private Animal animal;
        private int food;

        public Ranch(string name, int buyPrice, int sellPrice, int health, int water, int maturity, double finalProduction, bool disease, Animal animal, int food)
        {
            this.name = name;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.health = health;
            this.water = water;
            this.maturity = maturity;
            this.finalProduction = finalProduction;
            this.disease = disease;
            this.animal = animal;
            this.food = food;
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

        public Animal GetAnimal()
        {
            return this.animal;
        }

        public int GetFood()
        {
            return this.food;
        }
    }
}
