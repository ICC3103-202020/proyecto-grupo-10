using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        //CONSTRUCTOR
        public Market()
        {
            this.pricesProducts = new List<PriceProduct>();
            this.pricesConsumables = new List<PriceConsumable>();
            this.pricesTerrains = new List<PriceTerrain>();
            NewMarket();
        }

        //ACCESO

        //METODOS
        private void NewMarket()
        {
            //BUSCARA Y ABRIRA LOS DATOS DE UN NUEVO JUEGO SERIALIZADO
        }

        private void CalculatePricesProducts(int turn)
        {
            if(turn == 0)
            {
                for (int i = 0; i < this.pricesProducts.Count; i++)
                {
                    if (this.pricesProducts[i].GetProduct().Equals(typeof(Seed)))
                    {
                        Seed seed = (Seed)this.pricesProducts[i].GetProduct();

                        int initialPrice = this.pricesProducts[i].GetInitialPrice();
                        int maxPriceVariation = this.pricesProducts[i].GetMaxPriceVariation();
                        int variationPrice = seed.GetPriceVariation();

                        int j = 0;
                        Random rnd = new Random();
                        int priceTurn = initialPrice;

                        while (j < 30)
                        {
                            int variation = rnd.Next(3);

                            if (variation == 0)
                            {
                                this.pricesProducts[i].AddPrice(priceTurn);
                                j++;
                            }

                            if (variation == 1)
                            {
                                int price = priceTurn + variationPrice;

                                if (price < initialPrice + maxPriceVariation)
                                {
                                    this.pricesProducts[i].AddPrice(price);
                                    priceTurn = price;
                                    j++;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (variation == 2)
                            {
                                int price = priceTurn - variationPrice;

                                if (price > initialPrice - maxPriceVariation)
                                {
                                    this.pricesProducts[i].AddPrice(price);
                                    priceTurn = price;
                                    j++;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                    
                }
            }
        }
    }
}
