using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds
{
    class Storage:Build
    {
        private int maxCapacity;
        private List<FinalProduct> finalProducts;

        //CONSTRUCTOR
        public Storage(string name, int buyPrice, int sellPrice, int maxCapacity)
        {
            this.name = name;
            this.buyPrice = buyPrice;
            this.sellPrice = sellPrice;
            this.maxCapacity = maxCapacity;
            this.finalProducts = new List<FinalProduct>();
        }

        //ACCESO
        public string GetName()
        {
            return this.name;
        }

        public int GetBuyPrice()
        {
            return this.buyPrice;
        }

        public int GetSellPrice()
        {
            return this.maxCapacity;
        }

        public int GetMaxCapacity()
        {
            return this.maxCapacity;
        }

        public List<FinalProduct> GetFinalProducts()
        {
            return this.finalProducts;
        }

        //METODOS
        public void QualityDecline()
        {
            for(int i = 0; i < this.finalProducts.Count; i++)
            {
                this.finalProducts[i].QualityDecline();
            }
        }

        public void AddFinalProduct(Build build, int quality)
        {
            if(build.GetType() == typeof(Ranch))
            {
                Ranch ranch = (Ranch)build;
                FinalProduct finalProduct = new FinalProduct(ranch.GetAnimal(), quality);

                this.finalProducts.Add(finalProduct);
            }

            if (build.GetType() == typeof(Land))
            {
                Land land = (Land)build;
                FinalProduct finalProduct = new FinalProduct(land.GetSeed(), quality);

                this.finalProducts.Add(finalProduct);
            }
            
        }

        public void SellFinalProduct(FinalProduct finalProduct)
        {
            for(int i = 0; i < this.finalProducts.Count; i++)
            {
                if (finalProducts[i].Equals(finalProduct))
                {
                    this.finalProducts.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
