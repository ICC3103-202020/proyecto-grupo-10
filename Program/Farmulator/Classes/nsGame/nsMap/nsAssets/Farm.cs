using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsAssets
{
    class Farm
    {
        private List<Terrain> terrains;

        //CONSTRUCTOR
        public Farm()
        {
            this.terrains = new List<Terrain>();
        }

        //ACCESOS
        public List<Terrain> GetTerrains()
        {
            return this.terrains;
        }

        //METODOS
        public void GenerateFarm(Terrain[,] terrainsMap)
        {
            Random rnd = new Random();
            int direction = rnd.Next(2);

            int xMax, yMax, xPosition, yPosition;

            if(direction == 0)
            {
                xMax = 8;
                yMax = 9;
            }
            else
            {
                xMax = 9;
                yMax = 8;
            }

            xPosition = rnd.Next(xMax);
            yPosition = rnd.Next(yMax);

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    if(direction == 0)
                    {
                        Terrain terrain = terrainsMap[xPosition + i, yPosition + j];
                        this.terrains.Add(terrain);
                    }
                    else
                    {
                        Terrain terrain = terrainsMap[xPosition + j, yPosition + i];
                        this.terrains.Add(terrain);
                    }
                }
            }
            return;
        }
    }
}
