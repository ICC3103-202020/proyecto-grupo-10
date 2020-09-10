using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMarket
{
    class PriceTerrain
    {
        private Terrain terrain;
        private List<int> prices;

        //CONSTRUCTOR
        public PriceTerrain(Terrain terrain)
        {
            this.terrain = terrain;
        }

        //ACCESO
        public Terrain GetTerrain()
        {
            return this.terrain;
        }

        public List<int> GetPrices()
        {
            return this.prices;
        }
    }
}
