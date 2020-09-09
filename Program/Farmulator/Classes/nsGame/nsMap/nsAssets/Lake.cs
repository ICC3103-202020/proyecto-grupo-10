using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsAssets
{
    class Lake
    {
        private List<int[]> positions;

        //CONSTRUCTOR
        public Lake()
        {
            this.positions = new List<int[]>();
            GenerateLake();
        }

        //ACCESO
        public List<int[]> GetPositions()
        {
            return this.positions;
        }

        //METODOS
        public void GenerateLake()
        {
            this.positions.Clear();
            Random rnd = new Random();

            int xPosition = rnd.Next(100);
            int yPosition = rnd.Next(100);

            int numberBlock = 0;

            while (numberBlock < 225)
            {
                int[] positionBlock = { xPosition, yPosition };
                this.positions.Add(positionBlock);

                int nextPositionX = rnd.Next( xPosition - 1, xPosition + 2 );
                int nextPositionY = rnd.Next( yPosition - 1, yPosition + 2 );

                if( (nextPositionX > 0 && nextPositionY > 0) && (nextPositionX < 100 && nextPositionY < 100))
                {
                    int[] verify = { nextPositionX, nextPositionY };

                    if (this.positions.Contains(verify))
                    {
                        continue;
                    }
                    else
                    {
                        xPosition = nextPositionX;
                        yPosition = nextPositionY;
                        numberBlock++;
                    }
                }
                else
                {
                    continue;
                }
            }

            return;
        }
    }
}
