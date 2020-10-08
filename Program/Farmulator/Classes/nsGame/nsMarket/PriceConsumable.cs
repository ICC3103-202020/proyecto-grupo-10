using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables;
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
        private int price;

        //CONSTRUCTOR
        public PriceConsumable(Consumable consumable, int price)
        {
            this.consumable = consumable;
            this.price = price;
        }

        //ACCESO
        public Consumable GetConsumable()
        {
            return this.consumable;
        }

        public int GetPrice()
        {
            return this.price;
        }
    }
}
