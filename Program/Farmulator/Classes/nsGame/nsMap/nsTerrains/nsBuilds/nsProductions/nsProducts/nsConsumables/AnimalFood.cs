using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables
{
    [Serializable]
    class AnimalFood : Consumable
    {
        public AnimalFood(string name, string description)
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
