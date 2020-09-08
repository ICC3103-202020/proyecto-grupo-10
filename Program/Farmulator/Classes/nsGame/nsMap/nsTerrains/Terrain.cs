using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;

namespace Farmulator.Classes.nsGame.nsMap.nsTerrains
{
    class Terrain
    {
        private Block[,] blocks;
        private Build build;

        public Terrain()
        {
            this.blocks = new Block[10, 10];
            GenerateBlocks();

        }

        public void GenerateBlocks()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.blocks[i, j] = new Earth();
                }
            }
        }
    }
}
