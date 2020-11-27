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
        public Earth(float altitude, int temperature, int rainfall)
        {
            float altitudex100 = altitude * (100 + (rainfall * 40 / 100) - (temperature * 40 / 100));
            int altitudeInt = (int)altitudex100;

            this.quality = altitudeInt;
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

    }
}
