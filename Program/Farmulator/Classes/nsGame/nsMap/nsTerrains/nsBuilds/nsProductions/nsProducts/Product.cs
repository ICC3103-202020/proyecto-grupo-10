using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts
{
    abstract class Product
    {
        protected string name;
        protected int waterConsumption;
        protected int minWater;
        protected int waterPenalty;
        protected int timeProduction;
        protected int diseaseProbability;
        protected int diseasePenalty;

    }
}
