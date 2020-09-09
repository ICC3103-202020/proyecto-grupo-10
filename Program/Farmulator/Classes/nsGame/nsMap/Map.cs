using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap.nsAssets;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks;

namespace Farmulator.Classes.nsGame.nsMap
{
    class Map
    {
        private Terrain[,] terrains;
        private River river;
        private Lake lake;
        private Farm farm;

        //CONSTRUCTOR
        public Map()
        {
            this.terrains = new Terrain[10, 10];
            GenerateTerrains();
            this.farm = new Farm();
            this.lake = null;
            this.river = null;
        }

        //ACCESO
        public Terrain[,] GetTerrains()
        {
            return this.terrains;
        }

        public River GetRiver()
        {
            return this.river;
        }

        public Lake GetLake()
        {
            return this.lake;
        }

        public Farm GetFarm()
        {
            return this.farm;
        }

        //METODOS
        public void GenerateMap(bool lake, bool river)
        {
            //RESETEAMOS EL MAPA
            ResetMap();
            this.lake = null;
            this.river = null;

            //GENERAMOS RIOS Y/O LAGOS
            if (lake == true)
            {
                this.lake = new Lake();
                this.lake.GenerateLake();
                InsertAssets(this.lake.GetPositions());
            }
            if (river == true)
            {
                this.river = new River();
                this.river.GenerateRiver();
                InsertAssets(this.river.GetPositions(), this.river.GetDirection());
            }

            this.farm.GenerateFarm(this.terrains);

            return;

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

        private void ResetMap()
        {
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            this.terrains[i, j].GetBlocks()[x,y] = new Earth();
                        }
                    }
                }
            }

        }

        private void InsertAssets(List<int[]> positions, bool direction = true)
        {
            if (direction == true)
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    int xPosition = positions[i][0] / 10;
                    int yPosition = positions[i][1] / 10;

                    this.terrains[xPosition, yPosition].GetBlocks()[positions[i][0]%10, positions[i][1]%10] = new Water();
                }
            }
            else
            {
                for (int i = 0; i < positions.Count; i++)
                {
                    int yPosition = positions[i][0] / 10;
                    int xPosition = positions[i][1] / 10;

                    this.terrains[xPosition, yPosition].GetBlocks()[positions[i][1]%10, positions[i][0]%10] = new Water();
                }
            }
            

            return;
        }

    }
}
