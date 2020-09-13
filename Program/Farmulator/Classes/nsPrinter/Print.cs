using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using Farmulator.Classes.nsGame.nsMarket;
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

        public static List<int> RenderMarket(Market market, Map map, int typeBuy, int buy)
        {
            List<string> possibleOptions = new List<string>();
            List<int> optionsNumbers = new List<int>();
            int optionNumber;

            if (typeBuy == 1)
            {
                if (buy == 1)
                {
                    Terrain selectedTerrain;
                    PriceProduct selectedSeed;
                    List<Terrain> optionsTerrains = new List<Terrain>();
                    List<PriceProduct> optionsSeeds = new List<PriceProduct>();

                    for (int section = 0; section < 3; section++)
                    {
                        possibleOptions.Clear();

                        //SECCION UNO SE ELIGE LA SEMILLA QUE SE DESEA COMPRAR
                        if(section == 0)
                        {

                            string leftTab = new string(' ', 96);
                            Console.WriteLine("\n" + leftTab + "SEMILLAS");

                            int counter = 0;

                            for (int i = 0; i < market.GetPricesProducts().Count; i++)
                            {
                                int optionlength;
                                int lengthBackground;
                                string leftBackground;

                                if (market.GetPricesProducts()[i].GetProduct().GetType() == typeof(Seed))
                                {

                                    int value = market.GetPricesProducts()[i].GetPricesHistory()[market.GetPricesProducts()[i].GetPricesHistory().Count - 1];
                                    Seed seed = (Seed)market.GetPricesProducts()[i].GetProduct();

                                    optionlength = seed.GetName().Length + 18;

                                    lengthBackground = 100 - (optionlength / 2);
                                    leftBackground = new string(' ', lengthBackground);

                                    Console.Write(leftBackground);
                                    Console.Write((counter + 1) + " - " + seed.GetName() + " -- Valor = ¥ " + value.ToString() + "\n");

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsSeeds.Add(market.GetPricesProducts()[i]);
                                }

                            }
                        }

                        //SECCION DOS SE ELIGE EN QUE TERRENO COLOCARLO
                        if (section == 1)
                        {
                            string leftTab = new string(' ', 96);
                            Console.WriteLine("\n" + leftTab + "TERRENOS");

                            int counter = 0;

                            for (int i = 0; i < 100; i++)
                            {
                                int optionlength;
                                int lengthBackground;
                                string leftBackground;

                                if (map.GetFarm().GetTerrains().Contains( map.GetTerrains()[ i / 10, i % 10] ))
                                {

                                    int positionX = i / 10 ;
                                    int positionY = i % 10;
                                    string build = "";

                                    if (map.GetTerrains()[i/10,i%10].GetBuild() == null)
                                    {
                                        build = "Sin Edificacion";
                                    }
                                    if (map.GetTerrains()[i / 10, i % 10].GetBuild() != null)
                                    {
                                        build = map.GetTerrains()[i/10,i%10].GetBuild().GetType().ToString();
                                    }

                                    optionlength = 44;

                                    lengthBackground = 100 - (optionlength / 2);
                                    leftBackground = new string(' ', lengthBackground);

                                    Console.Write(leftBackground);
                                    Console.Write((counter + 1) + " - Terreno [" + positionX + "," + positionY + "]  -- Edificacion = " + build + "\n");

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsTerrains.Add(map.GetTerrains()[i / 10, i % 10]);
                                }

                            }
                        }

                        //SE PREGUNTA SI SE QUIERE DESTRUIR LA EDIFICACION SI ESTA EXISTE Y SE VERIFICA QUE EL DINERO ALCANCE
                        if(section == 2)
                        {
                            Seed seed = (Seed)optionsSeeds[optionsNumbers[0] - 1].GetProduct();
                            Console.WriteLine(seed.GetName());

                            Console.WriteLine();
                        }

                        while (true)
                        {
                            string leftTabOption = new string(' ', 87);
                            Console.WriteLine("\n" + leftTabOption + "Ingrese la opcion deseada:");

                            string optionSelect = Console.ReadLine();

                            if (possibleOptions.Contains(optionSelect))
                            {
                                optionNumber = Int32.Parse(optionSelect);
                                optionsNumbers.Add(optionNumber);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(leftTabOption + "Ingrese una opcion valida");
                            }
                        }

                        

                    }
                }


            }

            return optionsNumbers;
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
