using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts
{
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
        public Seed(string name, int waterConsumption, int minWater, int waterPenalty, int timeProduction, int diseaseProbability, int diseasePenalty)
        {
            this.name = name;
            this.waterConsumption = waterConsumption;
            this.minWater = minWater;
            this.waterPenalty = waterPenalty;
            this.timeProduction = timeProduction;
            this.diseaseProbability = diseaseProbability;
            this.diseasePenalty = diseasePenalty;

            //FALTA AGREGAR LOS ATRIBUTOS UNICOS DE SEED
        }

        //ACCESO
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
