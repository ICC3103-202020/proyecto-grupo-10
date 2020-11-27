using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables
{
    [Serializable]
    abstract class Consumable
    {
        protected string name;
        protected string description;
        protected Bitmap bitmap;

    }
}
