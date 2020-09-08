using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap;

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

        public Game()
        {
            this.turn = 1;
            this.money = 123456789;
            this.map = new Map();
            this.market = new Market();
            this.creationDate = DateTime.Now;
            this.saveDate = DateTime.Now;
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
