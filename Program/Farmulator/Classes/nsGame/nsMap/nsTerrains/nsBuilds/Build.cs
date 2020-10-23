using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds
{
    [Serializable]
    abstract class Build
    {
        protected string name;
        protected int buyPrice;
        protected int sellPrice;
    }
}
