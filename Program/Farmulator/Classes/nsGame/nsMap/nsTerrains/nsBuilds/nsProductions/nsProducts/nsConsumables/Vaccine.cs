using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables
{
    [Serializable]
    class Vaccine : Consumable
    {
        public Vaccine(Bitmap bitmap, string name, string description)
        {
            this.bitmap = bitmap;
            this.name = name;
            this.description = description;
        }

        //ACCESO
        public Bitmap GetImg()
        {
            return this.bitmap;
        }

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
