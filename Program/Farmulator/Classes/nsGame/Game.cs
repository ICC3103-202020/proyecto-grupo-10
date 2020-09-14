using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
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
            this.money = 50000;
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

        //METODOS
        public void NewGame()
        {
            //INSTANCIARA TODOS LOS PRODUCTOS, EDIFICACIONES, CONSUMIBLES AL CREAR UN NUEVO JUEGO

            Seed maiz = new Seed("Maiz", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, 1, 12, 5, 10);
            products.Add(maiz);
            Seed tomato = new Seed("Tomates", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, 1, 12, 5, 10);
            products.Add(tomato);

            Land tomatoLand = new Land("Granja de Tomates", 1500, 500, 100, 100, 0, 1.0, false, tomato, 100, false, false);
            this.builds.Add(tomatoLand);
            Land maizLand = new Land("Granja de Maiz", 1500, 500, 100, 100, 0, 1.0, false, maiz, 100, false, false);
            this.builds.Add(maizLand);

            int[] range = { 3, 2 };
            Animal pig = new Animal("Cerdo", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, range, 12, range, 10);
            products.Add(pig);

            Ranch pigRanch = new Ranch("Rancho de Cerdos", 2500, 1200, 100, 100, 0, 1.0, false, pig, 100);
            this.builds.Add(pigRanch);

            this.market.PriceMarket(products);

            Storage storage = new Storage("Almacen Grande",3000,500,360);

            this.builds.Add(storage);
        }
        public void NextTurn()
        {
            //METODO QUE MANEJARA EL AVANCE DE TURNOS
            this.turn++;
        }

        public void ConstructionBuilding(Terrain terrain, Build build, int cost)
        {
            terrain.Construction(build);

            this.money = this.money - cost;

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
