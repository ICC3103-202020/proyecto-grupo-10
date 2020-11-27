using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions
{
    [Serializable]
    class Ranch:Production
    {
        private Animal animal;
        private int food;
        private int quantity;
        private Bitmap bitmap;

        public Ranch(Bitmap bitmap,  string name, int buyPrice, int sellPrice, int health, int water, int maturity, int finalProduction, bool disease, Animal animal, int food, int quantity)
        {
            this.bitmap = bitmap;
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
            this.quantity = quantity;
        }

        //ACCESO
        public Bitmap GetImg()
        {
            return this.bitmap;
        }
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

        public int GetFinalProduction()
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

        public int GetQuantity()
        {
            return this.quantity;
        }

        public void ToMature()
        {
            this.maturity += 1;
            return;
        }

        public void HealthPenalty()
        {
            if (this.water < this.animal.GetMinWater())
            {
                if (this.health - this.animal.GetWaterPenalty() >= 0)
                {
                    this.health -= this.animal.GetWaterPenalty();
                }
            }

            if (this.food < this.animal.GetMinFood())
            {
                if (this.health - this.animal.GetFoodPenalty() >= 0)
                {
                    this.health -= this.animal.GetFoodPenalty();
                }
            }

            if (this.disease == true)
            {
                if (this.health - this.animal.GetDiseasePenalty() >= 0)
                {
                    this.health -= this.animal.GetDiseasePenalty();
                }
            }

            return;
        }

        public void FoodWaterConsumption()
        {
            int foodConsumption = this.animal.GetFoodConsumption();
            int waterConsumption = this.animal.GetWaterConsumption();

            if(this.food - foodConsumption >= 0)
            {
                this.food -= foodConsumption;
            }

            if (this.water - waterConsumption >= 0)
            {
                this.water -= waterConsumption;
            }
        }

        public void DiseaseProbability()
        {
            Random rnd = new Random();

            if (this.disease == false)
            {
                int probability = this.animal.GetDiseaseProbability() - 1;

                if (probability >= rnd.Next(100))
                {
                    this.disease = true;
                }
            }

            if(this.animal.GetDeadProbability() - 1 >= rnd.Next(100))
            {
                int animalsDead = rnd.Next(this.animal.GetDeadRange()[0] , this.animal.GetDeadRange()[1]);

                if(this.quantity - animalsDead >= 0)
                {
                    this.quantity -= animalsDead;
                }
            }

            if (this.animal.GetEscapeProbability() - 1 >= rnd.Next(100))
            {
                int animalsEscape = rnd.Next(this.animal.GetEscapeRange()[0], this.animal.GetEscapeRange()[1]);

                if (this.quantity - animalsEscape >= 0)
                {
                    this.quantity -= animalsEscape;
                }
            }

        }

        public void ApplyConsumable(Consumable consumable)
        {
            if(consumable.GetType() == typeof(AnimalFood))
            {
                this.food = 100;
            }

            if (consumable.GetType() == typeof(AnimalWater))
            {
                this.water = 100;
            }

            if (consumable.GetType() == typeof(Vaccine))
            {
                this.disease = false;
            }
        }
    }
}
