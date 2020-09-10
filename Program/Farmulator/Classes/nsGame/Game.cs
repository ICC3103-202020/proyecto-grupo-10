using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap;
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

        //CONSTRUCTOR
        public Game()
        {
            this.turn = 1;
            this.money = 50000;
            this.map = new Map();
            this.market = new Market();
            this.creationDate = DateTime.Now;
            this.saveDate = DateTime.Now;
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
