using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables;
using Farmulator.Classes.nsGame.nsMarket;

namespace Farmulator.Classes.nsGame
{
    class Game
    {
        private int turn;
        private int money;
        private Map map;
        private Market market;
        private DateTime creationDate;
        private DateTime saveDate;
        private List<Build> builds;
        private List<Product> products;
        private List<Consumable> consumables;

        //CONSTRUCTOR
        public Game()
        {
            this.turn = 1;
            this.money = 500000;
            this.map = new Map();
            this.market = new Market();
            this.creationDate = DateTime.Now;
            this.saveDate = DateTime.Now;
            this.products = new List<Product>();
            this.builds = new List<Build>();
            this.consumables = new List<Consumable>();
            NewGame();
        }

        //ACCESO
        public int GetTurn()
        {
            return this.turn;
        }
        public int GetMoney()
        {
            return this.money;
        }
        public Map GetMap()
        {
            return this.map;
        }
        public Market GetMarket()
        {
            return this.market;
        }
        public DateTime GetCreationDate()
        {
            return this.creationDate;
        }
        public DateTime GetSaveDate()
        {
            return this.saveDate;
        }
        public List<Build> GetBuilds()
        {
            return this.builds;
        }

        public List<Consumable> GetConsumables()
        {
            return this.consumables;
        }

        //METODOS
        public void NewGame()
        {
            //INSTANCIARA TODOS LOS PRODUCTOS, EDIFICACIONES, CONSUMIBLES AL CREAR UN NUEVO JUEGO

            Seed maiz = new Seed("Maiz", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, 1, 12, 5, 10);
            products.Add(maiz);
            Seed tomato = new Seed("Tomates", 3, 20, 2, 2, 10, 3, 5, 25, 3, 2, 1, 12, 5, 10);
            products.Add(tomato);

            Land tomatoLand = new Land("Granja de Tomates", 1500, 500, 100, 100, 0, 1, false, tomato, 100, false, false);
            this.builds.Add(tomatoLand);

            Land maizLand = new Land("Granja de Maiz", 1500, 500, 100, 100, 0, 1, false, maiz, 100, false, false);
            this.builds.Add(maizLand);

            int[] range = { 2, 4 };
            Animal pig = new Animal("Cerdo", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, range, 12, range, 10);
            products.Add(pig);
            
            Ranch pigRanch = new Ranch("Rancho de Cerdos", 2500, 1200, 100, 100, 0, 1, false, pig, 100, 0);
            this.builds.Add(pigRanch);

            this.market.PriceMarketProduct(this.products);

            Storage storage = new Storage("Almacen Grande",3000,500,360);

            this.builds.Add(storage);

            //GENERAMOS TODOS LOS CONSUMIBLES

            AnimalWater waterAnimal = new AnimalWater("Agua para animales","Rellena el nivel de agua de los animales");
            this.consumables.Add(waterAnimal);
            AnimalFood foodAnimal = new AnimalFood("Comida para animales", "Rellena el nivel de comida para los animales");
            this.consumables.Add(foodAnimal);
            Irrigation irrigation = new Irrigation("Riego para plantaciones", "Rellena el nivel de agua de una plantacion");
            this.consumables.Add(irrigation);
            Fertilizer fertilizer = new Fertilizer("Fertilizante para plantaciones", "Rellena el nivel de nutrientes de una plantacion");
            this.consumables.Add(fertilizer);
            Vaccine vaccine = new Vaccine("Vacuna para animales", "Cura para la enfermedad de un rancho");
            this.consumables.Add(vaccine);
            Pesticide pesticide = new Pesticide("Pesticida para plantaciones", "Cura las plagas de gusanos de una plantacion");
            this.consumables.Add(pesticide);
            Fungicide fungicide = new Fungicide("Fungicida para plantaciones", "Cura los hongos de una plantacion");
            this.consumables.Add(fungicide);
            Herbicide herbicide = new Herbicide("Herbicida para plantaciones", "Cura las malezas de una plantacion");
            this.consumables.Add(herbicide);


            this.market.PriceMarketConsumable(this.consumables);

            this.market.PriceMarketTerrain(this.map);
            
        }

