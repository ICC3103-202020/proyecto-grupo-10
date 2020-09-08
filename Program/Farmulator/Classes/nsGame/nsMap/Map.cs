using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap.nsAssets;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;

namespace Farmulator.Classes.nsGame.nsMap
{
    class Map
    {
        private Terrain[,] terrains;
        private River river;
        private Lake lake;
        private Farm farm;

        public Map()
        {
            this.terrains = new Terrain[10, 10];
            GenerateTerrains();
            this.farm = new Farm();
            this.lake = null;
            this.river = null;
        }

        public void GenerateMap(bool lake, bool river)
        {
            
        }

        private void GenerateTerrains()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    this.terrains[i, j] = new Terrain();
                }
            }
        }

    }
}
