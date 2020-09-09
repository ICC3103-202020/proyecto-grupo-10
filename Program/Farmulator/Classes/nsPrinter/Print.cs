using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.nsPrinter
{
    static class Print
    {
        public static int RenderMenu(List<string> options, string title)
        {
            Console.WriteLine(title);
            List<string> possibleOptions = new List<string>();
            
            for(int i = 0; i < options.Count; i++)
            {
                Console.WriteLine((i+1) + " - " + options[i]);
                possibleOptions.Add((i+1).ToString());
            }

            while (true)
            {
                Console.WriteLine("Ingrese la opcion deseada:");
                string optionSelect = Console.ReadLine();

                if(possibleOptions.Contains(optionSelect))
                {
                    int optionNumber = Int32.Parse(optionSelect);
                    return optionNumber;
                }
                else
                {
                    Console.WriteLine("Ingrese una opcion valida");
                }
            }
        }

        public static void RenderMap(Map map)
        {
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine();

                    for (int x = 0; x < 10; x++)
                    {
                        for (int z = 0; z < 10; z++)
                        {
                            if (map.GetTerrains()[x, j].GetBlocks()[i, z].GetType().Equals(typeof(Water)))
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("██");
                            }
                            if (map.GetTerrains()[x, j].GetBlocks()[i, z].GetType().Equals(typeof(Earth)))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("██");
                            }
                        }
                    }
                }
            }
        }
    }
}
