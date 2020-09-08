using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks
{
    class Earth:Block
    {
        private int quality;

        public Earth()
        {
            this.quality = CalculateQuality();
            this.workable = true;
        }

        private int CalculateQuality()
        {
            Random rnd = new Random();

            int quality = rnd.Next(25,100);

            return quality;
        }
    }
}
