using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks
{
    [Serializable]
    class Earth:Block
    {
        private int quality;

        //CONSTRUCTOR
        public Earth()
        {
            this.quality = CalculateQuality();
            this.workable = true;
        }

        //ACCESO    
        public bool GetWorkable()
        {
            return this.workable;
        }

        public int GetQuality()
        {
            return this.quality;
        }

        //METODOS
        private int CalculateQuality()
        {
            Random rnd = new Random();

            int quality = rnd.Next(25,100);

            return quality;
        }
    }
}
