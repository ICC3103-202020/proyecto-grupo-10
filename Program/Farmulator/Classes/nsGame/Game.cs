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
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace Farmulator.Classes.nsGame
{
    [Serializable]
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
        public Game(int temperature,int rainfall)
        {
            this.turn = 1;
            this.money = 500000;
            this.map = new Map(temperature,rainfall);
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

            Bitmap tomatoImg = new Bitmap("../../Resources/Assets/tomato.gif");
            Land tomatoLand = new Land(tomatoImg, "Granja de Tomates", 1500, 500, 100, 100, 0, 1, false, tomato, 100, false, false);
            this.builds.Add(tomatoLand);

            Bitmap cornImg = new Bitmap("../../Resources/Assets/corn.gif");
            Land maizLand = new Land(cornImg, "Granja de Maiz", 1500, 500, 100, 100, 0, 1, false, maiz, 100, false, false);
            this.builds.Add(maizLand);

            int[] range = { 2, 4 };
            Animal pig = new Animal("Cerdo", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, range, 12, range, 10);
            products.Add(pig);
            
            Bitmap pigImg = new Bitmap("../../Resources/Assets/pig.gif");
            Ranch pigRanch = new Ranch(pigImg ,"Rancho de Cerdos", 2500, 1200, 100, 100, 0, 1, false, pig, 100, 0);
            this.builds.Add(pigRanch);

            this.market.PriceMarketProduct(this.products);

            Bitmap bigStorageImg = new Bitmap("../../Resources/Assets/storage.gif");
            Storage bigStorage = new Storage(bigStorageImg, "Almacen Grande", 3000, 500, 360);

            Bitmap mediumStorageImg = new Bitmap("../../Resources/Assets/medium_storage.gif");
            Storage mediumStorage = new Storage(mediumStorageImg, "Almacen Mediano", 2000, 500, 200);

            Bitmap smallStorageImg = new Bitmap("../../Resources/Assets/small_storage.gif");
            Storage smallStorage = new Storage(smallStorageImg, "Almacen Pequeño", 1500, 500, 100);

            this.builds.Add(bigStorage);
            this.builds.Add(mediumStorage);
            this.builds.Add(smallStorage);

            //GENERAMOS TODOS LOS CONSUMIBLES

            Bitmap animalWaterImg = new Bitmap("../../Resources/Assets/animal_water.gif");
            AnimalWater waterAnimal = new AnimalWater(animalWaterImg,"Agua para animales","Rellena el nivel de agua de los animales");
            this.consumables.Add(waterAnimal);

            Bitmap AnimalFoodImg = new Bitmap("../../Resources/Assets/animal_food.gif");
            AnimalFood foodAnimal = new AnimalFood(AnimalFoodImg,"Comida para animales", "Rellena el nivel de comida para los animales");
            this.consumables.Add(foodAnimal);

            Bitmap IrrigationImg = new Bitmap("../../Resources/Assets/irrigation.gif");
            Irrigation irrigation = new Irrigation(IrrigationImg,"Riego para plantaciones", "Rellena el nivel de agua de una plantacion");
            this.consumables.Add(irrigation);

            Bitmap FertilizerImg = new Bitmap("../../Resources/Assets/fertilizer.gif");
            Fertilizer fertilizer = new Fertilizer(FertilizerImg,"Fertilizante para plantaciones", "Rellena el nivel de nutrientes de una plantacion");
            this.consumables.Add(fertilizer);

            Bitmap VaccineImg = new Bitmap("../../Resources/Assets/vaccine.gif");
            Vaccine vaccine = new Vaccine(VaccineImg,"Vacuna para animales", "Cura para la enfermedad de un rancho");
            this.consumables.Add(vaccine);

            Bitmap PesticideImg = new Bitmap("../../Resources/Assets/pesticide.gif");
            Pesticide pesticide = new Pesticide(PesticideImg,"Pesticida para plantaciones", "Cura las plagas de gusanos de una plantacion");
            this.consumables.Add(pesticide);

            Bitmap FungicideImg = new Bitmap("../../Resources/Assets/fungicide.gif");
            Fungicide fungicide = new Fungicide(FungicideImg,"Fungicida para plantaciones", "Cura los hongos de una plantacion");
            this.consumables.Add(fungicide);

            Bitmap HerbicideImg = new Bitmap("../../Resources/Assets/herbicide.gif");
            Herbicide herbicide = new Herbicide(HerbicideImg,"Herbicida para plantaciones", "Cura las malezas de una plantacion");
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
                terrain.Destroy();
                return;
            }
        }

        public void SellFinalProductStorage(Storage storage, FinalProduct finalProduct, int price)
        {
            this.money += price;

            storage.SellFinalProduct(finalProduct);

            return;
        }

        public bool SaveGame(Game game, string name)
        {

            BinaryFormatter formatter = new BinaryFormatter();
            string path = "../../Resources/Savegames/" + name +".bin";
            Stream stream = new FileStream( path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, game);
            stream.Close();

            this.saveDate = DateTime.Now;

            return true;
        }

        public bool DeleteGame()
        {
            return true;
        }
    }
}
