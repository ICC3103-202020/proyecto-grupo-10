using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts
{
    class FinalProduct
    {
        private Product product;
        private int quality;

        //CONSTRUCTOR
        public FinalProduct(Product product, int quality)
        {
            this.product = product;
            this.quality = quality;
        }

        //ACCESO
        public Product GetProduct()
        {
            return this.product;
        }

        public int GetQuality()
        {
            return this.quality;
        }

        //METODOS
    }
}
