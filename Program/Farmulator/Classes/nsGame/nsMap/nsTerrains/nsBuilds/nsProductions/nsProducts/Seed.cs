using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts
{
    [Serializable]
    class Seed:Product
    {
        private int nutrientsConsumption;
        private int minNutrients;
        private int nutrientsPenalty;
        private int wormsProbability;
        private int wormsPenalty;
        private int undergrowthProbability;
        private int undergrowthPenalty;
        private int priceVariation;

        //CONSTRUCTOR
        public Seed(string name, int waterConsumption, int minWater, int waterPenalty, int timeProduction, int diseaseProbability, int diseasePenalty, int nutrientsConsumption, int minNutrients, int nutrientsPenalty, int wormsProbability, int wormsPenalty, int undergrowthProbability, int undergrowthPenalty, int priceVariation)
        {
            this.name = name;
            this.waterConsumption = waterConsumption;
            this.minWater = minWater;
            this.waterPenalty = waterPenalty;
            this.timeProduction = timeProduction;
            this.diseaseProbability = diseaseProbability;
            this.diseasePenalty = diseasePenalty;
            this.nutrientsConsumption = nutrientsConsumption;
            this.minNutrients = minNutrients;
            this.nutrientsPenalty = nutrientsPenalty;
            this.wormsProbability = wormsProbability;
            this.wormsPenalty = wormsPenalty;
            this.undergrowthProbability = undergrowthProbability;
            this.undergrowthPenalty = undergrowthPenalty;
            this.priceVariation = priceVariation;

        }

        //ACCESO
        public string GetName()
        {
            return this.name;
        }

        public int GetWaterConsumption()
        {
            return this.waterConsumption;
        }

        public int GetMinWater()
        {
            return this.minWater;
        }

        public int GetWaterPenalty()
        {
            return this.waterPenalty;
        }

        public int GetTimeProduction()
        {
            return this.timeProduction;
        }

        public int GetDiseaseProbability()
        {
            return this.diseaseProbability;
        }

        public int GetDiseasePenalty()
        {
            return this.diseasePenalty;
        }

        public int GetNutrientsConsumption()
        {
            return this.nutrientsConsumption;
        }

        public int GetMinNutrients()
        {
            return this.minNutrients;
        }
        public int GetNutrientsPenalty()
        {
            return this.nutrientsPenalty;
        }
        public int GetWormsProbabiity()
        {
            return this.wormsProbability;
        }
        public int GetWormsPenalty()
        {
            return this.wormsPenalty;
        }
        public int GetUndergrowthProbability()
        {
            return this.undergrowthProbability;
        }
        public int GetUndergrowthPenalty()
        {
            return this.undergrowthPenalty;
        }
        public int GetPriceVariation()
        {
            return this.priceVariation;
        }

        //METODOS
    }
}
