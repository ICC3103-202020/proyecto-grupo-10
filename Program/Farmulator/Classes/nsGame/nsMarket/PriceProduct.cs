using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;

namespace Farmulator.Classes.nsGame.nsMarket
{
    class PriceProduct
    {
        private Product product;
        private List<int> prices;

        //CONSTRUCTOR
        public PriceProduct(Product product)
        {
            this.product = product;

        }

        //ACCESO
        public Product GetProduct()
        {
            return this.product;
        }
        public List<int> GetPrices()
        {
            return this.prices;
        }
    }
}
