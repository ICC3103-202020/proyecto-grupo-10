using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsGame.nsMap.nsAssets
{
    [Serializable]
    class River
    {
        private List<int[]> positions;
        private bool direction;

        //CONSTRUCTOR
        public River()
        {
            this.positions = new List<int[]>();
            this.direction = true;

            GenerateRiver();
        }

        //ACCESOS
        public List<int[]> GetPositions()
        {
            return this.positions;
        }

        public bool GetDirection()
        {
            return this.direction;
        }

        //METODOS
        public void GenerateRiver()
        {
            this.positions.Clear();
            Random rnd = new Random();

            //GENERAMOS LA DIRECCION QUE ESTARA EL RIO
            int direction = rnd.Next(2);

            if(direction == 1)
            {
                this.direction = true;
            }
            else
            {
                this.direction = false;
            }

            //GENERAMOS LAS POSICION DONDE SE UBICA EL RIO
            //(PARA LA GENERACION SE TOMA SIEMPRE COMO SI EL RIO FUERA VERTICAL)

            int xPosition = rnd.Next(2,98);
            int yPosition = 0;

            while(yPosition < 100)
            {
                for(int ySize = 0; ySize < 5; ySize++)
                {
                    int[] blockPosition = { yPosition, xPosition + ( ySize - 2 )};
                    this.positions.Add(blockPosition);
                }

                int nextPositionX = rnd.Next( xPosition - 2 , xPosition + 3 );

                if(nextPositionX > 97 || nextPositionX < 3)
                {
                    continue;
                }
                else
                {
                    xPosition = nextPositionX;
                    yPosition++;
                }

            }

            return;
        }
    }
}
