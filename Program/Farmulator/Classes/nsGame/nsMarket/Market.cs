using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap;
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
        }

        //ACCESO
        public List<PriceProduct> GetPricesProducts()
        {
            return this.pricesProducts;
        }

        public List<PriceConsumable> GetPricesConsumables()
        {
            return this.pricesConsumables;
        }

        public List<PriceTerrain> GetPricesTerrains()
        {
            return this.pricesTerrains;
        }

        //METODOS
        public void PriceMarketProduct(List<Product> products)
        {
            //INSTANCIAMOS TODOS LOS PRODUCTOS QUE ABRAN EN EL JUEGO JUNTO A SUS PRECIOS
            

            for (int i = 0; i < products.Count; i++)
            {
                PriceProduct nameProduct = new PriceProduct(products[i], 250, 100, 120);
                pricesProducts.Add(nameProduct);
            }

            CalculatePricesProducts(0);

            //MAS ADELANTE BUSCARA Y ABRIRA LOS DATOS DE UN NUEVO MERCADO SERIALIZADO
        }

        public void PriceMarketConsumable(List<Consumable> consumables)
        {
            //INSTANCIAMOS TODOS LOS PRODUCTOS QUE ABRAN EN EL JUEGO JUNTO A SUS PRECIOS


            for (int i = 0; i < consumables.Count; i++)
            {
                PriceConsumable nameProduct = new PriceConsumable(consumables[i], 50);
                pricesConsumables.Add(nameProduct);
            }

            //MAS ADELANTE BUSCARA Y ABRIRA LOS DATOS DE UN NUEVO MERCADO SERIALIZADO
        }

        public void PriceMarketTerrain(Map map)
        {
            for(int i = 0; i < 100; i++)
            {
                PriceTerrain priceTerrain = new PriceTerrain(map.GetTerrains()[i / 10, i % 10], 10000);
                this.pricesTerrains.Add(priceTerrain);
            }
        }

        private void CalculatePricesProducts(int turn)
        {
            if(turn == 0)
            {
                Random rnd = new Random();

                for (int i = 0; i < this.pricesProducts.Count; i++)
                {

                    if (this.pricesProducts[i].GetProduct().GetType() == typeof(Seed))
                    {
                        Seed seed = (Seed)this.pricesProducts[i].GetProduct();

                        int initialPrice = this.pricesProducts[i].GetInitialPrice();
                        int maxPriceVariation = this.pricesProducts[i].GetMaxPriceVariation();
                        int variationPrice = seed.GetPriceVariation();

                        int j = 0;
                        
                        int priceTurn = initialPrice;

                        while (j < 30)
                        {
                            int variation = rnd.Next(0,6);

                            if (variation == 0 || variation == 5)
                            {
                                this.pricesProducts[i].AddPrice(priceTurn);
                                j++;
                            }

                            if (variation == 1 || variation == 4)
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

                            if (variation == 2 || variation == 3)
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
