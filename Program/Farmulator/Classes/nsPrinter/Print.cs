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
        public static int RenderMenu(List<string> options, string title, bool subMenu = false)
        {
            Console.WriteLine(title);
            List<string> possibleOptions = new List<string>();
            
            for(int i = 0; i < options.Count; i++)
            {
                int optionlength = options[i].Length + 4;

                int lengthBackground = 100 - (optionlength / 2);
                string leftBackground = new string(' ',lengthBackground);

                Console.Write(leftBackground);
                Console.Write((i + 1) + " - " + options[i] + "\n");

                possibleOptions.Add((i+1).ToString());
            }

            while (true)
            {
                string leftTab = new string(' ', 87);
                Console.WriteLine("\n" + leftTab + "Ingrese la opcion deseada:");

                string optionSelect = Console.ReadLine();

                if (possibleOptions.Contains(optionSelect))
                {
                    int optionNumber = Int32.Parse(optionSelect);

                    if(subMenu == false)
                    {
                        Console.Clear();
                        return optionNumber;
                    }
                    else
                    {
                        return optionNumber;
                    }
                }
                else
                {
                    Console.WriteLine(leftTab + "Ingrese una opcion valida");
                }
            }
        }


        public static void RenderMap(Map map)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < 100; j++)
                {                    
                    if (map.GetTerrains()[i / 10, j / 10].GetBlocks()[i % 10, j % 10].GetType().Equals(typeof(Water)))
                    {
                        if (map.GetFarm().GetTerrains().Contains(map.GetTerrains()[i / 10, j / 10]))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write("▒▒");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("██");
                        }
                    }
                    if (map.GetTerrains()[i / 10, j / 10].GetBlocks()[i % 10, j % 10].GetType().Equals(typeof(Earth)))
                    {
                        if (map.GetFarm().GetTerrains().Contains(map.GetTerrains()[i / 10, j / 10]))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write("▒▒");
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("██");
                        }
                    }
                    
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
    }
}
