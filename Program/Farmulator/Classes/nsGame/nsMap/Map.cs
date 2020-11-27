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
    [Serializable]
    class Map
    {
        private Terrain[,] terrains;
        private River river;
        private Lake lake;
        private Farm farm;

        //CONSTRUCTOR
        public Map(int temperature, int rainfall)
        {
            this.terrains = new Terrain[10, 10];
            GenerateTerrains();
            this.farm = new Farm();
            this.farm.GenerateFarm(this.terrains);
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
        public void GenerateMap(int lake, int river, int temperature, int rainfall)
        {
            //RESETEAMOS MAPA
            ResetMap(temperature, rainfall);

            if(lake == 0)
            {
                this.lake = null;
            }
            
            if(river == 0)
            {
                this.river = null;
            }

            if(lake == 1)
            {
                this.lake = null;
                this.lake = new Lake();
                this.lake.GenerateLake();
                InsertAssets(this.lake.GetPositions());

            }

            if(river == 1)
            {
                this.river = null;
                this.river = new River();
                this.river.GenerateRiver();
                InsertAssets(this.river.GetPositions(), this.river.GetDirection());

            }

            this.farm.GetTerrains().Clear();
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

        private void ResetMap(int temperature, int rainfall)
        {
            Block[,] blockMap = new Block[100, 100];

            //CREAMOS EL MAPA SOLO DE BLOQUES
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {

                    if (this.terrains[i / 10, j / 10].GetBlocks()[i % 10, j % 10].GetType().Equals(typeof(Water)))
                    {
                        Water water = (Water)terrains[i / 10, j / 10].GetBlocks()[i % 10, j % 10];
                        blockMap[i, j] = water;
                    }

                    if (this.terrains[i / 10, j / 10].GetBlocks()[i % 10, j % 10].GetType().Equals(typeof(Earth)))
                    {
                        Earth earth = (Earth)terrains[i / 10, j / 10].GetBlocks()[i % 10, j % 10];
                        blockMap[i, j] = earth;

                    }
                }
            }

            float[][] perlinNoiseAltitude = PerlinNoise.GenerateWhiteNoise(100,100);

            float[][] mapAltitude = PerlinNoise.GenerateSmoothNoise(perlinNoiseAltitude, 6);

            for (int y = 0; y < 100; y++)
            {

                for(int x = 0; x < 100; x++)
                {
                    this.terrains[y / 10, x / 10].GetBlocks()[y % 10, x % 10] = new Earth(mapAltitude[y][x], temperature, rainfall);

                } 
            }

            return;

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
