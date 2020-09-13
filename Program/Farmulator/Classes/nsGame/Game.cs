using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
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

        //METODOS
        public void NewGame()
        {
            //INSTANCIARA TODOS LOS PRODUCTOS, EDIFICACIONES, CONSUMIBLES AL CREAR UN NUEVO JUEGO

            Seed maiz = new Seed("Maiz", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, 1, 12, 5, 10);
            products.Add(maiz);
            Seed tomato = new Seed("Tomates", 3, 20, 2, 15, 10, 3, 5, 25, 3, 15, 1, 12, 5, 10);
            products.Add(tomato);

            this.market.PriceMarket(products);
        }
        public void NextTurn()
        {
            //METODO QUE MANEJARA EL AVANCE DE TURNOS
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
