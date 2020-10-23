using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks
{
    [Serializable]
    class Water:Block
    {
        //CONSTRUCTOR
        public Water()
        {
            this.workable = false;
        }

        //ACCESO
        public bool GetWorkable()
        {
            return this.workable;
        }

        //METODOS
    }
}
