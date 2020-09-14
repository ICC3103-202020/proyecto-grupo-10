using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts
{
    class Animal:Product
    {
        private int foodConsumption;
        private int minFood;
        private int foodPenalty;
        private int escapeProbability;
        private int[] escapeRange;
        private int deadProbability;
        private int[] deadRange;
        private int units;

        //CONSTRUCTOR
        public Animal(string name, int waterConsumption, int minWater, int waterPenalty, int timeProduction, int diseaseProbability, int diseasePenalty, int foodConsumption, int minFood, int foodPenalty, int escapeProbability, int[] escapeRange, int deadProbability, int[] deadRange, int units)
        {
            this.name = name;
            this.waterConsumption = waterConsumption;
            this.minWater = minWater;
            this.waterPenalty = waterPenalty;
            this.timeProduction = timeProduction;
            this.diseaseProbability = diseaseProbability;
            this.diseasePenalty = diseasePenalty;
            this.foodConsumption = foodConsumption;
            this.minFood = minFood;
            this.foodPenalty = foodPenalty;
            this.escapeProbability = escapeProbability;
            this.escapeRange = escapeRange;
            this.deadProbability = deadProbability;
            this.deadRange = deadRange;
            this.units = units;

            //FALTA AGREGAR LOS ATRIBUTOS UNICOS DE ANIMAL
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

        public int GetFoodConsumption()
        {
            return this.foodConsumption;
        }

        public int GetMinFood()
        {
            return this.minFood;
        }

        public int GetFoodPenalty()
        {
            return this.foodPenalty;
        }

        public int GetEscapeProbability()
        {
            return this.escapeProbability;
        }

        public int[] GetEscapeRange()
        {
            return this.escapeRange;
        }

        public int GetDeadProbability()
        {
            return this.deadProbability;
        }

        public int[] GetDeadRange()
        {
            return this.deadRange;
        }

        public int GetUnits()
        {
            return this.units;
        }

        //METODOS
    }
}
