using Farmulator.Classes.nsGame;
using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsGame.nsMap.nsAssets;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts.nsConsumables;
using Farmulator.Classes.nsGame.nsMarket;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Farmulator.Classes.nsPrinter
{
    static class Print
    {
        private static Bitmap terrainAssets;
        private static List<Bitmap> grass;
        private static List<Bitmap> grassDirt;
        private static List<Bitmap> dirt;
        private static List<Bitmap> mediumGrass;
        private static List<Bitmap> highGrass;
        private static List<Bitmap> land;
        private static List<Bitmap> water;


        public static int RenderMenu(List<string> options, string title, bool subMenu = false)
        {
            Console.WriteLine(title);
            List<string> possibleOptions = new List<string>();
            
            for(int i = 0; i < options.Count; i++)
            {
                Console.Write(TextCenter((i + 1).ToString() + " - " + options[i] + "\n"));

                possibleOptions.Add((i+1).ToString());
            }

            while (true)
            {
                Console.WriteLine(TextCenter("Ingrese la opcion deseada:"));

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
                    Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                }
            }
        }

        public static bool RenderMarket(Game game, int typeBuy, int buy)
        {
            List<string> possibleOptions = new List<string>();
            List<int> optionsNumbers = new List<int>();
            int optionNumber;


            //--------------------------------------------------------------------------------------------
            //COMPRA DE EDIFICACIONES
            //--------------------------------------------------------------------------------------------

            if (typeBuy == 1)
            {
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################

                //CONSTRUCCION DE UN NUEVO CULTIVO

                possibleOptions.Clear();
                optionsNumbers.Clear();


                if (buy == 1)
                {
                    Terrain selectedTerrain = null;
                    PriceProduct selectedSeed = null;
                    Land selectedLand = null;
                    List<Terrain> optionsTerrains = new List<Terrain>();
                    List<PriceProduct> optionsSeeds = new List<PriceProduct>();

                    for (int section = 0; section < 3; section++)
                    {
                        possibleOptions.Clear();

                        //SECCION UNO - SE ELIGE LA SEMILLA QUE SE DESEA COMPRAR
                        if (section == 0)
                        {
                            Console.WriteLine(TextCenter("SEMILLAS"));

                            int counter = 0;

                            for (int i = 0; i < game.GetMarket().GetPricesProducts().Count; i++)
                            {
                                if (game.GetMarket().GetPricesProducts()[i].GetProduct().GetType() == typeof(Seed))
                                {

                                    int value = game.GetMarket().GetPricesProducts()[i].GetPricesHistory()[game.GetMarket().GetPricesProducts()[i].GetPricesHistory().Count - 1];
                                    Seed seed = (Seed)game.GetMarket().GetPricesProducts()[i].GetProduct();

                                    Console.Write(TextCenter((counter + 1).ToString() + " - " + seed.GetName() + " -- Valor = ¥ " + value.ToString() + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsSeeds.Add(game.GetMarket().GetPricesProducts()[i]);
                                }

                            }
                        }

                        //SECCION DOS SE ELIGE EN QUE TERRENO COLOCARLO
                        if (section == 1)
                        {
                            Console.WriteLine(TextCenter("TERRENOS"));

                            int counter = 0;

                            for (int i = 0; i < 100; i++)
                            {
                                if (game.GetMap().GetFarm().GetTerrains().Contains(game.GetMap().GetTerrains()[i / 10, i % 10]))
                                {

                                    int positionX = i / 10;
                                    int positionY = i % 10;
                                    string build = "";

                                    if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild() == null)
                                    {
                                        build = "Sin Edificacion";
                                    }
                                    if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild() != null)
                                    {
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Land))
                                        {
                                            Land landName = (Land)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = landName.GetName();
                                        }
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Ranch))
                                        {
                                            Ranch ranchName = (Ranch)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = ranchName.GetName();
                                        }
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Storage))
                                        {
                                            Storage storageName = (Storage)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = storageName.GetName();
                                        }
                                    }

                                    Console.Write(TextCenter((counter + 1).ToString() + " - Terreno [" + positionX.ToString() + "," + positionY.ToString() + "]  -- Edificacion = " + build + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsTerrains.Add(game.GetMap().GetTerrains()[i / 10, i % 10]);
                                }

                            }
                        }

                        //SE PREGUNTA SI SE QUIERE DESTRUIR LA EDIFICACION SI ESTA EXISTE Y SE VERIFICA QUE EL DINERO ALCANCE
                        if (section == 2)
                        {
                            selectedSeed = optionsSeeds[optionsNumbers[0] - 1];
                            selectedTerrain = optionsTerrains[optionsNumbers[1] - 1];

                            string optionSelected;

                            if (selectedTerrain.GetBuild() != null)
                            {
                                Console.Write(TextCenter("Desea eliminar la granja actual ? : \n"));
                                Console.Write(TextCenter("1 - Si\n") + TextCenter("2 - No\n"));

                                while (true)
                                {
                                    optionSelected = Console.ReadLine();

                                    if (optionSelected == "1")
                                    {
                                        break;
                                    }
                                    if (optionSelected == "2")
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                                    }
                                }

                            }

                            int valueBuild = 0;

                            for (int i = 0; i < game.GetBuilds().Count; i++)
                            {
                                if (game.GetBuilds()[i].GetType() == typeof(Land))
                                {
                                    Land land = (Land)game.GetBuilds()[i];
                                    Seed seed = (Seed)selectedSeed.GetProduct();

                                    if (land.GetSeed().Equals(seed))
                                    {
                                        selectedLand = land;

                                        if (selectedTerrain.GetBuild() != null)
                                        {
                                            if (selectedTerrain.GetBuild().GetType() == typeof(Land))
                                            {
                                                Land buildExist = (Land)selectedTerrain.GetBuild();
                                                valueBuild = selectedSeed.GetPricesHistory()[selectedSeed.GetPricesHistory().Count - 1] + selectedLand.GetBuyPrice() + buildExist.GetSellPrice();
                                            }
                                            if (selectedTerrain.GetBuild().GetType() == typeof(Storage))
                                            {
                                                Storage buildExist = (Storage)selectedTerrain.GetBuild();
                                                valueBuild = selectedSeed.GetPricesHistory()[selectedSeed.GetPricesHistory().Count - 1] + selectedLand.GetBuyPrice() + buildExist.GetSellPrice();
                                            }
                                            if (selectedTerrain.GetBuild().GetType() == typeof(Ranch))
                                            {
                                                Ranch buildExist = (Ranch)selectedTerrain.GetBuild();
                                                valueBuild = selectedSeed.GetPricesHistory()[selectedSeed.GetPricesHistory().Count - 1] + selectedLand.GetBuyPrice() + buildExist.GetSellPrice();
                                            }

                                        }
                                        else
                                        {
                                            valueBuild = selectedSeed.GetPricesHistory()[selectedSeed.GetPricesHistory().Count - 1] + selectedLand.GetBuyPrice();
                                        }
                                    }
                                }
                            }

                            if (game.GetMoney() < valueBuild)
                            {
                                Console.Write(TextCenter("Dinero Insuficiente"));
                                return false;
                            }

                            Console.Write(TextCenter("Valor Total = " + valueBuild.ToString() + "\n"));

                            game.ConstructionBuilding(selectedTerrain, selectedLand, valueBuild);

                            Console.Write(TextCenter("Construccion realizada con exito\n") + TextCenter("PRESIONA ENTER PARA CONTINUAR"));
                            Console.ReadLine();

                            return true;

                        }

                        while (true)
                        {
                            Console.WriteLine(TextCenter("Ingrese la opcion deseada: "));

                            string optionSelect = Console.ReadLine();

                            if (possibleOptions.Contains(optionSelect))
                            {
                                optionNumber = Int32.Parse(optionSelect);
                                optionsNumbers.Add(optionNumber);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }



                    }
                }

                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################

                //CONSTRUCCION DE UN NUEVO RANCHO

                if (buy == 2)
                {
                    Terrain selectedTerrain = null;
                    PriceProduct selectedAnimal = null;
                    Ranch selectedRanch = null;
                    List<Terrain> optionsTerrains = new List<Terrain>();
                    List<PriceProduct> optionsAnimals = new List<PriceProduct>();

                    for (int section = 0; section < 3; section++)
                    {
                        possibleOptions.Clear();

                        //SECCION UNO - SE ELIGE EL ANIMAL QUE SE DESEA COMPRAR
                        if (section == 0)
                        {
                            Console.WriteLine(TextCenter("ANIMALES"));

                            int counter = 0;

                            for (int i = 0; i < game.GetMarket().GetPricesProducts().Count; i++)
                            {
                                if (game.GetMarket().GetPricesProducts()[i].GetProduct().GetType() == typeof(Animal))
                                {

                                    int value = game.GetMarket().GetPricesProducts()[i].GetInitialPrice();
                                    Animal animal = (Animal)game.GetMarket().GetPricesProducts()[i].GetProduct();

                                    Console.Write(TextCenter((counter + 1).ToString() + " - " + animal.GetName() + " -- Valor = ¥ " + value.ToString() + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsAnimals.Add(game.GetMarket().GetPricesProducts()[i]);
                                }

                            }
                        }

                        //SECCION DOS SE ELIGE EN QUE TERRENO COLOCARLO
                        if (section == 1)
                        {
                            Console.WriteLine(TextCenter("TERRENOS"));

                            int counter = 0;

                            for (int i = 0; i < 100; i++)
                            {
                                if (game.GetMap().GetFarm().GetTerrains().Contains(game.GetMap().GetTerrains()[i / 10, i % 10]))
                                {

                                    int positionX = i / 10;
                                    int positionY = i % 10;
                                    string build = "";

                                    if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild() == null)
                                    {
                                        build = "Sin Edificacion";
                                    }
                                    if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild() != null)
                                    {
                                        if(game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Land))
                                        {
                                            Land landName = (Land)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = landName.GetName();
                                        }
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Ranch))
                                        {
                                            Ranch ranchName = (Ranch)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = ranchName.GetName();
                                        }
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Storage))
                                        {
                                            Storage storageName = (Storage)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = storageName.GetName();
                                        }
                                    }

                                    Console.Write(TextCenter((counter + 1).ToString() + " - Terreno [" + positionX.ToString() + "," + positionY.ToString() + "]  -- Edificacion = " + build + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsTerrains.Add(game.GetMap().GetTerrains()[i / 10, i % 10]);
                                }

                            }
                        }

                        //SE PREGUNTA SI SE QUIERE DESTRUIR LA EDIFICACION SI ESTA EXISTE Y SE VERIFICA QUE EL DINERO ALCANCE
                        if (section == 2)
                        {
                            selectedAnimal = optionsAnimals[optionsNumbers[0] - 1];
                            selectedTerrain = optionsTerrains[optionsNumbers[1] - 1];

                            string optionSelected;

                            if (selectedTerrain.GetBuild() != null)
                            {
                                Console.Write(TextCenter("Desea eliminar la granja actual ? : \n"));
                                Console.Write(TextCenter("1 - Si\n") + TextCenter("2 - No\n"));

                                while (true)
                                {
                                    optionSelected = Console.ReadLine();

                                    if (optionSelected == "1")
                                    {
                                        break;
                                    }
                                    if (optionSelected == "2")
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                                    }
                                }

                            }

                            int valueBuild = 0;

                            for (int i = 0; i < game.GetBuilds().Count; i++)
                            {
                                if (game.GetBuilds()[i].GetType() == typeof(Ranch))
                                {
                                    Ranch ranch = (Ranch)game.GetBuilds()[i];
                                    Animal animal = (Animal)selectedAnimal.GetProduct();

                                    if (ranch.GetAnimal().Equals(animal))
                                    {
                                        selectedRanch = ranch;

                                        if (selectedTerrain.GetBuild() != null)
                                        {
                                            if (selectedTerrain.GetBuild().GetType() == typeof(Land))
                                            {
                                                Land buildExist = (Land)selectedTerrain.GetBuild();
                                                valueBuild = selectedAnimal.GetInitialPrice() + selectedRanch.GetBuyPrice() + buildExist.GetSellPrice();
                                            }
                                            if (selectedTerrain.GetBuild().GetType() == typeof(Storage))
                                            {
                                                Storage buildExist = (Storage)selectedTerrain.GetBuild();
                                                valueBuild = selectedAnimal.GetInitialPrice() + selectedRanch.GetBuyPrice() + buildExist.GetSellPrice();
                                            }
                                            if (selectedTerrain.GetBuild().GetType() == typeof(Ranch))
                                            {
                                                Ranch buildExist = (Ranch)selectedTerrain.GetBuild();
                                                valueBuild = selectedAnimal.GetInitialPrice() + selectedRanch.GetBuyPrice() + buildExist.GetSellPrice();
                                            }

                                        }
                                        else
                                        {
                                            valueBuild = selectedAnimal.GetInitialPrice() + selectedRanch.GetBuyPrice();
                                        }
                                    }
                                }
                            }

                            if (game.GetMoney() < valueBuild)
                            {
                                Console.Write(TextCenter("Dinero Insuficiente"));
                                return false;
                            }

                            Console.Write(TextCenter("Valor Total = " + valueBuild.ToString() + "\n"));

                            game.ConstructionBuilding(selectedTerrain, selectedRanch, valueBuild);

                            Console.Write(TextCenter("Construccion realizada con exito\n") + TextCenter("PRESIONA ENTER PARA CONTINUAR"));
                            Console.ReadLine();

                            return true;

                        }

                        while (true)
                        {
                            Console.WriteLine(TextCenter("Ingrese la opcion deseada: "));

                            string optionSelect = Console.ReadLine();

                            if (possibleOptions.Contains(optionSelect))
                            {
                                optionNumber = Int32.Parse(optionSelect);
                                optionsNumbers.Add(optionNumber);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }



                    }
                }

                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################

                //CONSTRUCCION DE UN NUEVO ALMACEN

                if (buy == 3)
                {
                    Terrain selectedTerrain = null;
                    Storage selectedStorage = null;
                    List<Terrain> optionsTerrains = new List<Terrain>();
                    List<Storage> optionsStorages = new List<Storage>();

                    for (int section = 0; section < 3; section++)
                    {
                        possibleOptions.Clear();

                        //SECCION UNO - SE ELIGE EL ALMACEN QUE SE DESEA COMPRAR
                        if (section == 0)
                        {
                            Console.WriteLine(TextCenter("ALMACENES"));

                            int counter = 0;

                            for (int i = 0; i < game.GetBuilds().Count; i++)
                            {
                                if (game.GetBuilds()[i].GetType() == typeof(Storage))
                                {

                                    Storage storage = (Storage)game.GetBuilds()[i];
                                    int value = storage.GetBuyPrice();

                                    Console.Write(TextCenter((counter + 1).ToString() + " - " + storage.GetName() + " -- Valor = ¥ " + value.ToString() + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsStorages.Add(storage);
                                }

                            }
                        }

                        //SECCION DOS SE ELIGE EN QUE TERRENO COLOCARLO
                        if (section == 1)
                        {
                            Console.WriteLine(TextCenter("TERRENOS"));

                            int counter = 0;

                            for (int i = 0; i < 100; i++)
                            {
                                if (game.GetMap().GetFarm().GetTerrains().Contains(game.GetMap().GetTerrains()[i / 10, i % 10]))
                                {

                                    int positionX = i / 10;
                                    int positionY = i % 10;
                                    string build = "";

                                    if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild() == null)
                                    {
                                        build = "Sin Edificacion";
                                    }
                                    if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild() != null)
                                    {
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Land))
                                        {
                                            Land landName = (Land)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = landName.GetName();
                                        }
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Ranch))
                                        {
                                            Ranch ranchName = (Ranch)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = ranchName.GetName();
                                        }
                                        if (game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild().GetType() == typeof(Storage))
                                        {
                                            Storage storageName = (Storage)game.GetMap().GetTerrains()[i / 10, i % 10].GetBuild();
                                            build = storageName.GetName();
                                        }
                                    }

                                    Console.Write(TextCenter((counter + 1).ToString() + " - Terreno [" + positionX.ToString() + "," + positionY.ToString() + "]  -- Edificacion = " + build + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsTerrains.Add(game.GetMap().GetTerrains()[i / 10, i % 10]);
                                }

                            }
                        }

                        //SE PREGUNTA SI SE QUIERE DESTRUIR LA EDIFICACION SI ESTA EXISTE Y SE VERIFICA QUE EL DINERO ALCANCE
                        if (section == 2)
                        {
                            selectedStorage = optionsStorages[optionsNumbers[0] - 1];
                            selectedTerrain = optionsTerrains[optionsNumbers[1] - 1];

                            string optionSelected;

                            if (selectedTerrain.GetBuild() != null)
                            {
                                Console.Write(TextCenter("Desea eliminar la construccion actual ? : \n"));
                                Console.Write(TextCenter("1 - Si\n") + TextCenter("2 - No\n"));

                                while (true)
                                {
                                    optionSelected = Console.ReadLine();

                                    if (optionSelected == "1")
                                    {
                                        break;
                                    }
                                    if (optionSelected == "2")
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                                    }
                                }

                            }

                            int valueBuild = 0;

                            for (int i = 0; i < game.GetBuilds().Count; i++)
                            {
                                if (game.GetBuilds()[i].GetType() == typeof(Storage))
                                {
                                    Storage storage = (Storage)game.GetBuilds()[i];

                                    if (selectedTerrain.GetBuild() != null)
                                    {
                                        if (selectedTerrain.GetBuild().GetType() == typeof(Land))
                                        {
                                            Land buildExist = (Land)selectedTerrain.GetBuild();
                                            valueBuild = selectedStorage.GetBuyPrice() + buildExist.GetSellPrice();
                                        }
                                        if (selectedTerrain.GetBuild().GetType() == typeof(Storage))
                                        {
                                            Storage buildExist = (Storage)selectedTerrain.GetBuild();
                                            valueBuild = selectedStorage.GetBuyPrice() + buildExist.GetSellPrice();
                                        }
                                        if (selectedTerrain.GetBuild().GetType() == typeof(Ranch))
                                        {
                                            Ranch buildExist = (Ranch)selectedTerrain.GetBuild();
                                            valueBuild = selectedStorage.GetBuyPrice() + buildExist.GetSellPrice();
                                        }

                                    }
                                    else
                                    {
                                        valueBuild = selectedStorage.GetBuyPrice();
                                    }
                                   
                                }
                            }

                            if (game.GetMoney() < valueBuild)
                            {
                                Console.Write(TextCenter("---- NO POSEE DINERO PARA COMPRAR -----"));
                                Console.Write(TextCenter("PRESIONE ENTER PARA SALIR"));
                                Console.ReadLine();
                                return false;
                            }

                            Console.Write(TextCenter("Valor Total = " + valueBuild.ToString() + "\n"));

                            game.ConstructionBuilding(selectedTerrain, selectedStorage, valueBuild);

                            Console.Write(TextCenter("Construccion realizada con exito\n") + TextCenter("PRESIONA ENTER PARA CONTINUAR"));
                            Console.ReadLine();

                            return true;

                        }

                        while (true)
                        {
                            Console.WriteLine(TextCenter("Ingrese la opcion deseada: "));

                            string optionSelect = Console.ReadLine();

                            if (possibleOptions.Contains(optionSelect))
                            {
                                optionNumber = Int32.Parse(optionSelect);
                                optionsNumbers.Add(optionNumber);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }



                    }
                }

                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################
                //##############################################################################################################################################################################################

                //DESTRUCCION DE UN EDIFICIO

                if (buy == 4)
                {
                    Terrain selectedTerrain = null;
                    List<Terrain> optionsTerrains = new List<Terrain>();
                    int value = 0;

                    for (int section = 0; section < 2; section++)
                    {
                        possibleOptions.Clear();

                        //SECCION UNO - SE ELIGE EL EDIFICIO QUE SE DESEA ELIMINAR
                        if (section == 0)
                        {
                            Console.WriteLine(TextCenter("EDIFICACIONES"));

                            int counter = 0;

                            for (int i = 0; i < game.GetMap().GetFarm().GetTerrains().Count; i++)
                            {

                                if(game.GetMap().GetFarm().GetTerrains()[i].GetBuild() != null)
                                {
                                    string build = "";

                                    if(game.GetMap().GetFarm().GetTerrains()[i].GetBuild().GetType() == typeof(Land))
                                    {
                                        Land land = (Land)game.GetMap().GetFarm().GetTerrains()[i].GetBuild();
                                        build = land.GetName() + " -- Valor por destruccion = ¥ ";

                                        value = land.GetSellPrice()*(-1);
                                    }

                                    if (game.GetMap().GetFarm().GetTerrains()[i].GetBuild().GetType() == typeof(Ranch))
                                    {
                                        Ranch ranch = (Ranch)game.GetMap().GetFarm().GetTerrains()[i].GetBuild();
                                        build = ranch.GetName() + " -- Valor por destruccion = ¥ ";

                                        value = ranch.GetSellPrice() * (-1);
                                    }

                                    if (game.GetMap().GetFarm().GetTerrains()[i].GetBuild().GetType() == typeof(Storage))
                                    {
                                        Storage storage = (Storage)game.GetMap().GetFarm().GetTerrains()[i].GetBuild();
                                        build = storage.GetName() + " -- Valor por venta = ¥ ";

                                        value += (storage.GetSellPrice() * (-1));

                                        for(int j = 0; j < storage.GetFinalProducts().Count; j++)
                                        {
                                            int quality = storage.GetFinalProducts()[j].GetQuality();

                                            if(storage.GetFinalProducts()[j].GetProduct().GetType() == typeof(Seed))
                                            {
                                                Seed seed = (Seed)storage.GetFinalProducts()[j].GetProduct();

                                                for(int x = 0; x < game.GetMarket().GetPricesProducts().Count; x++)
                                                {
                                                    if (game.GetMarket().GetPricesProducts()[x].Equals(seed))
                                                    {
                                                        value += quality * game.GetMarket().GetPricesProducts()[x].GetSellPrice();
                                                    }
                                                }
                                            }

                                            if (storage.GetFinalProducts()[j].GetProduct().GetType() == typeof(Animal))
                                            {
                                                Animal animal = (Animal)storage.GetFinalProducts()[j].GetProduct();

                                                for (int x = 0; x < game.GetMarket().GetPricesProducts().Count; x++)
                                                {
                                                    if (game.GetMarket().GetPricesProducts()[x].Equals(animal))
                                                    {
                                                        value += quality * game.GetMarket().GetPricesProducts()[x].GetSellPrice();
                                                    }
                                                }
                                            }

                                            //MEJORAR CALCULO DE VENTA DE UN ALMACEN
                                        }
                                    }


                                    Console.Write(TextCenter((counter + 1).ToString() + " - " + build + value.ToString() + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsTerrains.Add(game.GetMap().GetFarm().GetTerrains()[i]);
                                }

                            }

                            if(counter == 0)
                            {
                                Console.WriteLine(TextCenter("NO POSEE EDIFICIOS PARA DESTRUIR O VENDER\n" + TextCenter("PRESIONE ENTER PARA VOLVER")));
                                Console.ReadLine();

                                return false;
                            }
                        }                        

                        //SE PREGUNTA SI ESTA SEGURO DE DESTRUIR ESE EDIFICIO

                        if (section == 1)
                        {
                            selectedTerrain = optionsTerrains[optionsNumbers[0] - 1];

                            string optionSelected;

                            Console.Write(TextCenter("Esta seguro de eliminar este edificio ? : \n"));
                            Console.Write(TextCenter("1 - Si\n") + TextCenter("2 - No\n"));

                            while (true)
                            {
                                optionSelected = Console.ReadLine();

                                if (optionSelected == "1")
                                {
                                    break;
                                }
                                if (optionSelected == "2")
                                {
                                    return false;
                                }
                                else
                                {
                                    Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                                }
                            }


                            if (game.GetMoney() < value)
                            {
                                Console.Write(TextCenter("Dinero Insuficiente\n"));
                                return false;
                            }

                            Console.Write(TextCenter("Valor Total = " + value.ToString() + "\n"));

                            game.ConstructionSell(selectedTerrain, value);

                            Console.Write(TextCenter("Destruccion realizada con exito\n") + TextCenter("PRESIONA ENTER PARA CONTINUAR"));
                            Console.ReadLine();

                            return true;

                        }

                        while (true)
                        {
                            Console.WriteLine(TextCenter("Ingrese la opcion deseada: "));

                            string optionSelect = Console.ReadLine();

                            if (possibleOptions.Contains(optionSelect))
                            {
                                optionNumber = Int32.Parse(optionSelect);
                                optionsNumbers.Add(optionNumber);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }



                    }
                }

            }

            //--------------------------------------------------------------------------------------------
            //COMPRA DE CONSUMIBLES
            //--------------------------------------------------------------------------------------------
            if (typeBuy == 2)
            {

                optionsNumbers.Clear();

                List<PriceConsumable> selectedsConsumables = new List<PriceConsumable>();
                List<PriceConsumable> optionsConsumables = new List<PriceConsumable>();
                List<int> selectedQuantity = new List<int>();

                Console.WriteLine(TextCenter("CONSUMIBLES\n"));

                bool exit = true;

                while (exit)
                {
                    optionsConsumables.Clear();
                    possibleOptions.Clear();
                    int counter = 0;

                    for (int i = 0; i < game.GetMarket().GetPricesConsumables().Count; i++)
                    {

                        int value = game.GetMarket().GetPricesConsumables()[i].GetPrice();

                        string nameConsumable = "";

                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(AnimalFood))
                        {
                            AnimalFood animalFood = (AnimalFood)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();
                        }
                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(AnimalWater))
                        {
                            AnimalWater animalFood = (AnimalWater)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();
                        }
                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(Fertilizer))
                        {
                            Fertilizer animalFood = (Fertilizer)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();
                        }
                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(Irrigation))
                        {
                            Irrigation animalFood = (Irrigation)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();
                        }
                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(Pesticide))
                        {
                            Pesticide animalFood = (Pesticide)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();
                        }
                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(Herbicide))
                        {
                            Herbicide animalFood = (Herbicide)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();

                        }
                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(Fungicide))
                        {
                            Fungicide animalFood = (Fungicide)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();
                        }
                        if (game.GetMarket().GetPricesConsumables()[i].GetConsumable().GetType() == typeof(Vaccine))
                        {
                            Vaccine animalFood = (Vaccine)game.GetMarket().GetPricesConsumables()[i].GetConsumable();
                            nameConsumable = animalFood.GetName();
                        }

                        Console.Write(TextCenter((counter + 1).ToString() + " - " + nameConsumable + " -- Valor = ¥ " + value.ToString() + "\n"));

                        counter++;
                        possibleOptions.Add(counter.ToString());
                        optionsConsumables.Add(game.GetMarket().GetPricesConsumables()[i]);

                    }
                        
                    while (true)
                    {
                        Console.WriteLine(TextCenter("Ingrese la opcion deseada: "));

                        string optionSelect = Console.ReadLine();

                        if (possibleOptions.Contains(optionSelect))
                        {
                            optionNumber = Int32.Parse(optionSelect);
                            optionsNumbers.Add(optionNumber);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                        }
                    }

                    //SELECCIONAMOS CANTIDAD DE CONSUMIBLES A COMPRAR
                    while (true)
                    {
                        Console.WriteLine(TextCenter("Ingrese la cantidad que desea comprar : "));

                        string optionSelect = Console.ReadLine();
                        List<char> numbers = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                        int checker = 0;

                        for(int letter = 0; letter < optionSelect.Length; letter++)
                        {
                            if (!numbers.Contains(optionSelect[letter]))
                            {
                                checker = 1;
                            }
                            
                        }
                        
                        if(checker == 0 && optionSelect != "")
                        {
                            int quantity = Int32.Parse(optionSelect);
                            selectedQuantity.Add(quantity);
                            selectedsConsumables.Add(optionsConsumables[optionsNumbers[0] - 1 ]);
                            break;
                        }
                        if(checker == 1 || optionSelect != "")
                        {
                            Console.WriteLine(TextCenter("Ingrese solo numeros"));
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine(TextCenter("Desea seguir comprando ? :\n"));
                        Console.WriteLine(TextCenter("1 - Si\n") + TextCenter("2 - No"));

                        string optionSelect = Console.ReadLine();

                        if (optionSelect == "1")
                        {
                            break;
                        }

                        if (optionSelect == "2")
                        {
                            exit = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                        }
                    }
                    


                }

                int totalValue = 0;

                Console.WriteLine(TextCenter("LISTA DE COMPRAS"));

                for(int j = 0; j < selectedsConsumables.Count; j++)
                {
                    totalValue += selectedsConsumables[j].GetPrice() * selectedQuantity[j];
                    string nameConsumable = "";

                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(AnimalFood))
                    {
                        AnimalFood animalFood = (AnimalFood)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();
                    }
                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(AnimalWater))
                    {
                        AnimalWater animalFood = (AnimalWater)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();
                    }
                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(Fertilizer))
                    {
                        Fertilizer animalFood = (Fertilizer)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();
                    }
                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(Irrigation))
                    {
                        Irrigation animalFood = (Irrigation)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();
                    }
                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(Pesticide))
                    {
                        Pesticide animalFood = (Pesticide)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();
                    }
                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(Herbicide))
                    {
                        Herbicide animalFood = (Herbicide)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();

                    }
                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(Fungicide))
                    {
                        Fungicide animalFood = (Fungicide)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();
                    }
                    if (selectedsConsumables[j].GetConsumable().GetType() == typeof(Vaccine))
                    {
                        Vaccine animalFood = (Vaccine)selectedsConsumables[j].GetConsumable();
                        nameConsumable = animalFood.GetName();
                    }

                    Console.WriteLine(TextCenter((j+1).ToString() + " - " + nameConsumable + " x " + selectedQuantity[j].ToString() + " -- Valor = ¥ " + (selectedsConsumables[j].GetPrice() * selectedQuantity[j]).ToString()));
                }

                Console.WriteLine(TextCenter(" -- Valor total = ¥ " + totalValue.ToString() + "\n"));

                if(totalValue > game.GetMoney())
                {
                    Console.WriteLine(TextCenter("----- No posee dinero suficiente para hacer la compra -----"));
                    Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));

                    Console.ReadLine();
                    return false;
                }

                if (totalValue <= game.GetMoney())
                {

                    game.BuyConsumables(selectedsConsumables, selectedQuantity, totalValue);

                    Console.WriteLine(TextCenter("----- Compra realizada con exito -----"));
                    Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));

                    Console.ReadLine();
                    return true;
                }



            }

            //--------------------------------------------------------------------------------------------
            //COMPRA DE TERRENOS
            //--------------------------------------------------------------------------------------------
            if (typeBuy == 3)
            {
                optionsNumbers.Clear();

                PriceTerrain selectedTerrain = null;
                List<PriceTerrain> optionsTerrains = new List<PriceTerrain>();

                Console.WriteLine(TextCenter("TERRENOS\n"));

                optionsTerrains.Clear();
                possibleOptions.Clear();
                int counter = 0;
                int positionX = 0;
                int positionY = 0;
                int totalValue = 0;
                bool exit = true;

                while (exit)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        positionX = i / 10;
                        positionY = i % 10;

                        if (!game.GetMap().GetFarm().GetTerrains().Contains(game.GetMap().GetTerrains()[positionX, positionY]))
                        {

                            for (int j = 0; j < game.GetMarket().GetPricesTerrains().Count; j++)
                            {

                                if (game.GetMarket().GetPricesTerrains()[j].GetTerrain().Equals(game.GetMap().GetTerrains()[positionX, positionY]))
                                {
                                    int value = game.GetMarket().GetPricesTerrains()[j].GetPrice();
                                    PriceTerrain terrain = game.GetMarket().GetPricesTerrains()[j];

                                    Console.Write(TextCenter((counter + 1).ToString() + " - Terreno [" + positionX.ToString() + "," + positionY.ToString() + "] -- Valor = ¥ " + value.ToString() + "\n"));

                                    counter++;
                                    possibleOptions.Add(counter.ToString());
                                    optionsTerrains.Add(game.GetMarket().GetPricesTerrains()[j]);
                                }
                            }
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine(TextCenter("Ingrese la opcion deseada: "));

                        string optionSelect = Console.ReadLine();

                        if (possibleOptions.Contains(optionSelect))
                        {
                            optionNumber = Int32.Parse(optionSelect);
                            optionsNumbers.Add(optionNumber);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                        }
                    }


                    int quality = 0;
                    int counterEarth = 0;
                    selectedTerrain = optionsTerrains[optionsNumbers[0] - 1];

                    Console.WriteLine(TextCenter("TERRENO COMPRADO"));

                    for (int z = 0; z < 100; z++)
                    {
                        if (game.GetMap().GetTerrains()[z / 10, z % 10].Equals(selectedTerrain.GetTerrain()))
                        {
                            positionX = z / 10;
                            positionY = z % 10;

                        }

                        if (selectedTerrain.GetTerrain().GetBlocks()[z / 10, z % 10].GetType() == typeof(Earth))
                        {
                            Earth block = (Earth)selectedTerrain.GetTerrain().GetBlocks()[z / 10, z % 10];

                            quality += block.GetQuality();

                            counterEarth++;
                        }

                    }

                    totalValue = (quality / counterEarth) * (counterEarth / 100) * selectedTerrain.GetPrice();

                    Console.Write(TextCenter(" - Terreno [" + positionX.ToString() + "," + positionY.ToString() + " -- Valor = ¥ " + totalValue.ToString() + "\n"));

                    while (true)
                    {
                        Console.WriteLine(TextCenter("Desea comprar este terreno ? :\n"));
                        Console.WriteLine(TextCenter("1 - Si\n") + TextCenter("2 - Comprar otro terreno\n") + TextCenter("3 - Volver al mercado\n"));

                        string optionSelect = Console.ReadLine();

                        if (optionSelect == "1")
                        {
                            exit = false;
                            break;
                        }

                        if (optionSelect == "2")
                        {
                            break;
                        }

                        if (optionSelect == "3")
                        {
                            return false;
                        }

                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                        }
                    }

                }

                if (totalValue > game.GetMoney())
                {
                    Console.WriteLine(TextCenter("----- No posee dinero suficiente para hacer la compra -----"));
                    Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));

                    Console.ReadLine();
                    return false;
                }

                if (totalValue <= game.GetMoney())
                {

                    game.BuyTerrain(selectedTerrain.GetTerrain(), totalValue);

                    Console.WriteLine(TextCenter("----- Compra realizada con exito -----"));
                    Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));

                    Console.ReadLine();
                    return true;
                }
            }

            if (typeBuy == 4)
            {
                //--------------------------------------------------------------------------------------------
                //PRECIOS HISTORICOS POR SEMILLA
                //--------------------------------------------------------------------------------------------

                PriceProduct selectedSeed = null;
                List<PriceProduct> optionsSeeds = new List<PriceProduct>();

                bool exit = true;

                while (exit)
                {
                    possibleOptions.Clear();
                    optionsNumbers.Clear();
                    optionsSeeds.Clear();

                    Console.WriteLine(TextCenter("SEMILLAS"));

                    int counter = 0;

                    for (int i = 0; i < game.GetMarket().GetPricesProducts().Count; i++)
                    {
                        if (game.GetMarket().GetPricesProducts()[i].GetProduct().GetType() == typeof(Seed))
                        {

                            int value = game.GetMarket().GetPricesProducts()[i].GetPricesHistory()[game.GetMarket().GetPricesProducts()[i].GetPricesHistory().Count - 1];
                            Seed seed = (Seed)game.GetMarket().GetPricesProducts()[i].GetProduct();

                            Console.Write(TextCenter((counter + 1).ToString() + " - " + seed.GetName() + " -- Ultimo valor = ¥ " + value.ToString() + "\n"));

                            counter++;
                            possibleOptions.Add(counter.ToString());
                            optionsSeeds.Add(game.GetMarket().GetPricesProducts()[i]);
                        }

                    }

                    while (true)
                    {
                        Console.WriteLine(TextCenter("Ingrese la opcion deseada: "));

                        string optionSelect = Console.ReadLine();

                        if (possibleOptions.Contains(optionSelect))
                        {
                            optionNumber = Int32.Parse(optionSelect);
                            optionsNumbers.Add(optionNumber);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                        }
                    }

                    selectedSeed = optionsSeeds[optionsNumbers[0] - 1];

                    for (int j = 0; j < selectedSeed.GetPricesHistory().Count; j++)
                    {
                        int price = selectedSeed.GetPricesHistory()[j];

                        Console.Write(TextCenter("Turno " + (j + 1).ToString()  + " -- Valor = ¥ " + price.ToString() + "\n" ));
                    }

                    while (true)
                    {
                        Console.WriteLine(TextCenter("Desea ver otro historial ? :\n"));
                        Console.WriteLine(TextCenter("1 - Si\n") + TextCenter("2 - No") );

                        string optionSelect = Console.ReadLine();

                        if (optionSelect == "1")
                        {
                            break;
                        }

                        if (optionSelect == "2")
                        {
                            exit = false;
                            break;
                        }

                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                        }
                    }

                }
            }

            return false;
        }

        public static bool RenderFarmManagement(Game game, int typeManagementBuild, int typeManagement )
        {
             
            //---------------------
            //ADMINISTRACION PRODUCCION
            if(typeManagementBuild == 0)
            {
                List<string> options = new List<string>();
                List<Build> builds = new List<Build>();
                List<Consumable> consumables = game.GetMap().GetFarm().GetConsumables();
                Consumable consumableSelected = null;
                int buildSelected;
                int aggregateSelection;

                //----------------------
                //AGREGAR AGUA O COMIDA
                if(typeManagement == 0)
                {
                    options.Clear();
                    builds.Clear();
                    int counter = 0;
                    //IMPRIMIMOS LAS PLANTACIONES O GANADOS
                    for(int i = 0; i < 100; i++)
                    {
                        string name = "";
                        int positionX = i / 10;
                        int positionY = i % 10;

                        if(game.GetMap().GetTerrains()[positionX , positionY].GetBuild() != null)
                        {
                            if(game.GetMap().GetTerrains()[positionX , positionY].GetBuild().GetType() == typeof(Land))
                            {
                                Land land = (Land)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                                name = land.GetName();
                                counter++;
                                Console.WriteLine(TextCenter(counter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                                options.Add(counter.ToString());
                                builds.Add(land);
                            }

                            if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild().GetType() == typeof(Ranch))
                            {
                                Ranch ranch = (Ranch)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                                name = ranch.GetName();
                                counter++;
                                Console.WriteLine(TextCenter(counter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                                options.Add(counter.ToString());
                                builds.Add(ranch);
                            }
                        }
                    }

                    //SELECCIONAMOS LA PLANTACION O GANADO
                    while (true)
                    {
                        Console.WriteLine(TextCenter("Ingrese la produccion que desea agregar agua o comida: "));

                        string optionSelect = Console.ReadLine();

                        if (options.Contains(optionSelect))
                        {
                            buildSelected = Int32.Parse(optionSelect);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                        }
                    }

                    //AGREGAMOS AGUA O COMIDA
                    while (true)
                    {
                        if (builds[buildSelected - 1].GetType() == typeof(Land))
                        {
                            Console.WriteLine(TextCenter("¿Que desea hacer?"));
                            Console.WriteLine(TextCenter("1 - Regar plantacion"));
                            Console.WriteLine(TextCenter("2 - Agregar nutrientes"));
                        }

                        if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                        {
                            Console.WriteLine(TextCenter("¿Que desea hacer?"));
                            Console.WriteLine(TextCenter("1 - Agregar agua a los animales"));
                            Console.WriteLine(TextCenter("2 - Agregar comida a los animales"));
                        }

                        string optionSelect = Console.ReadLine();

                        if (optionSelect == "1")
                        {
                            if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                            {
                                for(int m = 0; m < game.GetConsumables().Count; m++)
                                {
                                    if(game.GetConsumables()[m].GetType() == typeof(AnimalWater))
                                    {
                                        consumableSelected = game.GetConsumables()[m];
                                    }
                                }
                            }
                            if (builds[buildSelected - 1].GetType() == typeof(Land))
                            {
                                for (int m = 0; m < game.GetConsumables().Count; m++)
                                {
                                    if (game.GetConsumables()[m].GetType() == typeof(Irrigation))
                                    {
                                        consumableSelected = game.GetConsumables()[m];
                                    }
                                }
                            }

                            aggregateSelection = Int32.Parse(optionSelect);
                            break;
                        }
                        if (optionSelect == "2")
                        {
                            if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                            {
                                for (int m = 0; m < game.GetConsumables().Count; m++)
                                {
                                    if (game.GetConsumables()[m].GetType() == typeof(AnimalFood))
                                    {
                                        consumableSelected = game.GetConsumables()[m];
                                    }
                                }
                            }
                            if (builds[buildSelected - 1].GetType() == typeof(Land))
                            {
                                for (int m = 0; m < game.GetConsumables().Count; m++)
                                {
                                    if (game.GetConsumables()[m].GetType() == typeof(Fertilizer))
                                    {
                                        consumableSelected = game.GetConsumables()[m];
                                    }
                                }
                            }

                            aggregateSelection = Int32.Parse(optionSelect);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                        }
                    }

                    //REVISION SI POSEE O NO DE ESE CONSUMIBLE
                    int quantityConsumable = 0;

                    for(int a = 0; a < consumables.Count(); a++)
                    {
                        if (builds[buildSelected - 1].GetType() == typeof(Land))
                        {
                            if(aggregateSelection == 1)
                            {
                                if (consumables[a].GetType() == typeof(Irrigation))
                                {
                                    quantityConsumable++;
                                }
                            }
                            if (aggregateSelection == 2)
                            {
                                if (consumables[a].GetType() == typeof(Fertilizer))
                                {
                                    quantityConsumable++;
                                }
                            }
                        }

                        if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                        {
                            if (aggregateSelection == 1)
                            {
                                if (consumables[a].GetType() == typeof(AnimalWater))
                                {
                                    quantityConsumable++;
                                }
                            }
                            if (aggregateSelection == 2)
                            {
                                if (consumables[a].GetType() == typeof(AnimalFood))
                                {
                                    quantityConsumable++;
                                }
                            }
                        }
                    }

                    //SI NO POSEE DEL CONSUMIBLE SE SOLICITA COMPRAR O VOLVER
                    if(quantityConsumable == 0)
                    {
                        Console.WriteLine(TextCenter("----- NO POSEE DEL CONSUMIBLE NECESARIO PARA LLEVAR LA ACCION -----"));

                        while (true)
                        {
                            if (builds[buildSelected - 1].GetType() == typeof(Land))
                            {
                                if (aggregateSelection == 1)
                                {
                                    Console.WriteLine(TextCenter("¿Desea comprar riego para la plantacion?"));
                                    Console.WriteLine(TextCenter("1 - Si"));
                                    Console.WriteLine(TextCenter("2 - No"));
                                }
                                if (aggregateSelection == 2)
                                {
                                    Console.WriteLine(TextCenter("¿Desea comprar fertilizante para la plantacion?"));
                                    Console.WriteLine(TextCenter("1 - Si"));
                                    Console.WriteLine(TextCenter("2 - No"));
                                }
                            }

                            if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                            {
                                if(aggregateSelection == 1)
                                {
                                    Console.WriteLine(TextCenter("¿Desea comprar agua para los animales?"));
                                    Console.WriteLine(TextCenter("1 - Si"));
                                    Console.WriteLine(TextCenter("2 - No"));
                                }
                                if (aggregateSelection == 2)
                                {
                                    Console.WriteLine(TextCenter("¿Desea comprar comida para los animales?"));
                                    Console.WriteLine(TextCenter("1 - Si"));
                                    Console.WriteLine(TextCenter("2 - No"));
                                }
                            }

                            string optionSelect = Console.ReadLine();

                            if (optionSelect == "1")
                            {
                                break;
                            }
                            if (optionSelect == "2")
                            {
                                return false;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }

                        //SE REVISA SI TIENE DINERO SUFICIENTE
                        int valueConsumable = 0;
                        PriceConsumable priceConsumable = null;

                        if (builds[buildSelected - 1].GetType() == typeof(Land))
                        {
                            if (aggregateSelection == 1)
                            {
                                for(int n = 0; n < game.GetMarket().GetPricesConsumables().Count; n++)
                                {
                                    if(game.GetMarket().GetPricesConsumables()[n].GetConsumable().GetType() == typeof(Irrigation))
                                    {
                                        priceConsumable = (PriceConsumable)game.GetMarket().GetPricesConsumables()[n];
                                        valueConsumable = priceConsumable.GetPrice();
                                    }
                                }
                            }
                            if (aggregateSelection == 2)
                            {
                                for (int n = 0; n < game.GetMarket().GetPricesConsumables().Count; n++)
                                {
                                    if (game.GetMarket().GetPricesConsumables()[n].GetConsumable().GetType() == typeof(Fertilizer))
                                    {
                                        priceConsumable = (PriceConsumable)game.GetMarket().GetPricesConsumables()[n];
                                        valueConsumable = priceConsumable.GetPrice();
                                    }
                                }
                            }
                        }

                        if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                        {
                            if (aggregateSelection == 1)
                            {
                                for (int n = 0; n < game.GetMarket().GetPricesConsumables().Count; n++)
                                {
                                    if (game.GetMarket().GetPricesConsumables()[n].GetConsumable().GetType() == typeof(AnimalWater))
                                    {
                                        priceConsumable = (PriceConsumable)game.GetMarket().GetPricesConsumables()[n];
                                        valueConsumable = priceConsumable.GetPrice();
                                    }
                                }
                            }
                            if (aggregateSelection == 2)
                            {
                                for (int n = 0; n < game.GetMarket().GetPricesConsumables().Count; n++)
                                {
                                    if (game.GetMarket().GetPricesConsumables()[n].GetConsumable().GetType() == typeof(AnimalFood))
                                    {
                                        priceConsumable = (PriceConsumable)game.GetMarket().GetPricesConsumables()[n];
                                        valueConsumable = priceConsumable.GetPrice();
                                    }
                                }
                            }
                        }

                        //SI NO POSEE DINERO SUFICIENTE PARA COMPRAR EL CONSUMIBLE
                        if(game.GetMoney() < valueConsumable)
                        {
                            Console.WriteLine(TextCenter("---- NO POSEE DINERO SUFICIENTE PARA COMPRAR EL CONSUMIBLE -----"));
                            Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                            Console.ReadLine();
                            return false;
                        }

                        //SI POSEE DINERO SUFICIENTE
                        if (game.GetMoney() >= valueConsumable)
                        {
                            List<PriceConsumable> priceConsumables = new List<PriceConsumable>();
                            priceConsumables.Add(priceConsumable);

                            List<int> quantity = new List<int>();
                            quantity.Add(1);

                            game.BuyConsumables(priceConsumables, quantity, valueConsumable);

                            game.GetMap().GetFarm().ApplyConsumable(consumableSelected, builds[buildSelected - 1]);

                            Console.WriteLine(TextCenter("---- SU COMPRA FUE REALIZADA CON EXITO Y APLICADA A SU PRODUCCION -----"));
                            Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                            Console.ReadLine();
                            return true;
                        }
                    }

                    //SI POSEE DEL CONSUMIBLE
                    if (quantityConsumable > 0)
                    {
                        game.GetMap().GetFarm().ApplyConsumable(consumableSelected, builds[buildSelected - 1]);

                        Console.WriteLine(TextCenter("---- SU CONSUMIBLE FUE APLICADO A SU PRODUCCION -----"));
                        Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                        Console.ReadLine();
                        return true;
                    }

                    return false;
                }

                //----------------------
                //APLICAR CURA
                if (typeManagement == 1)
                {
                    options.Clear();
                    builds.Clear();
                    int counter = 0;
                    //IMPRIMIMOS LAS PLANTACIONES O GANADOS
                    for (int i = 0; i < 100; i++)
                    {
                        string name = "";
                        int positionX = i / 10;
                        int positionY = i % 10;

                        if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild() != null)
                        {
                            if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild().GetType() == typeof(Land))
                            {
                                Land land = (Land)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                                name = land.GetName();
                                counter++;
                                Console.WriteLine(TextCenter(counter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                                options.Add(counter.ToString());
                                builds.Add(land);
                            }

                            if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild().GetType() == typeof(Ranch))
                            {
                                Ranch ranch = (Ranch)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                                name = ranch.GetName();
                                counter++;
                                Console.WriteLine(TextCenter(counter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                                options.Add(counter.ToString());
                                builds.Add(ranch);
                            }
                        }
                    }

                    //SELECCIONAMOS LA PLANTACION O GANADO
                    while (true)
                    {
                        Console.WriteLine(TextCenter("Ingrese la produccion que desea curar: "));

                        string optionSelect = Console.ReadLine();

                        if (options.Contains(optionSelect))
                        {
                            buildSelected = Int32.Parse(optionSelect);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                        }
                    }

                    //SE VERIFICA QUE POSEA ALGUNA ENFERMEDAD Y QUE TIPO DE ENFERMEDAD SE DESEA CURAR
                    while (true)
                    {
                        int diseaseCounter = 0;
                        List<Consumable> optionsConsumables = new List<Consumable>();

                        if (builds[buildSelected - 1].GetType() == typeof(Land))
                        {
                            Land land = (Land)builds[buildSelected - 1];

                            if (land.GetDisease() == true)
                            {
                                diseaseCounter++;
                                Console.WriteLine(TextCenter(diseaseCounter.ToString() + " - Curar Hongos"));
                                for(int n = 0; n < game.GetConsumables().Count; n++)
                                {
                                    if (game.GetConsumables()[n].GetType() == typeof(Fungicide))
                                    {
                                        optionsConsumables.Add(game.GetConsumables()[n]);
                                    }
                                }
                            }

                            if (land.GetWorms() == true)
                            {
                                diseaseCounter++;
                                Console.WriteLine(TextCenter(diseaseCounter.ToString() + " - Curar Gusanos"));
                                for (int n = 0; n < game.GetConsumables().Count; n++)
                                {
                                    if (game.GetConsumables()[n].GetType() == typeof(Pesticide))
                                    {
                                        optionsConsumables.Add(game.GetConsumables()[n]);
                                    }
                                }
                            }

                            if (land.GetUndergrowth() == true)
                            {
                                diseaseCounter++;
                                Console.WriteLine(TextCenter(diseaseCounter.ToString() + " - Curar Maleza"));
                                for (int n = 0; n < game.GetConsumables().Count; n++)
                                {
                                    if (game.GetConsumables()[n].GetType() == typeof(Herbicide))
                                    {
                                        optionsConsumables.Add(game.GetConsumables()[n]);
                                    }
                                }
                            }


                        }

                        if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                        {
                            Ranch ranch = (Ranch)builds[buildSelected - 1];

                            if(ranch.GetDisease() == true)
                            {
                                diseaseCounter++;
                                Console.WriteLine(TextCenter(diseaseCounter.ToString() + " - Curar Enfermedad"));
                                for (int n = 0; n < game.GetConsumables().Count; n++)
                                {
                                    if (game.GetConsumables()[n].GetType() == typeof(Vaccine))
                                    {
                                        optionsConsumables.Add(game.GetConsumables()[n]);
                                    }
                                }
                            }
                        }

                        if(diseaseCounter == 0)
                        {
                            Console.WriteLine(TextCenter("---- SU PRODUCCION NO POSEE ENFERMEDAD PARA CURAR -----"));
                            Console.WriteLine(TextCenter("PRESIONE ENTER PARA VOLVER"));
                            Console.ReadLine();
                            return false;
                        }

                        string optionSelect = Console.ReadLine();


                        if(optionSelect == "1" || optionSelect == "2" || optionSelect == "3")
                        {
                            int optionSelectInt = Int32.Parse(optionSelect);

                            if(optionSelectInt <= optionsConsumables.Count())
                            {
                                consumableSelected = optionsConsumables[optionSelectInt - 1];
                                break;
                            }

                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                        }
                    }

                    //REVISION SI POSEE O NO DE ESE CONSUMIBLE
                    int quantityConsumable = 0;

                    if (consumables.Contains(consumableSelected))
                    {
                        quantityConsumable = 1;
                    }

                    //SI NO POSEE DEL CONSUMIBLE SE SOLICITA COMPRAR O VOLVER
                    if (quantityConsumable == 0)
                    {
                        Console.WriteLine(TextCenter("----- NO POSEE DEL CONSUMIBLE NECESARIO PARA LLEVAR LA ACCION -----"));

                        while (true)
                        {
                            if(consumableSelected.GetType() == typeof(Vaccine))
                            {
                                Console.WriteLine(TextCenter("¿Desea comprar vacuna para los animales?"));
                                Console.WriteLine(TextCenter("1 - Si"));
                                Console.WriteLine(TextCenter("2 - No"));
                            }
                            if (consumableSelected.GetType() == typeof(Fungicide))
                            {
                                Console.WriteLine(TextCenter("¿Desea fungicida para la plantacion?"));
                                Console.WriteLine(TextCenter("1 - Si"));
                                Console.WriteLine(TextCenter("2 - No"));
                            }
                            if (consumableSelected.GetType() == typeof(Pesticide))
                            {
                                Console.WriteLine(TextCenter("¿Desea pesticida para la plantacion?"));
                                Console.WriteLine(TextCenter("1 - Si"));
                                Console.WriteLine(TextCenter("2 - No"));
                            }
                            if (consumableSelected.GetType() == typeof(Herbicide))
                            {
                                Console.WriteLine(TextCenter("¿Desea herbicida para la plantacion?"));
                                Console.WriteLine(TextCenter("1 - Si"));
                                Console.WriteLine(TextCenter("2 - No"));
                            }

                            string optionSelect = Console.ReadLine();

                            if (optionSelect == "1")
                            {
                                break;
                            }
                            if (optionSelect == "2")
                            {
                                return false;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }

                        //SE REVISA SI TIENE DINERO SUFICIENTE
                        int valueConsumable = 0;
                        PriceConsumable priceConsumable = null;

                        for(int z = 0; z < game.GetMarket().GetPricesConsumables().Count; z++)
                        {
                            if(game.GetMarket().GetPricesConsumables()[z].GetConsumable().GetType() == consumableSelected.GetType())
                            {
                                priceConsumable = game.GetMarket().GetPricesConsumables()[z];
                                valueConsumable = game.GetMarket().GetPricesConsumables()[z].GetPrice();
                            }
                        }

                        //SI NO POSEE DINERO SUFICIENTE PARA COMPRAR EL CONSUMIBLE
                        if (game.GetMoney() < valueConsumable)
                        {
                            Console.WriteLine(TextCenter("---- NO POSEE DINERO SUFICIENTE PARA COMPRAR EL CONSUMIBLE -----"));
                            Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                            Console.ReadLine();
                            return false;
                        }

                        //SI POSEE DINERO SUFICIENTE
                        if (game.GetMoney() >= valueConsumable)
                        {
                            List<PriceConsumable> priceConsumables = new List<PriceConsumable>();
                            priceConsumables.Add(priceConsumable);

                            List<int> quantity = new List<int>();
                            quantity.Add(1);

                            game.BuyConsumables(priceConsumables, quantity, valueConsumable);

                            game.GetMap().GetFarm().ApplyConsumable(consumableSelected, builds[buildSelected - 1]);

                            Console.WriteLine(TextCenter("---- SU COMPRA FUE REALIZADA CON EXITO Y APLICADA A SU PRODUCCION -----"));
                            Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                            Console.ReadLine();
                            return true;
                        }
                    }

                    //SI POSEE DEL CONSUMIBLE
                    if (quantityConsumable > 0)
                    {
                        game.GetMap().GetFarm().ApplyConsumable(consumableSelected, builds[buildSelected - 1]);

                        Console.WriteLine(TextCenter("---- SU CONSUMIBLE FUE APLICADO A SU PRODUCCION -----"));
                        Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                        Console.ReadLine();
                        return true;
                    }
                }

                //----------------------
                //OBTENER PRODUCTO TERMINADO
                if (typeManagement == 2)
                {
                    options.Clear();
                    builds.Clear();


                    List<Terrain> terrains = new List<Terrain>();

                    int counter = 0;
                    //IMPRIMIMOS LAS PLANTACIONES O GANADOS
                    for (int i = 0; i < 100; i++)
                    {
                        string name = "";
                        int positionX = i / 10;
                        int positionY = i % 10;

                        if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild() != null)
                        {
                            if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild().GetType() == typeof(Land))
                            {
                                Land land = (Land)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                                name = land.GetName();

                                if (land.GetMaturity() >= land.GetSeed().GetTimeProduction())
                                {
                                    counter++;
                                    Console.WriteLine(TextCenter(counter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                                    options.Add(counter.ToString());
                                    builds.Add(land);
                                    terrains.Add(game.GetMap().GetTerrains()[positionX, positionY]);
                                }

                            }

                            if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild().GetType() == typeof(Ranch))
                            {
                                Ranch ranch = (Ranch)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                                name = ranch.GetName();

                                if (ranch.GetMaturity() >= ranch.GetAnimal().GetTimeProduction())
                                {
                                    counter++;
                                    Console.WriteLine(TextCenter(counter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                                    options.Add(counter.ToString());
                                    builds.Add(ranch);
                                    terrains.Add(game.GetMap().GetTerrains()[positionX, positionY]);
                                }
                            }
                        }
                    }

                    if (counter == 0)
                    {
                        Console.WriteLine(TextCenter("----- NO POSEE PLANTACIONES NI GANADOS MADUROS PARA OBTENER SU PRODUCTO -----"));
                        Console.WriteLine(TextCenter("PRESIONES ENTER PARA SALIR"));
                        Console.ReadLine();

                        return false;
                    }

                    //SELECCIONAMOS LA PLANTACION O GANADO
                    while (true)
                    {
                        Console.WriteLine(TextCenter("Ingrese la produccion que desea producir: "));

                        string optionSelect = Console.ReadLine();

                        if (options.Contains(optionSelect))
                        {
                            buildSelected = Int32.Parse(optionSelect);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                        }
                    }

                    //CALCULAMOS LOS ATRIBUTOS DE LA CALIDAD

                    int landProportion = 0;
                    int terrainQuality = 0;
                    int healthProduct = 0;
                    int quality = 0;
                    int priceProduct = 0;

                    //SE OBTIENE LA PROPORCION DE TIERRA Y SU CALIDAD PROMEDIO

                    int earthCounter = 0;
                    int earthQualitySum = 0;
                    for (int j = 0; j < 100; j++)
                    {
                        if (terrains[buildSelected - 1].GetBlocks()[j / 10, j % 10].GetType() == typeof(Earth))
                        {
                            Earth earth = (Earth)terrains[buildSelected - 1].GetBlocks()[j / 10, j % 10];

                            earthCounter++;
                            earthQualitySum += earth.GetQuality();
                        }
                    }

                    terrainQuality = earthQualitySum / earthCounter;

                    landProportion = earthCounter;


                    //SE OBTIENE LA SALUD DEL PRDUCTO
                    if (builds[buildSelected - 1].GetType() == typeof(Land))
                    {
                        Land land = (Land)builds[buildSelected - 1];

                        healthProduct = land.GetHealth();
                        quality = healthProduct * terrainQuality * landProportion;
                    }
                    if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                    {
                        Ranch ranch = (Ranch)builds[buildSelected - 1];

                        healthProduct = ranch.GetHealth();
                        quality = healthProduct * (ranch.GetQuantity() / (ranch.GetAnimal().GetUnits() * earthCounter));
                    }

                    //SE CALCULA EL PRECIO DE VENTA FINAL SEGUN VALOR EN EL MERCADO * CALIDAD
                    for (int b = 0; b < game.GetMarket().GetPricesProducts().Count; b++)
                    {
                        if (game.GetMarket().GetPricesProducts()[b].GetProduct().GetType() == typeof(Animal))
                        {
                            Animal animal = (Animal)game.GetMarket().GetPricesProducts()[b].GetProduct();

                            if (builds[buildSelected - 1].GetType() == typeof(Ranch))
                            {
                                Ranch ranch = (Ranch)builds[buildSelected - 1];

                                if (ranch.GetAnimal().Equals(animal))
                                {
                                    priceProduct = (game.GetMarket().GetPricesProducts()[b].GetSellPrice() * quality) / 100;
                                }
                            }
                        }
                        if (game.GetMarket().GetPricesProducts()[b].GetProduct().GetType() == typeof(Seed))
                        {
                            Seed seed = (Seed)game.GetMarket().GetPricesProducts()[b].GetProduct();

                            if (builds[buildSelected - 1].GetType() == typeof(Land))
                            {
                                Land land = (Land)builds[buildSelected - 1];

                                if (land.GetSeed().Equals(seed))
                                {
                                    priceProduct = (game.GetMarket().GetPricesProducts()[b].GetSellPrice() * quality) / 100;
                                }
                            }
                            
                        }
                    }
                    
                    //SE VERIFICARA SI POSEE ALMACENES
                    List<Storage> storages = new List<Storage>();
                    List<string> storagesOptions = new List<string>();
                    int storageSelected = 0;
                    int storageCounter = 0;

                    for (int a = 0; a < 100; a++)
                    {
                        string name = "";
                        int positionX = a / 10;
                        int positionY = a % 10;

                        if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild() != null)
                        {                            
                            if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild().GetType() == typeof(Storage))
                            {
                                Storage storage = (Storage)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                                name = storage.GetName();

                                storageCounter++;
                                Console.WriteLine(TextCenter(storageCounter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                                storagesOptions.Add(storageCounter.ToString());
                                storages.Add(storage);
                            }
                        }
                    }

                    //SI NO POSEE ALMACEN SE PREGUNTA SI DASEA VENDER EL PRODUCTO
                    if (storageCounter == 0)
                    {
                        Console.WriteLine(TextCenter("----- NO POSEE ALMACEN DONDE GUARDAR SU PRODUCTO -----\n"));
                        Console.WriteLine(TextCenter("El producto puede ser vendido por : " + priceProduct.ToString()) );

                        while (true)
                        {
                            Console.WriteLine(TextCenter("¿Desea vender el producto?"));
                            Console.WriteLine(TextCenter("1 - Si"));
                            Console.WriteLine(TextCenter("2 - No"));

                            string optionSelect = Console.ReadLine();

                            if(optionSelect == "1")
                            {
                                Console.WriteLine(TextCenter("----- SU PRODUCTO FUE VENDIDO EXITOSAMENTE -----\n"));
                                Console.WriteLine(TextCenter("----- PRESIONE ENTER PARA SALIR -----\n"));
                                Console.ReadLine();

                                game.SellFinalProduct(terrains[buildSelected - 1], null, priceProduct, quality);
                                return true;

                            }


                            if (optionSelect == "2")
                            {
                                Console.WriteLine(TextCenter("----- LA TIERRA NO FUE PROCESADA -----\n"));
                                Console.WriteLine(TextCenter("----- PRESIONE ENTER PARA SALIR -----\n"));
                                Console.ReadLine();

                                return false;

                            }

                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }
                        
                    }

                    //SI POSEE ALMACEN SE GUARDA EL PRODUCTO EN EL ALMACEN SELECCIONADO
                    if(storageCounter > 0)
                    {
                        while (true)
                        {
                            Console.WriteLine(TextCenter("Ingrese en que almacen desea guardar el producto: "));

                            string optionSelect = Console.ReadLine();

                            if (storagesOptions.Contains(optionSelect))
                            {
                                storageSelected = Int32.Parse(optionSelect);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }

                        Storage storage = storages[storageSelected - 1];

                        game.SellFinalProduct(terrains[buildSelected - 1], storage, priceProduct, quality);

                        Console.WriteLine(TextCenter("----- SU PRODUCTO FUE ALMACENADO EXITOSAMENTE -----\n"));
                        Console.WriteLine(TextCenter("----- PRESIONE ENTER PARA SALIR -----\n"));
                        Console.ReadLine();

                        return true;
                    }

                }

            }
            //---------------------
            //ADMINISTRACION ALMACENAMIENTO
            if (typeManagementBuild == 1)
            {
                // SE VERIFICARA SI POSEE ALMACENES
                List<Storage> storages = new List<Storage>();
                List<string> storagesOptions = new List<string>();
                int finalProductCounter = 0;
                int storageSelected = 0;
                int storageCounter = 0;

                for (int a = 0; a < 100; a++)
                {
                    string name = "";
                    int positionX = a / 10;
                    int positionY = a % 10;

                    if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild() != null)
                    {                        
                        if (game.GetMap().GetTerrains()[positionX, positionY].GetBuild().GetType() == typeof(Storage))
                        {
                            Storage storage = (Storage)game.GetMap().GetTerrains()[positionX, positionY].GetBuild();
                            name = storage.GetName();

                            storageCounter++;
                            Console.WriteLine(TextCenter(storageCounter.ToString() + " - " + name + " - Terreno[" + positionX.ToString() + "," + positionY.ToString() + "]"));
                            storagesOptions.Add(storageCounter.ToString());
                            storages.Add(storage);

                            for (int b = 0; b < storage.GetFinalProducts().Count; b++)
                            {

                                if (storage.GetFinalProducts()[b].GetProduct().GetType() == typeof(Seed))
                                {
                                    Seed seed = (Seed)storage.GetFinalProducts()[b].GetProduct();

                                    Console.WriteLine(TextCenter(" - " + seed.GetName() + " - Calidad : " + storage.GetFinalProducts()[b].GetQuality().ToString()));
                                    finalProductCounter++;
                                }

                                if (storage.GetFinalProducts()[b].GetProduct().GetType() == typeof(Animal))
                                {
                                    Animal animal = (Animal)storage.GetFinalProducts()[b].GetProduct();

                                    Console.WriteLine(TextCenter(" - " + animal.GetName() + " - Calidad : " + storage.GetFinalProducts()[b].GetQuality().ToString()));
                                    finalProductCounter++;
                                }

                            }

                            Console.WriteLine("\n");

                        }
                    }
                }

                //SI NO POSEE ALMACEN SE PREGUNTA SI DASEA VENDER EL PRODUCTO
                if (storageCounter == 0)
                {
                    Console.WriteLine(TextCenter("----- NO POSEE ALMACEN PARA ADMINISTRAR -----\n"));
                    Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                    Console.ReadLine();

                    return false;

                }

                if (storageCounter > 0)
                {
                    if (finalProductCounter == 0)
                    {
                        Console.WriteLine(TextCenter("----- NO POSEE PRODUCTOS FINALES PARA ADMINISTRAR -----\n"));
                        Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));
                        Console.ReadLine();

                        return false;
                    }

                    if (finalProductCounter > 0)
                    {
                        while (true)
                        {
                            Console.WriteLine(TextCenter("Ingrese en que almacen desea guardar el producto: "));

                            string optionSelect = Console.ReadLine();

                            if (storagesOptions.Contains(optionSelect))
                            {
                                storageSelected = Int32.Parse(optionSelect);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }

                        List<FinalProduct> finalProducts = new List<FinalProduct>();
                        List<string> finalProductsOptions = new List<string>();
                        int finalProductSelected = 0;
                        int productsQualityCounter = 0;

                        for (int c = 0; c < storages[storageSelected - 1].GetFinalProducts().Count; c++)
                        {

                            if (storages[storageSelected - 1].GetFinalProducts()[c].GetProduct().GetType() == typeof(Seed))
                            {
                                Seed seed = (Seed)storages[storageSelected - 1].GetFinalProducts()[c].GetProduct();
                                productsQualityCounter++;
                                Console.WriteLine(TextCenter(productsQualityCounter.ToString() + " - " + seed.GetName() + " - Calidad : " + storages[storageSelected - 1].GetFinalProducts()[c].GetQuality().ToString()));

                                finalProducts.Add(storages[storageSelected - 1].GetFinalProducts()[c]);
                                finalProductsOptions.Add(productsQualityCounter.ToString());
                                
                            }

                            if (storages[storageSelected - 1].GetFinalProducts()[c].GetProduct().GetType() == typeof(Animal))
                            {
                                Animal animal = (Animal)storages[storageSelected - 1].GetFinalProducts()[c].GetProduct();
                                productsQualityCounter++;
                                Console.WriteLine(TextCenter(productsQualityCounter.ToString() + " - " + animal.GetName() + " - Calidad : " + storages[storageSelected - 1].GetFinalProducts()[c].GetQuality().ToString()));

                                finalProducts.Add(storages[storageSelected - 1].GetFinalProducts()[c]);
                                finalProductsOptions.Add(productsQualityCounter.ToString());
                            }

                        }

                        while (true)
                        {
                            Console.WriteLine(TextCenter("Ingrese el producto que desea vender: "));

                            string optionSelect = Console.ReadLine();

                            if (finalProductsOptions.Contains(optionSelect))
                            {
                                finalProductSelected = Int32.Parse(optionSelect);
                                break;
                            }
                            else
                            {
                                Console.WriteLine(TextCenter("Ingrese una opcion valida"));
                            }
                        }

                        int quality = finalProducts[finalProductSelected - 1].GetQuality();
                        int priceProduct = 0;

                        //SE CALCULA EL PRECIO DE VENTA FINAL SEGUN VALOR EN EL MERCADO * CALIDAD
                        for (int b = 0; b < game.GetMarket().GetPricesProducts().Count; b++)
                        {
                            if (game.GetMarket().GetPricesProducts()[b].GetProduct().GetType() == typeof(Animal))
                            {
                                Animal animal = (Animal)game.GetMarket().GetPricesProducts()[b].GetProduct();

                                if (finalProducts[finalProductSelected - 1].GetProduct().GetType() == typeof(Animal))
                                {
                                    Animal animalFinalProduct = (Animal)finalProducts[finalProductSelected - 1].GetProduct();

                                    if (animalFinalProduct.Equals(animal))
                                    {
                                        priceProduct = (game.GetMarket().GetPricesProducts()[b].GetSellPrice() * quality) / 100;
                                    }
                                }
                            }
                            if (game.GetMarket().GetPricesProducts()[b].GetProduct().GetType() == typeof(Seed))
                            {
                                Seed seed = (Seed)game.GetMarket().GetPricesProducts()[b].GetProduct();

                                if (finalProducts[finalProductSelected - 1].GetProduct().GetType() == typeof(Seed))
                                {
                                    Seed seedFinalProduct = (Seed)finalProducts[finalProductSelected - 1].GetProduct();

                                    if (seedFinalProduct.Equals(seed))
                                    {
                                        priceProduct = (game.GetMarket().GetPricesProducts()[b].GetSellPrice() * quality) / 100;
                                    }
                                }

                            }
                        }

                        Console.WriteLine(TextCenter("----- SU PRODUCTO FUE VENDIDO EXITOSAMENTE -----\n"));
                        Console.WriteLine(TextCenter("----- PRESIONE ENTER PARA SALIR -----\n"));
                        Console.ReadLine();

                        game.SellFinalProductStorage(storages[storageSelected - 1], finalProducts[finalProductSelected - 1], priceProduct);
                        return true;

                    }
                }

                return false;
            }

            return false;
        }



        //--------------------------------------------------------------------------------------------
        //IMPRESION DEL MAPA
        //--------------------------------------------------------------------------------------------

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
                            if (map.GetTerrains()[i / 10, j / 10].GetBuild() != null)
                            {
                                if (map.GetTerrains()[i / 10, j / 10].GetBuild().GetType() == typeof(Land))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Write("▒▒");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                if (map.GetTerrains()[i / 10, j / 10].GetBuild().GetType() == typeof(Ranch))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Write("▒▒");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                if (map.GetTerrains()[i / 10, j / 10].GetBuild().GetType() == typeof(Storage))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Write("▒▒");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                            }
                            
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.Write("▒▒");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            
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
                            if (map.GetTerrains()[i / 10, j / 10].GetBuild() != null)
                            {
                                if (map.GetTerrains()[i / 10, j / 10].GetBuild().GetType() == typeof(Land))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.Write("▒▒");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                if (map.GetTerrains()[i / 10, j / 10].GetBuild().GetType() == typeof(Ranch))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.Write("▒▒");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                if (map.GetTerrains()[i / 10, j / 10].GetBuild().GetType() == typeof(Storage))
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    Console.Write("▒▒");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                            }
                            
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.Write("▒▒");
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            
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

        public static void RenderFarmDetails(Map map)
        {
            Terrain[,] terrainsMap = map.GetTerrains();
            List<Terrain> terrainsFarm = map.GetFarm().GetTerrains();

            int counter = 0;

            for(int i = 0; i < 300; i++)
            {
                int positionX = (i % 100) / 10;
                int positionY = (i % 100) % 10;

                if(i%100 == 1 || i%100 == 2)
                {
                    counter = 0;
                }

                if (terrainsFarm.Contains(terrainsMap[positionX , positionY]))
                {
                    if (terrainsMap[positionX, positionY].GetBuild() != null)
                    {
                        if (i / 100 == 0)
                        {
                            if (terrainsMap[positionX , positionY].GetBuild().GetType() == typeof(Ranch))
                            {
                                if(counter == 0)
                                {
                                    Console.Write("\n\n\n");
                                    Console.WriteLine(TextCenter("ESTADO DE RANCHOS" + "\n"));
                                    counter = 1;
                                }
                                Ranch ranch = (Ranch)terrainsMap[positionX, positionY].GetBuild();

                                Console.WriteLine(TextCenter(ranch.GetName() + "\n"));

                                string healthBar = new string('█', ranch.GetHealth() / 2);
                                string noBarHealth = new string('░', 50 - (ranch.GetHealth() / 2));
                                healthBar += noBarHealth;
                                Console.WriteLine(TextCenter("Salud : " + healthBar + " " + ranch.GetHealth() + "%"));

                                string waterBar = new string('█', ranch.GetWater() / 2);
                                string noBarWater = new string('░', 50 - (ranch.GetHealth() / 2));
                                waterBar += noBarWater;
                                Console.WriteLine(TextCenter("Agua : " + waterBar + " " + ranch.GetWater() + "%"));

                                string foodBar = new string('█', ranch.GetFood() / 2);
                                string noBarFood = new string('░', 50 - (ranch.GetHealth() / 2));
                                foodBar += noBarFood;
                                Console.WriteLine(TextCenter("Comida : " + foodBar + " " + ranch.GetFood() + "%"));

                                
                                Console.WriteLine(TextCenter("Maduracion : " + ranch.GetMaturity() + "/" + ranch.GetAnimal().GetTimeProduction() + " turnos"));

                                Console.WriteLine(TextCenter("Enfermedad : " + ranch.GetDisease()));

                            }

                        }

                        if (i / 100 == 1)
                        {
                            if (terrainsMap[positionX, positionY].GetBuild().GetType() == typeof(Land))
                            {
                                if (counter == 0)
                                {
                                    Console.Write("\n\n\n");
                                    Console.WriteLine(TextCenter("ESTADO DE PLANTACIONES" + "\n"));
                                    counter = 1;
                                }
                                Land land = (Land)terrainsMap[positionX, positionY].GetBuild();

                                Console.WriteLine(TextCenter(land.GetName() + "\n"));

                                string healthBar = new string('█', land.GetHealth() / 2);
                                string noBarHealth = new string('░',50 - (land.GetHealth() / 2));
                                healthBar += noBarHealth;
                                Console.WriteLine(TextCenter("Salud : " + healthBar + " " + land.GetHealth() + "%"));

                                string waterBar = new string('█', land.GetWater() / 2);
                                string noBarWater = new string('░', 50 - (land.GetWater() / 2));
                                waterBar += noBarWater;
                                Console.WriteLine(TextCenter("Agua : " + waterBar + " " + land.GetWater() + "%"));

                                string foodBar = new string('█', land.GetNutrients() / 2);
                                string noBarFood = new string('░', 50 - (land.GetNutrients() / 2));
                                foodBar += noBarFood;
                                Console.WriteLine(TextCenter("Comida : " + foodBar + " " + land.GetNutrients() + "%"));


                                Console.WriteLine(TextCenter("Maduracion : " + land.GetMaturity() + "/" + land.GetSeed().GetTimeProduction() + " turnos"));

                                Console.WriteLine(TextCenter("Hongos : " + land.GetDisease()));
                                Console.WriteLine(TextCenter("Gusanos : " + land.GetWorms()));
                                Console.WriteLine(TextCenter("Maleza : " + land.GetUndergrowth()));
                            }
                        }

                        if (i / 100 == 2)
                        {
                            if (terrainsMap[positionX, positionY].GetBuild().GetType() == typeof(Storage))
                            {
                                if (counter == 0)
                                {
                                    Console.Write("\n\n\n");
                                    Console.WriteLine(TextCenter("ESTADO DE ALMACENES" + "\n"));
                                    counter = 1;
                                }
                                Storage storage = (Storage)terrainsMap[positionX, positionY].GetBuild();

                                Console.WriteLine(TextCenter(storage.GetName() + "\n" ));

                                Console.WriteLine(TextCenter("Utilizacion : " + storage.GetFinalProducts().Count + "/" + storage.GetMaxCapacity() + "productos finales"));

                                Console.WriteLine("");
                                Console.WriteLine(TextCenter("Contenido"));

                                for(int a = 0; a < storage.GetFinalProducts().Count; a++)
                                {
                                    if (storage.GetFinalProducts()[a].GetProduct().GetType() == typeof(Animal))
                                    {
                                        Animal animal = (Animal)storage.GetFinalProducts()[a].GetProduct();
                                        Console.WriteLine(TextCenter(a + " - " + animal.GetName() + " - Calidad : " + storage.GetFinalProducts()[a].GetQuality()));
                                    }
                                    if (storage.GetFinalProducts()[a].GetProduct().GetType() == typeof(Seed))
                                    {
                                        Seed seed = (Seed)storage.GetFinalProducts()[a].GetProduct();
                                        Console.WriteLine(TextCenter(a + " - " + seed.GetName() + " - Calidad : " + storage.GetFinalProducts()[a].GetQuality()));
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private static string TextCenter(string text)
        {
            int spaces = 100 - (text.Length / 2);
            string tab = new string(' ', spaces);

            return tab + text;
        }

        public static bool RenderSaveMenu(Game game, string nameSave)
        {
            string path = "../../Resources/Savegames/" + nameSave + ".bin";

            if (!File.Exists(path))
            {
                game.SaveGame(game, nameSave);

                return true;
            }
            else
            {
                return false;
            }
            

        }

        public static string RenderLoadMenu(String title)
        {
            Console.WriteLine(title);

            List<string> optionsGames = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo("../../Resources/Savegames");
            FileInfo[] fileGamesSaved = directoryInfo.GetFiles();
            int counter = 0;
            Console.WriteLine("\n\n");

            for(int i = 0; i < fileGamesSaved.Length; i++)
            {
                counter++;
                Console.WriteLine(TextCenter(counter.ToString() + " - " + fileGamesSaved[i].ToString()));

                optionsGames.Add(counter.ToString());
            }

            if(counter == 0)
            {
                Console.WriteLine(TextCenter("----- NO EXISTEN PARTIDAS PARA CARGAR -----"));
                Console.WriteLine(TextCenter("PRESIONE ENTER PARA SALIR"));

                Console.ReadLine();
                return null;
            }

            while (true)
            {
                Console.WriteLine(TextCenter("Ingrese la partida que desea cargar : "));

                string optionSelect = Console.ReadLine();

                if (optionsGames.Contains(optionSelect))
                {
                    return fileGamesSaved[Int32.Parse(optionSelect) - 1].ToString();
                }
                else
                {
                    Console.WriteLine(TextCenter("Ingrese una opcion valida\n"));
                }
            }

        }


        //-----------------------------------------------------------------------------------------------
        //METODOS DE FORMULARIOS
        //-----------------------------------------------------------------------------------------------

        public static Bitmap RenderImgMap(Game game)
        {
            //CREAMOS UN MAPA PROVISORIO

            Block[,] blockMap = new Block[100,100];

            Map map = game.GetMap();

            //------------------------------------

            Random rnd = new Random();

            //RECORREMOS EL MAPA CON TERRENOS Y LO PASAMOS A UNO SOLO CON BLOQUES
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                 
                    if (map.GetTerrains()[i / 10, j / 10].GetBlocks()[i % 10, j % 10].GetType().Equals(typeof(Water)))
                    {
                        Water water = (Water)map.GetTerrains()[i / 10, j / 10].GetBlocks()[i % 10, j % 10];
                        blockMap[i, j] = water;
                    }

                    if (map.GetTerrains()[i / 10, j / 10].GetBlocks()[i % 10, j % 10].GetType().Equals(typeof(Earth)))
                    {
                        Earth earth = (Earth)map.GetTerrains()[i / 10, j / 10].GetBlocks()[i % 10, j % 10];
                        blockMap[i, j] = earth;

                    }
                }
            }

            //CREAMOS EL MAPA DE BIT

            Bitmap imgMap = new Bitmap(1000, 1000);

            Graphics g = Graphics.FromImage(imgMap);

            //ESTABLECEMOS A LAS DISTANCIAS QUE ESTARAN LOS TILE
            int xPosition = 10;
            int yPosition = 10;

            //RECORREMOS EL MAPA PROVISORIO PARA DETERMINAR QUE TILE DEBE IR EN CADA BLOQUE

            for(int y = 0; y < 100; y++)
            {
                for(int x = 0; x < 100; x++)
                {
                    ////SISTEMA DE TECLADO NUMERICO PARA DETERMINAR LOS BLOQUES ADYACENTES AL QUE NOS ENCONTRAMOS

                    //int one = 0;
                    //int two = 0;
                    //int three = 0;
                    //int four = 0;
                    int five = 0;
                    //int six = 0;
                    //int seven = 0;
                    //int eight = 0;
                    //int nine = 0;

                    ////POSIBLES CASOS
                    //// 1 = AGUA
                    //// 2 = TIERRA
                    //// 3 = PASTO
                    //// 4 = PASTO LARGO

                    ////DETERMINAMOS POSICION 4
                    //if (x > 0)
                    //{
                    //    if (blockMap[y, x - 1].GetType().Equals(typeof(Water)))
                    //    {
                    //        four = 1;
                    //    }
                    //    if (blockMap[y, x - 1].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y, x - 1];
                    //        int quality = earth.GetQuality();

                    //        if( quality <= 25 && quality > 0) 
                    //        {
                    //            four = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            four = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            four = 4;
                    //        }
                    //    }
                    //}

                    ////DETERMINAMOS POSICION 6

                    //if (x < 99)
                    //{
                    //    if (blockMap[y, x + 1].GetType().Equals(typeof(Water)))
                    //    {
                    //        six = 1;
                    //    }
                    //    if (blockMap[y, x + 1].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y, x + 1];
                    //        int quality = earth.GetQuality();

                    //        if (quality <= 25 && quality > 0)
                    //        {
                    //            six = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            six = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            six = 4;
                    //        }
                    //    }
                    //}

                    ////DETERMINAMOS POSICION 8

                    //if (y > 0)
                    //{
                    //    if (blockMap[y - 1, x].GetType().Equals(typeof(Water)))
                    //    {
                    //        eight = 1;
                    //    }
                    //    if (blockMap[y - 1, x].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y - 1, x];
                    //        int quality = earth.GetQuality();

                    //        if (quality <= 25 && quality > 0)
                    //        {
                    //            eight = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            eight = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            eight = 4;
                    //        }
                    //    }
                    //}

                    ////DETERMINAMOS POSICION 2

                    //if (y < 99)
                    //{
                    //    if (blockMap[y + 1, x].GetType().Equals(typeof(Water)))
                    //    {
                    //        two = 1;
                    //    }
                    //    if (blockMap[y + 1, x].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y + 1, x];
                    //        int quality = earth.GetQuality();

                    //        if (quality <= 25 && quality > 0)
                    //        {
                    //            two = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            two = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            two = 4;
                    //        }
                    //    }
                    //}

                    ////DETERMINAMOS POSICION 7

                    //if (x > 0 && y > 0)
                    //{
                    //    if (blockMap[y - 1, x - 1].GetType().Equals(typeof(Water)))
                    //    {
                    //        seven = 1;
                    //    }
                    //    if (blockMap[y - 1, x - 1].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y - 1, x - 1];
                    //        int quality = earth.GetQuality();

                    //        if (quality <= 25 && quality > 0)
                    //        {
                    //            seven = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            seven = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            seven = 4;
                    //        }
                    //    }
                    //}

                    ////DETERMINAMOS POSICION 3

                    //if (x < 99 && y < 99)
                    //{
                    //    if (blockMap[y + 1, x + 1].GetType().Equals(typeof(Water)))
                    //    {
                    //        three = 1;
                    //    }
                    //    if (blockMap[y + 1, x + 1].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y + 1, x + 1];
                    //        int quality = earth.GetQuality();

                    //        if (quality <= 25 && quality > 0)
                    //        {
                    //            three = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            three = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            three = 4;
                    //        }
                    //    }
                    //}

                    ////DETERMINAMOS POSICION 1

                    //if (x > 0 && y < 99)
                    //{
                    //    if (blockMap[y + 1, x - 1].GetType().Equals(typeof(Water)))
                    //    {
                    //        one = 1;
                    //    }
                    //    if (blockMap[y + 1, x - 1].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y + 1, x - 1];
                    //        int quality = earth.GetQuality();

                    //        if (quality <= 25 && quality > 0)
                    //        {
                    //            one = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            one = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            one = 4;
                    //        }
                    //    }
                    //}

                    ////DETERMINAMOS POSICION 9

                    //if (x < 99 && y > 0)
                    //{
                    //    if (blockMap[y - 1, x + 1].GetType().Equals(typeof(Water)))
                    //    {
                    //        nine = 1;
                    //    }
                    //    if (blockMap[y - 1, x + 1].GetType().Equals(typeof(Earth)))
                    //    {
                    //        Earth earth = (Earth)blockMap[y - 1, x + 1];
                    //        int quality = earth.GetQuality();

                    //        if (quality <= 25 && quality > 0)
                    //        {
                    //            nine = 2;
                    //        }
                    //        if (quality <= 75 && quality > 25)
                    //        {
                    //            nine = 3;
                    //        }
                    //        if (quality <= 100 && quality > 75)
                    //        {
                    //            nine = 4;
                    //        }
                    //    }
                    //}

                    //DETERMINAMOS EL 5

                    if (blockMap[y , x].GetType().Equals(typeof(Water)))
                    {
                        five = 1;
                    }

                    if (blockMap[y, x].GetType().Equals(typeof(Earth)))
                    {
                        Earth earth = (Earth)blockMap[y , x ];
                        int quality = earth.GetQuality();

                        if (quality <= 25 )
                        {
                            five = 2;
                        }
                        else if (quality <= 50 )
                        {
                            five = 3;
                        }
                        else if (quality <= 75 )
                        {
                            five = 4;
                        }
                        else
                        {
                            five = 5;
                        }

                    }

                    //DETERMINAMOS SI ES PARTE DE LA GRANJA

                    int alpha = 200;

                    if(map.GetFarm().GetTerrains().Contains(map.GetTerrains()[y / 10, x / 10]))
                    {
                        alpha = 150;
                    }
                    //---------------------------------------------------------------------

                    Color color = Color.FromArgb(255, 255, 255);


                    for (int pixelX = 0; pixelX < 10; pixelX++)
                    {

                        for (int pixelY = 0; pixelY < 10; pixelY++)
                        {
                           
                            if (five == 1)
                            {
                                color = Color.FromArgb(alpha, 57, 114, 171);
                            }

                            if (five == 2)
                            {
                                color = Color.FromArgb(alpha, 234, 255, 127);
                            }

                            if (five == 3)
                            {
                                color = Color.FromArgb(alpha, 94, 165, 51);
                            }

                            if (five == 4)
                            {
                                color = Color.FromArgb(alpha, 70,128,34);
                            }

                            if (five == 5)
                            {
                                color = Color.FromArgb(alpha,54, 102, 25);
                            }

                            

                            imgMap.SetPixel((xPosition * x) + pixelX, (yPosition * y) + pixelY , color);

                        }  
                    }


                    //AGUA

                    //if (five == 1)
                    //{
                    //    //AGUA
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(water[4], xPosition * x, yPosition * y);
                    //    }

                    //    //AGUA UNION
                    //    //1
                    //    if ((one == 2) && (two == 2) && (three == 2 || three == 1 || three == 0) && (four == 2) && (six == 1 || six == 0) && (seven == 2 || seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[0], xPosition * x, yPosition * y);
                    //    }
                    //    //2
                    //    if ((one == 2 || one == 1 || one == 0) && (two == 2 || two == 0) && (three == 2 || three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[1], xPosition * x, yPosition * y);
                    //    }
                    //    //3
                    //    if ((one == 2 || one == 1 || one == 0) && (two == 2) && (three == 2) && (four == 1 || four == 0) && (six == 2) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 2 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[2], xPosition * x, yPosition * y);
                    //    }
                    //    //4
                    //    if ((one == 2 || one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 2) && (six == 1 || six == 0) && (seven == 2 || seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[3], xPosition * x, yPosition * y);
                    //    }
                    //    //SE OMITE EL 5 SOLO ES PASTO

                    //    //6
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 2 || three == 1 || three == 0) && (four == 1 || four == 0) && (six == 2) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 2 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[5], xPosition * x, yPosition * y);
                    //    }
                    //    //7
                    //    if ((one == 2 || one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 2) && (six == 1 || six == 0) && (seven == 2) && (eight == 2) && (nine == 2 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[6], xPosition * x, yPosition * y);
                    //    }

                    //    //8
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 2 || seven == 1 || seven == 0) && (eight == 2) && (nine == 2 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[7], xPosition * x, yPosition * y);
                    //    }

                    //    //9
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 2 || three == 0) && (four == 1 || four == 0) && (six == 2) && (seven == 2 || seven == 1 || seven == 0) && (eight == 2) && (nine == 2))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[8], xPosition * x, yPosition * y);
                    //    }

                    //    //10
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 2))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[9], xPosition * x, yPosition * y);
                    //    }

                    //    //11
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 2) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[10], xPosition * x, yPosition * y);
                    //    }

                    //    //12
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 2) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[11], xPosition * x, yPosition * y);
                    //    }

                    //    //13
                    //    if ((one == 2) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[12], xPosition * x, yPosition * y);
                    //    }

                    //    //CUANDO SE ENCUENTRA SOLO
                    //    //IZQUIERDA
                    //    if ((one == 2) && (two == 2) && (three == 1 || three == 0) && (four == 2) && (six == 1 || six == 0) && (seven == 2) && (eight == 2) && (nine == 1 || nine == 0))
                    //    {
                    //        int waterType = rnd.Next(0, 2);

                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 2) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1) && (six == 1 || six == 0) && (seven == 2) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[3], xPosition * x, yPosition * y);
                    //    }

                    //    //DERECHA
                    //    if ((one == 1 || one == 0) && (two == 2) && (three == 2) && (four == 1 || four == 0) && (six == 2) && (seven == 1 || seven == 0) && (eight == 2) && (nine == 2))
                    //    {
                    //        int waterType = rnd.Next(0, 1);

                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 2) && (four == 1 || four == 0) && (six == 1) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 2))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[5], xPosition * x, yPosition * y);
                    //    }

                    //    //ARRIBA
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 2) && (six == 2) && (seven == 2) && (eight == 2) && (nine == 2))
                    //    {
                    //        int waterType = rnd.Next(0, 1);

                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 2) && (eight == 1) && (nine == 2))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[7], xPosition * x, yPosition * y);
                    //    }

                    //    //ABAJO
                    //    if ((one == 2) && (two == 2) && (three == 2) && (four == 2) && (six == 2) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        int waterType = rnd.Next(0, 1);

                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 2) && (two == 1) && (three == 2) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[1], xPosition * x, yPosition * y);
                    //    }


                    //    //UNION CON PASTO
                    //    //-------------------------------------------
                    //    //-------------------------------------------
                    //    //1
                    //    if ((one == 3) && (two == 3) && (three == 3 || three == 1 || three == 0) && (four == 3) && (six == 1 || six == 0) && (seven == 3 || seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[0], xPosition * x, yPosition * y);
                    //    }
                    //    //2
                    //    if ((one == 3 || one == 1 || one == 0) && (two == 3 || two == 0) && (three == 3 || three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[1], xPosition * x, yPosition * y);
                    //    }
                    //    //3
                    //    if ((one == 3 || one == 1 || one == 0) && (two == 3) && (three == 3) && (four == 1 || four == 0) && (six == 3) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 3 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[2], xPosition * x, yPosition * y);
                    //    }
                    //    //4
                    //    if ((one == 3 || one == 1 || one == 2 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 3) && (six == 1 || six == 0) && (seven == 3 || seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        if (one == 2 && seven == 3)
                    //        {
                    //            g.DrawImage(dirt[1], xPosition * x, yPosition * y);
                    //            g.DrawImage(grassDirt[1], xPosition * x, yPosition * y);
                    //            g.DrawImage(water[3], xPosition * x, yPosition * y);
                    //        }

                    //        else
                    //        {
                    //            g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //            g.DrawImage(water[3], xPosition * x, yPosition * y);
                    //        }

                    //    }
                    //    //SE OMITE EL 5 SOLO ES PASTO

                    //    //6
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 3 || three == 1 || three == 0) && (four == 1 || four == 0) && (six == 3) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 3 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[5], xPosition * x, yPosition * y);
                    //    }
                    //    //7
                    //    if ((one == 3 || one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 3) && (six == 1 || six == 0) && (seven == 3) && (eight == 3) && (nine == 3 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[6], xPosition * x, yPosition * y);
                    //    }

                    //    //8
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 3 || seven == 1 || seven == 0) && (eight == 3) && (nine == 3 || nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[7], xPosition * x, yPosition * y);
                    //    }

                    //    //9
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 3 || three == 0) && (four == 1 || four == 0) && (six == 3) && (seven == 3 || seven == 1 || seven == 0) && (eight == 3) && (nine == 3))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[8], xPosition * x, yPosition * y);
                    //    }

                    //    //10
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 3))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[9], xPosition * x, yPosition * y);
                    //    }

                    //    //11
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 3) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[10], xPosition * x, yPosition * y);
                    //    }

                    //    //12
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 3) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[11], xPosition * x, yPosition * y);
                    //    }

                    //    //13
                    //    if ((one == 3) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[12], xPosition * x, yPosition * y);
                    //    }

                    //    //CUANDO SE ENCUENTRA SOLO
                    //    //IZQUIERDA
                    //    if ((one == 3) && (two == 3) && (three == 1 || three == 0) && (four == 3) && (six == 1 || six == 0) && (seven == 3) && (eight == 3) && (nine == 1 || nine == 0))
                    //    {
                    //        int waterType = rnd.Next(0, 2);

                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 3) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1) && (six == 1 || six == 0) && (seven == 3) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[3], xPosition * x, yPosition * y);
                    //    }

                    //    //DERECHA
                    //    if ((one == 1 || one == 0) && (two == 3) && (three == 3) && (four == 1 || four == 0) && (six == 3) && (seven == 1 || seven == 0) && (eight == 3) && (nine == 3))
                    //    {
                    //        int waterType = rnd.Next(0, 1);

                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 3) && (four == 1 || four == 0) && (six == 1) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 3))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[5], xPosition * x, yPosition * y);
                    //    }

                    //    //ARRIBA
                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 3) && (six == 3) && (seven == 3) && (eight == 3) && (nine == 3))
                    //    {
                    //        int waterType = rnd.Next(0, 1);

                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 1 || one == 0) && (two == 1 || two == 0) && (three == 1 || three == 0) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 3) && (eight == 1) && (nine == 3))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[7], xPosition * x, yPosition * y);
                    //    }

                    //    //ABAJO
                    //    if ((one == 3) && (two == 3) && (three == 3) && (four == 3) && (six == 3) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        int waterType = rnd.Next(0, 1);

                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[13 + waterType], xPosition * x, yPosition * y);
                    //    }

                    //    if ((one == 3) && (two == 1) && (three == 3) && (four == 1 || four == 0) && (six == 1 || six == 0) && (seven == 1 || seven == 0) && (eight == 1 || eight == 0) && (nine == 1 || nine == 0))
                    //    {
                    //        g.DrawImage(grass[1], xPosition * x, yPosition * y);
                    //        g.DrawImage(water[1], xPosition * x, yPosition * y);
                    //    }

                    //}

                    ////TIERRA

                    //if (five == 2)
                    //{
                    //    int dirtType = rnd.Next(0, 3);

                    //    g.DrawImage(dirt[dirtType], xPosition * x, yPosition * y);
                    //}

                    ////PASTO

                    //if (five == 3)
                    //{
                    //    //PASTO
                    //    if ((one == 3 || one == 1 || one == 0) && (two == 3 || two == 1 || two == 0) && (three == 3 || three == 1 || three == 0) && (four == 3 || four == 1 || four == 0) && (six == 3 || six == 1 || six == 0) && (seven == 3 || seven == 1 || seven == 0) && (eight == 3 || eight == 1 || eight == 0) && (nine == 3 || nine == 1 || nine == 0))
                    //    {
                    //        int grassType = rnd.Next(0, 3);

                    //        g.DrawImage(grass[grassType], xPosition * x, yPosition * y);
                    //    }

                    //    //PASTO UNION TIERRA
                    //    //1
                    //    if ((one == 2) && (two == 2) && (three == 2 || three == 3 || three == 0) && (four == 2) && (six == 3 || six == 0) && (seven == 2 || seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[0], xPosition * x, yPosition * y);
                    //    }
                    //    //2
                    //    if ((one == 1 || one == 2 || one == 3 || one == 0) && (two == 2 || two == 0) && (three == 1 || three == 2 || three == 3 || three == 0) && (four == 1 || four == 3 || four == 0) && (six == 1 || six == 3 || six == 0) && (seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[1], xPosition * x, yPosition * y);
                    //    }
                    //    //3
                    //    if ((one == 2 || one == 3 || one == 0) && (two == 2) && (three == 2) && (four == 3 || four == 0) && (six == 2) && (seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 2 || nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[2], xPosition * x, yPosition * y);
                    //    }
                    //    //4
                    //    if ((one == 2 || one == 3 || one == 0) && (two == 3 || two == 0) && (three == 3 || three == 0) && (four == 2) && (six == 3 || six == 0) && (seven == 2 || seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[3], xPosition * x, yPosition * y);
                    //    }
                    //    //SE OMITE EL 5 SOLO ES PASTO

                    //    //6
                    //    if ((one == 3 || one == 0) && (two == 3 || two == 0) && (three == 2 || three == 3 || three == 0) && (four == 3 || four == 0) && (six == 2) && (seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 2 || nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[5], xPosition * x, yPosition * y);
                    //    }
                    //    //7
                    //    if ((one == 2 || one == 3 || one == 0) && (two == 3 || two == 0) && (three == 3 || three == 0) && (four == 2) && (six == 3 || six == 0) && (seven == 2) && (eight == 2) && (nine == 2 || nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[6], xPosition * x, yPosition * y);
                    //    }

                    //    //8
                    //    if ((one == 3 || one == 0) && (two == 3 || two == 0) && (three == 3 || three == 0) && (four == 3 || four == 0) && (six == 3 || six == 0) && (seven == 2 || seven == 3 || seven == 0) && (eight == 2) && (nine == 2 || nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[7], xPosition * x, yPosition * y);
                    //    }

                    //    //9
                    //    if ((one == 3 || one == 0) && (two == 3 || two == 0) && (three == 3 || three == 2 || three == 0) && (four == 3 || four == 0) && (six == 2) && (seven == 2 || seven == 3 || seven == 0) && (eight == 2) && (nine == 2))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[8], xPosition * x, yPosition * y);
                    //    }

                    //    //10
                    //    if ((one == 3 || one == 0) && (two == 3 || two == 0) && (three == 3 || three == 0) && (four == 3 || four == 0) && (six == 3 || six == 0) && (seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 2))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[9], xPosition * x, yPosition * y);
                    //    }

                    //    //11
                    //    if ((one == 3 || one == 0) && (two == 3 || two == 0) && (three == 3 || three == 0) && (four == 3 || four == 0) && (six == 3 || six == 0) && (seven == 2) && (eight == 3 || eight == 0) && (nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[10], xPosition * x, yPosition * y);
                    //    }

                    //    //12
                    //    if ((one == 3 || one == 0) && (two == 3 || two == 0) && (three == 2) && (four == 3 || four == 0) && (six == 3 || six == 0) && (seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[11], xPosition * x, yPosition * y);
                    //    }

                    //    //13
                    //    if ((one == 2) && (two == 3 || two == 0) && (three == 3 || three == 0) && (four == 3 || four == 0) && (six == 3 || six == 0) && (seven == 3 || seven == 0) && (eight == 3 || eight == 0) && (nine == 3 || nine == 0))
                    //    {
                    //        g.DrawImage(dirt[2], xPosition * x, yPosition * y);
                    //        g.DrawImage(grassDirt[12], xPosition * x, yPosition * y);
                    //    }



                    //}

                    ////PASTO LARGO

                    //if (five == 4)
                    //{
                    //    //PASTO LARGO
                    //    if ((one == 4 || one == 0) && (two == 4 || two == 0) && (three == 4 || three == 0) && (four == 4 || four == 0) && (six == 4 || six == 0) && (seven == 4 || seven == 0) && (eight == 4 || eight == 0) && (nine == 4 || nine == 0))
                    //    {
                    //        g.DrawImage(mediumGrass[4], xPosition * x, yPosition * y);
                    //    }

                    //    //1
                    //    if ((one == 2))
                    //    {

                    //    }
                    //}
                }
            }

            g.Dispose();
            return imgMap;
        }

        public static void CreateAssets()
        {
            string pathTerrainsAssets = "../../Resources/Assets/terrain_assets.png";

            terrainAssets = new Bitmap(pathTerrainsAssets);

            int widthAsset = 32;
            int heightAsset = 32;

            int xPosition = 32;
            int yPosition = 32;


            grass = new List<Bitmap>() {CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 0, yPosition * 11),
                                           CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 11),
                                           CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 11) };

            dirt = new List<Bitmap>() { CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 0, yPosition * 5),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 5),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 5)};

            grassDirt = new List<Bitmap>() { CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 0, yPosition * 10),
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 10) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 10) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 0, yPosition * 9) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 9) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 9) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 0, yPosition * 8) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 8) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 8),
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 7) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 7) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 6),
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 6) };

            mediumGrass = new List<Bitmap>() { CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 12, yPosition * 10), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 13, yPosition * 10) , 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 14, yPosition * 10) , 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 12, yPosition * 9) , 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 13, yPosition * 9) , 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 14, yPosition * 9) , 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 12, yPosition * 8) , 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 13, yPosition * 8) , 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 14, yPosition * 8) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 13, yPosition * 7) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 14, yPosition * 7) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 13, yPosition * 6) ,
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 14, yPosition * 6) };

            highGrass = new List<Bitmap>() { CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 28), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 28), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 3, yPosition * 28), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 27), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 27), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 3, yPosition * 27), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 26), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 26), 
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 3, yPosition * 26),
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 1, yPosition * 25),
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 2, yPosition * 25),
                                                CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 3, yPosition * 25) };

            land = new List<Bitmap>() { CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 3, yPosition * 22), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 4, yPosition * 22), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 5, yPosition * 22), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 3, yPosition * 21), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 4, yPosition * 21), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 5, yPosition * 21), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 3, yPosition * 20), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 4, yPosition * 20), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 5, yPosition * 20) };

            water = new List<Bitmap>() { CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 27, yPosition * 4), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 28, yPosition * 4), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 29, yPosition * 4), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 27, yPosition * 3), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 28, yPosition * 3), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 29, yPosition * 3), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 27, yPosition * 2), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 28, yPosition * 2), 
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 29, yPosition * 2),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 28, yPosition * 1),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 29, yPosition * 1),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 28, yPosition * 0),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 29, yPosition * 0),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 27, yPosition * 0),
                                            CropImg(terrainAssets, widthAsset, heightAsset, xPosition * 27, yPosition * 1) };
        }
        private static Bitmap CropImg(Bitmap img, int width, int height, int xPosition, int yPosition)
        {
            Rectangle sectionCrop = new Rectangle(xPosition, yPosition, width, height);

            Bitmap asset = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(asset);

            g.DrawImage(img, 0, 0, sectionCrop, GraphicsUnit.Pixel);

            return asset;
        }
    }
}