        public void NextTurn()
        {
            //METODO QUE MANEJARA EL AVANCE DE TURNOS

            this.turn++;

            //GENERAR NUEVOS PRECIOS PARA SEMILLAS

            market.CalculatePricesProducts(this.turn);

            //GENERAR NUEVOS PRECIOS PARA SEMILLAS
            //----------------------------------------------------
            //MADURAR PLANTACIONES/GANADO --- CALCULO DE NUEVA SALUD

            for (int i = 0; i < this.map.GetFarm().GetTerrains().Count; i++)
            {
                if (this.map.GetFarm().GetTerrains()[i].GetBuild() != null)
                {
                    if (this.map.GetFarm().GetTerrains()[i].GetBuild().GetType() == typeof(Ranch))
                    {
                        Ranch ranch = (Ranch)this.map.GetFarm().GetTerrains()[i].GetBuild();
                        ranch.ToMature();

                        //CALCULO DE NUEVA SALUD

                        ranch.HealthPenalty();

                        //CALCULO DE NUEVA SALUD
                        //-----------------------------------
                        //CALCULO DE NIVELES DE AGUA Y COMIDA

                        ranch.FoodWaterConsumption();

                        //CALCULO DE NIVELES DE AGUA Y COMIDA
                        //-----------------------------------
                        //CALCULO DE PROBABILIDADES DE DESARROLLAR ALGUNA ENFERMEDAD

                        ranch.DiseaseProbability();

                        //CALCULO DE PROBABILIDADES DE DESARROLLAR ALGUNA ENFERMEDAD


                    }
                    if (this.map.GetFarm().GetTerrains()[i].GetBuild().GetType() == typeof(Land))
                    {
                        Land land = (Land)this.map.GetFarm().GetTerrains()[i].GetBuild();
                        land.ToMature();

                        //CALCULO DE NUEVA SALUD

                        land.HealthPenalty();

                        //CALCULO DE NUEVA SALUD
                        //-----------------------------------
                        //CALCULO DE NIVELES DE AGUA Y COMIDA

                        land.FoodWaterConsumption();

                        //CALCULO DE NIVELES DE AGUA Y COMIDA
                        //-----------------------------------
                        //CALCULO DE PROBABILIDADES DE DESARROLLAR ALGUNA ENFERMEDAD

                        land.DiseaseProbability();

                        //CALCULO DE PROBABILIDADES DE DESARROLLAR ALGUNA ENFERMEDAD
                    }
                    if(this.map.GetFarm().GetTerrains()[i].GetBuild().GetType() == typeof(Storage))
                    {
                        Storage storage = (Storage)this.map.GetFarm().GetTerrains()[i].GetBuild();

                        //SE DISMINUYE EN 1 LA CALIDAD DE LOS PRODUCTOS ALMACENADOS

                        storage.QualityDecline();
                    }
                    
                }
            }

            //MADURAR PLANTACIONES/GANADO --- CALCULO DE NUEVA SALUD
            //----------------------------------------------------


        }

        public void ConstructionBuilding(Terrain terrain, Build build, int cost)
        {
            terrain.Construction(build);

            this.money = this.money - cost;

        }

        public void ConstructionSell(Terrain terrain, int cost)
        {
            terrain.Destroy();

            this.money = this.money + cost;
        }

        public void BuyConsumables(List<PriceConsumable> consumables, List<int> quantitys, int totalValue)
        {
            this.money -= totalValue;

            for(int i = 0; i < consumables.Count; i++)
            {
                this.map.GetFarm().AddConsumables(consumables[i].GetConsumable(),quantitys[i]);
            }
        }

        public void BuyTerrain(Terrain terrain, int value)
        {
            this.money -= value;

            this.map.GetFarm().AddTerrain(terrain);
        }

        public void SellFinalProduct(Terrain terrain, Storage storage, int price, int quality)
        {
            if(storage != null)
            {
                terrain.CreateFinalProduct(storage, quality);
            }
            else
            {
                this.money += price;
                return;
            }
        }

        public void SellFinalProductStorage(Storage storage, FinalProduct finalProduct, int price)
        {
            this.money += price;

            storage.SellFinalProduct(finalProduct);

            return;
        }

        public bool SaveGame()
        {
            return true;
        }

        public bool LoadGame()
        {
            return true;
        }

        public bool DeleteGame()
        {
            return true;
        }
    }
}
