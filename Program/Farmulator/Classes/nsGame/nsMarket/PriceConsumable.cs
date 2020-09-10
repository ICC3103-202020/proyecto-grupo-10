using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMarket
{
    class PriceConsumable
    {
        private Consumable consumable;
        private List<int> prices;

        //CONSTRUCTOR
        public PriceConsumable(Consumable consumable)
        {
            this.consumable = consumable;
        }

        //ACCESO
        public Consumable GetConsumable()
        {
            return this.consumable;
        }

        public List<int> GetPrices()
        {
            return this.prices;
        }
    }
}
