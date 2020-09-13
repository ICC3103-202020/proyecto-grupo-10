using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts
{
    class Consumable
    {
        private string name;
        private string description;

        public Consumable(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        //ACCESO
        public string GetName()
        {
            return this.name;
        }

        public string GetDescription()
        {
            return this.description;
        }
    }
}
