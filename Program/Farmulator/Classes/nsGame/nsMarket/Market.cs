using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMarket
{
    class Market
    {
        private List<PriceProduct> pricesProducts;
        private List<PriceConsumable> pricesConsumables;
        private List<PriceTerrain> pricesTerrains;

        public Market()
        {
            this.pricesProducts = new List<PriceProduct>();
            this.pricesConsumables = new List<PriceConsumable>();
            this.pricesTerrains = new List<PriceTerrain>();
        }

        private void CalculatePricesProducts(List<Product> products, int turn)
        {
            if(turn == 0)
            {
                for(int i = 0; i < products.Count; i++)
                {
                    for(int j = 0; j < 30; j++)
                    {
                        //FALTA CREAR QUE GENERE HOSTORIAL DE PRECIOS
                    }
                }
            }
        }
    }
}
