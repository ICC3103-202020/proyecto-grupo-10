using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsAssets
{
    [Serializable]
    class Farm
    {
        private List<Terrain> terrains;
        private List<Consumable> consumables;

        //CONSTRUCTOR
        public Farm()
        {
            this.terrains = new List<Terrain>();
            this.consumables = new List<Consumable>();
        }

        //ACCESOS
        public List<Terrain> GetTerrains()
        {
            return this.terrains;
        }

        public List<Consumable> GetConsumables()
        {
            return this.consumables;
        }

        //METODOS
        public void AddConsumables(Consumable consumable, int quantity)
        {
            for(int i = 0; i < quantity; i++)
            {
                this.consumables.Add(consumable);
            }
        }

        public void ApplyConsumable(Consumable consumable, Build build)
        {
            for(int i = 0; i < this.consumables.Count; i++)
            {
                if (this.consumables[i].GetType() == consumable.GetType())
                {
                    consumables.RemoveAt(i);
                    break;
                }
            }

            for(int j = 0; j < this.terrains.Count; j++)
            {
                if (this.terrains[j].GetBuild() != null)
                {
                    if (this.terrains[j].GetBuild().Equals(build))
                    {

                        if (this.terrains[j].GetBuild().GetType() == typeof(Land))
                        {
                            Land land = (Land)this.terrains[j].GetBuild();
                            land.ApplyConsumable(consumable);
                            break;
                        }
                        if (this.terrains[j].GetBuild().GetType() == typeof(Ranch))
                        {
                            Ranch ranch = (Ranch)this.terrains[j].GetBuild();
                            ranch.ApplyConsumable(consumable);
                            break;
                        }
                    }
                    
                }
            }
        }

        public void AddTerrain(Terrain terrain)
        {
            this.terrains.Add(terrain);
        }

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
