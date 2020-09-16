using Farmulator.Classes.nsGame;
using Farmulator.Classes.nsGame.nsMap;
using Farmulator.Classes.nsGame.nsMap.nsAssets;
using Farmulator.Classes.nsGame.nsMap.nsTerrains;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBlocks;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions;
using Farmulator.Classes.nsGame.nsMap.nsTerrains.nsBuilds.nsProductions.nsProducts;
using Farmulator.Classes.nsGame.nsMarket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                                Console.Write(TextCenter("Dinero Insuficiente"));
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
                        Consumable consumable = game.GetMarket().GetPricesConsumables()[i].GetConsumable();

                        Console.Write(TextCenter((counter + 1).ToString() + " - " + consumable.GetName() + " -- Valor = ¥ " + value.ToString() + "\n"));

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
                        
                        if(checker == 0)
                        {
                            int quantity = Int32.Parse(optionSelect);
                            selectedQuantity.Add(quantity);
                            selectedsConsumables.Add(optionsConsumables[optionsNumbers[0] - 1 ]);
                            break;
                        }
                        if(checker == 1)
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

                    Console.WriteLine(TextCenter((j+1).ToString() + " - " + selectedsConsumables[j].GetConsumable().GetName() + " x " + selectedQuantity[j].ToString() + " -- Valor = ¥ " + (selectedsConsumables[j].GetPrice() * selectedQuantity[j]).ToString()));
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

        private static string TextCenter(string text)
        {
            int spaces = 100 - (text.Length / 2);
            string tab = new string(' ', spaces);

            return tab + text;
        }
    }
}
