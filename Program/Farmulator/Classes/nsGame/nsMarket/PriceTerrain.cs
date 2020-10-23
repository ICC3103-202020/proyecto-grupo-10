using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMarket
{
    [Serializable]
    class PriceTerrain
    {
        private Terrain terrain;
        private int price;

        //CONSTRUCTOR
        public PriceTerrain(Terrain terrain, int price)
        {
            this.terrain = terrain;
            this.price = price;
        }

        //ACCESO
        public Terrain GetTerrain()
        {
            return this.terrain;
        }

        public int GetPrice()
        {
            return this.price;
        }
    }
}
