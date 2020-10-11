using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;

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
            int earthCounter = 0;
            for (int j = 0; j < 100; j++)
            {
                if (this.blocks[j / 10, j % 10].GetType() == typeof(Earth))
                {
                    Earth earth = (Earth)this.blocks[j / 10, j % 10];

                    earthCounter++;
                }
            }

            if (build.GetType() == typeof(Ranch))
            {
                Ranch ranch = (Ranch)build;

                Ranch newRanch = new Ranch(ranch.GetName(), ranch.GetBuyPrice(), ranch.GetSellPrice(), ranch.GetHealth(), ranch.GetWater(), ranch.GetMaturity(), ranch.GetFinalProduction(), ranch.GetDisease(), ranch.GetAnimal(), ranch.GetFood(), ranch.GetAnimal().GetUnits() * earthCounter);

                this.build = newRanch;
            }

            if (build.GetType() == typeof(Land))
            {
                Land land = (Land)build;

                Land newLand = new Land(land.GetName(), land.GetBuyPrice(), land.GetSellPrice(), land.GetHealth(), land.GetWater(), land.GetMaturity(), land.GetFinalProduction(), land.GetDisease(), land.GetSeed(), land.GetNutrients(), land.GetWorms(), land.GetUndergrowth());

                this.build = newLand;
            }
            
        }

        public void Destroy()
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

        public void CreateFinalProduct(Storage storage, int quality)
        {

            storage.AddFinalProduct(this.build, quality);

            this.build = null;

        }
    }
}
