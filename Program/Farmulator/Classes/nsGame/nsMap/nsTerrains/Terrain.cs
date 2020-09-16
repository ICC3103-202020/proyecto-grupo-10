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

        //CONSTRUCTOR
        public Terrain()
        {
            this.blocks = new Block[10, 10];
            this.build = null;
            GenerateBlocks();

        }

        //ACCESOS
        public Block[,] GetBlocks()
        {
            return this.blocks;
        }

        public Build GetBuild()
        {
            return this.build;
        }

        //METODOS DE TERRAIN
        public void Construction(Build build)
        {
            this.build = build;
        }

        public void Deploy()
        {
            this.build = null;
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
