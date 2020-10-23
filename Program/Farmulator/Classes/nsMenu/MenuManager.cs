using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Farmulator.Classes.nsGame;
using Farmulator.Classes.nsPrinter;

namespace Farmulator.Classes.nsMenu
{

    static class MenuManager
    {
        private static string[] zero = { " ▄▄  ", "█  █ ", "▀▄▄▀ " };
        private static string[] one = { " ▄ ", "▀█ ", " █ " };
        private static string[] two = { " ▄▄  ", "▀ ▄▀ ", "▄█▄▄ " };
        private static string[] three = { "▄▄▄▄ ", "  ▄▀ ", "▀▄▄▀ " };
        private static string[] four = { "   ▄ ", " ▄▀█ ", "▀▀▀█ " };
        private static string[] five = { "▄▄▄▄ ", "█▄▄  ", "▄▄▄▀ " };
        private static string[] six = { "▄▄▄  ", "█▄▄▄ ", "▀▄▄▀ " };
        private static string[] seven = { "▄▄▄▄ ", "  ▄▀ ", " █   " };
        private static string[] eight = { "▄▄▄▄ ", "▀▄▄▀ ", "▀▄▄▀ " };
        private static string[] nine = { " ▄▄  ", "▀▄▄█ ", "   █ " };
        private static Game game;
        private static List<string[]> numbers = new List<string[]>() { zero, one, two, three, four, five, six, seven, eight, nine };
        private static string[] stringTurn = { "  ▄▄▄▄▄ ▄  ▄ ▄▄▄  ▄   ▄     ", "    █   █  █ █  █ █▀▄ █  ▀  ", "    █   ▀▄▄▀ █▀▀▄ █  ▀█  ▀  " };
        private static string[] stringMoney = { "▄   ▄ ", "▬▀▄▀▬ ", "▬▬█▬▬ " };

        public static void StartMenu()
        {
            Console.Clear();

            string titleGame = "                                                                                                                                                                                                        \n" +
                                "                                                                                                                                                                                                        \n" +
                                "                                                                                               BIENVENIDO                                                                                               \n" +
                                "                                                                                                                                                                                                        \n" +
                                "                                                                                                                                                                                                        \n" +
                                "                                         ╔═══════════════╗                                                                                                                                              \n" +
                                "                                         ║               ║                                                                                                                                              \n" +
                                "                                         ║               ║                                                                                                                                              \n" +
                                "                                         ║     ╔═════════╝                                                                                                                                              \n" +
                                "                                         ║     ║                                                                                                                                                        \n" +
                                "                                         ║     ╚═════╗ ╔═════════╗ ╔════════╗  ╔═══╗   ╔═══╗ ╔═══╗ ╔═══╗ ╔═══╗ ╔═════════╗ ╔═════════╗  ╔═══════╗  ╔════════╗                                           \n" +
                                "                                         ║           ║ ║         ║ ║        ╚╗ ║   ╚╗ ╔╝   ║ ║   ║ ║   ║ ║   ║ ║         ║ ║         ║ ╔╝       ╚╗ ║        ╚╗                                          \n" +
                                "                                         ║     ╔═════╝ ║   ╔═╗   ║ ║   ╔═╗   ║ ║    ╚═╝    ║ ║   ║ ║   ║ ║   ║ ║   ╔═╗   ║ ╚══╗   ╔══╝ ║   ╔═╗   ║ ║   ╔═╗   ║                                          \n" +
                                "                                         ║     ║       ║   ║ ║   ║ ║   ╚═╝ ╔═╝ ║   ╠╗ ╔╣   ║ ║   ║ ║   ║ ║   ║ ║   ║ ║   ║    ║   ║    ║   ║ ║   ║ ║   ╚═╝ ╔═╝                                          \n" +
                                "                                         ║     ║       ║   ╚═╝   ║ ║   ╔╗  ╚╗  ║   ║╚═╝║   ║ ║   ╚═╝   ║ ║   ║ ║   ╚═╝   ║    ║   ║    ║   ╚═╝   ║ ║   ╔╗  ╚╗                                           \n" +
                                "                                         ║     ║       ║   ╔═╗   ║ ║   ║╚╗  ╚╗ ║   ║   ║   ║ ╚╗       ╔╝ ║   ║ ║   ╔═╗   ║    ║   ║    ╚╗       ╔╝ ║   ║╚╗  ╚╗                                          \n" +
                                "                                         ╚═════╝       ╚═══╝ ╚═══╝ ╚═══╝ ╚═══╝ ╚═══╝   ╚═══╝  ╚═══════╝  ║   ║ ╚═══╝ ╚═══╝    ╚═══╝     ╚═══════╝  ╚═══╝ ╚═══╝                                          \n" +
                                "                                                                ▄▄▄▄▄ ▄  ▄ ▄▄▄▄   ▄▄▄▄▄ ▄▄▄▄ ▄   ▄ ▄▄▄▄  ║   ╚════════════════════════════════════════════════╗                                         \n" +
                                "                                                                  █   █▄▄█ █▄▄    █ ▄▄▄ █  █ █▀▄▀█ █▄▄   ║                                                    ║                                         \n" +
                                "                                                                  █   █  █ █▄▄▄   █▄▄▄█ █▀▀█ █   █ █▄▄▄  ╚════════════════════════════════════════════════════╝                                         \n" +
                                "                                                                                                                                                                                                        \n" +
                                "                                                                                                                                                                                                        \n" +
                                "                                                                                                                                                                                                        \n" +
                                "                                                                                                                                                                                                        \n" +
                                "                                                                                                                                                                                                        ";



            List<string> optionsStartMenu = new List<string>() { "New Game", "Load Game", "Options", "Salir" };

            bool exit = true;
            while (exit)
            {
                int optionSelect = Print.RenderMenu(optionsStartMenu, titleGame);

                switch (optionSelect)
                {
                    case 1:
                        NewGameMenu();
                        break;
                    case 2:

                        bool request = LoadGameMenu();

                        if(request == true)
                        {
                            GameMenu();
                            break;
                        }
                        else
                        {
                            break;
                        }

                    case 3:
                        OptionsMenu();
                        break;
                    case 4:
                        exit = false;
                        break;
                }
            }
                
        }

        private static void NewGameMenu()
        {
            game = new Game();

            while (true)
            {
                Print.RenderMap(game.GetMap());

                string titleNewGame = "\n\n\n\n" +
                                    "                                                         ╔══╗     ╔══╗                              ╔═══════════╗\n" +
                                    "                                                         ║  ╚╗    ║  ║                              ║  ╔═════╗  ║\n" +
                                    "                                                         ║   ╚╗   ║  ║                              ║  ║     ╚══╝\n" +
                                    "                                                         ║    ╚╗  ║  ║                              ║  ║\n" +
                                    "                                                         ║  ╠╗ ╚╗ ║  ║                              ║  ║\n" +
                                    "                                                         ║  ║╚╗ ╚╗║  ║ ╔══════╗ ╔══╗ ╔══╗ ╔══╗      ║  ║  ╔═════╗ ╔══════╗ ╔══╗   ╔══╗ ╔══════╗\n" +
                                    "                                                         ║  ║ ╚╗ ╚╣  ║ ║  ╔═══╝ ║  ║╔╝  ║╔╝ ╔╝      ║  ║  ╚══╗  ║ ║  ╔╗  ║ ║  ╚╗ ╔╝  ║ ║  ╔═══╝\n" +
                                    "                                                         ║  ║  ╚╗    ║ ║  ╚══╗  ║  ╠╝   ╠╝ ╔╝       ║  ║     ║  ║ ║  ║║  ║ ║   ╚═╝   ║ ║  ╚══╗\n" +
                                    "                                                         ║  ║   ╚╗   ║ ║  ╔══╝  ║   ╔╣   ╔╝         ║  ║     ║  ║ ║  ╚╝  ║ ║  ╠╗ ╔╣  ║ ║  ╔══╝\n" +
                                    "                                                         ║  ║    ╚╗  ║ ║  ╚═══╗ ║  ╔╝║  ╔╝          ║  ╚═════╝  ║ ║  ╔╗  ║ ║  ║╚╦╝║  ║ ║  ╚═══╗\n" +
                                    "                                                         ╚══╝     ╚══╝ ╚══════╝ ╚══╝ ╚══╝           ╚═══════════╝ ╚══╝╚══╝ ╚══╝   ╚══╝ ╚══════╝\n" +
                                    "\n\n\n\n" +
                                    "                                                                   ▄   ▄ ▄▄▄▄ ▄▄▄     ▄▄▄▄ ▄▄▄▄ ▄   ▄ ▄▄▄▄ ▄▄▄  ▄▄▄▄ ▄▄▄▄▄  ▄▄  ▄▄▄ \n" +
                                    "                                                                   █▀▄▀█ █  █ █  █    █ ▄▄ █▄▄  █▀▄ █ █▄▄  █  █ █  █   █   █  █ █  █\n" +
                                    "                                                                   █   █ █▀▀█ █▀▀     █▄▄█ █▄▄▄ █  ▀█ █▄▄▄ █▀▀▄ █▀▀█   █   ▀▄▄▀ █▀▀▄\n" +
                                    "\n\n\n\n";


                List<string> optionsNewGame = new List<string>() { "Generar Lago", "Generar Rio", "Generar Granja", "Eliminar Lago", "Eliminar Rio", "Seleccionar Mapa", "Volver" };

                int optionSelect = Print.RenderMenu(optionsNewGame, titleNewGame);

                switch (optionSelect)
                {
                    case 1:
                        game.GetMap().GenerateMap(1, 2, 2);
                        break;
                    case 2:
                        game.GetMap().GenerateMap(2, 1, 2);
                        break;
                    case 3:
                        game.GetMap().GenerateMap(2, 2, 1);
                        break;
                    case 4:
                        game.GetMap().GenerateMap(0, 2, 2);
                        break;
                    case 5:
                        game.GetMap().GenerateMap(2, 0, 2);
                        break;
                    case 6:
                        bool request = GameMenu();

                        if (request == true)
                        {
                            return;
                        }

                        break;
                    case 7:
                        return;
                }
            }
        }

        private static bool LoadGameMenu()
        {

            string titleLoadGame = "\n\n\n\n" +
                    "                                                      ╔══╗                                             ╔═══════════╗\n" +
                    "                                                      ║  ║                                             ║  ╔═════╗  ║\n" +
                    "                                                      ║  ║                                             ║  ║     ╚══╝\n" +
                    "                                                      ║  ║                                             ║  ║\n" +
                    "                                                      ║  ║                                             ║  ║\n" +
                    "                                                      ║  ║          ╔══════╗ ╔══════╗ ╔═════╗          ║  ║  ╔═════╗ ╔══════╗ ╔══╗   ╔══╗ ╔══════╗\n" +
                    "                                                      ║  ║          ║  ╔╗  ║ ║  ╔╗  ║ ║  ╔╗ ╚╗         ║  ║  ╚══╗  ║ ║  ╔╗  ║ ║  ╚╗ ╔╝  ║ ║  ╔═══╝\n" +
                    "                                                      ║  ║          ║  ║║  ║ ║  ║║  ║ ║  ║║  ║         ║  ║     ║  ║ ║  ║║  ║ ║   ╚═╝   ║ ║  ╚══╗\n" +
                    "                                                      ║  ║          ║  ║║  ║ ║  ╚╝  ║ ║  ║║  ║         ║  ║     ║  ║ ║  ╚╝  ║ ║  ╠╗ ╔╣  ║ ║  ╔══╝\n" +
                    "                                                      ║  ╚════════╗ ║  ╚╝  ║ ║  ╔╗  ║ ║  ╚╝ ╔╝         ║  ╚═════╝  ║ ║  ╔╗  ║ ║  ║╚╦╝║  ║ ║  ╚═══╗\n" +
                    "                                                      ╚═══════════╝ ╚══════╝ ╚══╝╚══╝ ╚═════╝          ╚═══════════╝ ╚══╝╚══╝ ╚══╝   ╚══╝ ╚══════╝\n" +
                    "\n\n\n\n";



            string nameFile = Print.RenderLoadMenu(titleLoadGame);

            if (nameFile == null)
            {
                return false;
            }
            else
            {
                IFormatter formatter = new BinaryFormatter();
                string path = "../../Resources/Savegames/" + nameFile;
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                game = (Game)formatter.Deserialize(stream);

                stream.Close();

                return true;
            }

        }

        private static void OptionsMenu()
        {

        }

        private static bool GameMenu()
        {
            string[] gameMenu = { "                                          ▄▄▄▄ ▄▄▄▄ ▄   ▄ ▄▄▄▄   ▄   ▄ ▄▄▄▄ ▄   ▄ ▄  ▄                                         ", 
                                  "                                          █ ▄▄ █  █ █▀▄▀█ █▄▄    █▀▄▀█ █▄▄  █▀▄ █ █  █                                         ", 
                                  "                                          █▄▄█ █▀▀█ █   █ █▄▄▄   █   █ █▄▄▄ █  ▀█ ▀▄▄▀                                         " };

            List<string> optionsGameMenu = new List<string>() {"Administrar granja","Ir al mercado","Pasar turno","Guardar juego","Volver al menu principal" };

            while (true)
            {
                bool requestMenu = false;

                int turn = game.GetTurn();
                int money = game.GetMoney();
                string titleGameMenu = "\n\n\n";

                for (int i = 0; i < 3; i++)
                {
                    titleGameMenu = titleGameMenu + stringTurn[i] + numbers[turn / 10][i] + numbers[turn % 10][i] + gameMenu[i] + stringMoney[i] +  numbers[money / 100000][i] + numbers[(money / 10000)%10][i] + numbers[(money / 1000) % 10][i] + numbers[(money / 100) % 10][i] + numbers[(money / 10) % 10][i] + numbers[money % 10][i] + "\n";
                }

                Print.RenderMap(game.GetMap());
                int optionSelect = Print.RenderMenu(optionsGameMenu, titleGameMenu);

                switch (optionSelect)
                {
                    case 1:
                        requestMenu = FarmMenu();
                        break;
                    case 2:
                        requestMenu = MarketMenu();
                        break;
                    case 3:
                        requestMenu = true;
                        break;
                    case 4:
                        requestMenu = Print.RenderSaveMenu(game);
                        break;
                    case 5:
                        return true;
                }

                if (requestMenu == true)
                {
                    game.NextTurn();
                }
            }
                            
        }

        private static bool MarketMenu()
        {
            string[] marketMenu = { "                                                 ▄   ▄ ▄▄▄▄ ▄▄▄  ▄  ▄ ▄▄▄▄ ▄▄▄▄▄                                              ",
                                    "                                                 █▀▄▀█ █  █ █  █ █▄▀  █▄▄    █                                                ",
                                    "                                                 █   █ █▀▀█ █▀▀▄ █ ▀▄ █▄▄▄   █                                                " };

            List<string> optionsMarketMenu = new List<string>() { "Ir al mercado de edificaciones", "Ir al mercado de consumibles", "Ir al mercado de propiedades", "Revisar precios historicos de semillas" , "Volver" };

            int turn = game.GetTurn();
            int money = game.GetMoney();
            string titleGameMenu = "\n\n\n";

            for (int i = 0; i < 3; i++)
            {
                titleGameMenu = titleGameMenu + stringTurn[i] + numbers[turn / 10][i] + numbers[turn % 10][i] + marketMenu[i] + stringMoney[i] + numbers[money / 100000][i] + numbers[(money / 10000) % 10][i] + numbers[(money / 1000) % 10][i] + numbers[(money / 100) % 10][i] + numbers[(money / 10) % 10][i] + numbers[money % 10][i] + "\n";
            }


            while (true)
            {
                int optionSelect = Print.RenderMenu(optionsMarketMenu, titleGameMenu,true);

                switch (optionSelect)
                {
                    case 1:





                        //MERCADO DE EDIFICACIONES-------------------------------------------------------------------------------------------------------------------------

                        string subTitle = "\n\n\n" +
                                          "                                                                                 ▄▄▄  ▄  ▄ ▄ ▄   ▄▄▄  ▄ ▄   ▄ ▄▄▄▄  ▄▄▄\n" +
                                          "                                                                                 █▄▄▀ █  █ █ █   █  █ █ █▀▄ █ █ ▄▄ ▀▄▄ \n" +
                                          "                                                                                 █▄▄▀ ▀▄▄▀ █ █▄▄ █▄▄▀ █ █  ▀█ █▄▄█ ▄▄▄▀\n";

                        List<string> optionsMarketBuldings = new List<string>() { "Comprar una plantacion", "Comprar ganado", "Comprar Almacenamiento", "Vender/Destruir edificacion", "Volver al mercado" };

                        int optionSelectSubMenu = Print.RenderMenu(optionsMarketBuldings, subTitle, true);

                        switch (optionSelectSubMenu)
                        {
                            case 1:

                                bool request11 = Print.RenderMarket( game, optionSelect, optionSelectSubMenu);

                                if(request11 == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return true;
                                }
                            
                            case 2:

                                bool request12 = Print.RenderMarket(game, optionSelect, optionSelectSubMenu);

                                if (request12 == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return true;
                                }

                            case 3:

                                bool request13 = Print.RenderMarket(game, optionSelect, optionSelectSubMenu);

                                if (request13 == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return true;
                                }

                            case 4:

                                bool request14 = Print.RenderMarket(game, optionSelect, optionSelectSubMenu);

                                if (request14 == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return true;
                                }

                            case 5:
                                break;
                        }


                        break;







                    case 2:

                        bool request2 = Print.RenderMarket(game, optionSelect, 0);

                        if (request2 == false)
                        {
                            break;
                        }
                        else
                        {
                            return true;
                        }


                        //MERCADO DE CONSUMIBLES--------------------------------------------------------------------------------------------------------------------------------------

                    case 3:

                        bool request3 = Print.RenderMarket(game, optionSelect, 0);

                        if (request3 == false)
                        {
                            break;
                        }
                        else
                        {
                            return true;
                        }

                    case 4:

                        bool request4 = Print.RenderMarket(game, optionSelect, 0);

                        if (request4 == false)
                        {
                            break;
                        }
                        else
                        {
                            return true;
                        }

                    case 5:
                        return false;
                }
            }
            
        }

        private static bool FarmMenu()
        {
            Print.RenderFarmDetails(game.GetMap());

            string[] farmMenu = {   "                                                      ▄▄▄▄ ▄▄▄▄ ▄▄▄  ▄   ▄                                                        ",
                                    "                                                      █▄▄  █  █ █  █ █▀▄▀█                                                        ",
                                    "                                                      █    █▀▀█ █▀▀▄ █   █                                                        " };

            List<string> optionsFarmMenu = new List<string>() { "Administrar produccion", "Administrar almacenamiento" , "Vovler al menu"};

            int turn = game.GetTurn();
            int money = game.GetMoney();
            string titleGameMenu = "\n\n\n";

            for (int i = 0; i < 3; i++)
            {
                titleGameMenu = titleGameMenu + stringTurn[i] + numbers[turn / 10][i] + numbers[turn % 10][i] + farmMenu[i] + stringMoney[i] + numbers[money / 100000][i] + numbers[(money / 10000) % 10][i] + numbers[(money / 1000) % 10][i] + numbers[(money / 100) % 10][i] + numbers[(money / 10) % 10][i] + numbers[money % 10][i] + "\n";
            }

            while (true)
            {
                int optionSelect = Print.RenderMenu(optionsFarmMenu, titleGameMenu, true);

                switch (optionSelect)
                {
                    case 1:

                        //ADMINISTRACION DE LA GRANJA -------------------------------------------------------------------------------------------------------------------------

                        string subTitle = "\n\n\n" +
                                          "                                                           ▄▄▄▄ ▄▄▄▄ ▄▄▄  ▄   ▄      ▄   ▄ ▄▄▄▄ ▄   ▄ ▄▄▄▄ ▄▄▄▄ ▄▄▄▄ ▄   ▄ ▄▄▄▄ ▄   ▄ ▄▄▄▄▄\n" +
                                          "                                                           █▄▄  █  █ █  █ █▀▄▀█      █▀▄▀█ █  █ █▀▄ █ █  █ █ ▄▄ █▄▄  █▀▄▀█ █▄▄  █▀▄ █   █  \n" +
                                          "                                                           █    █▀▀█ █▀▀▄ █   █      █   █ █▀▀█ █  ▀█ █▀▀█ █▄▄█ █▄▄▄ █   █ █▄▄▄ █  ▀█   █  \n";

                        List<string> optionsFarmManagement = new List<string>() { "Agregar agua o comida", "Aplicar cura", "Obtener producto terminado", "volver a granja" };

                        int optionSelectSubMenu = Print.RenderMenu(optionsFarmManagement, subTitle, true);

                        switch (optionSelectSubMenu)
                        {
                            case 1:
                                bool request11 = Print.RenderFarmManagement(game,0,0);

                                if(request11 == true)
                                {
                                    return true;
                                }
                                else
                                {
                                    break;
                                }
                            case 2:
                                bool request12 = Print.RenderFarmManagement(game, 0, 1);

                                if (request12 == true)
                                {
                                    return true;
                                }
                                else
                                {
                                    break;
                                }
                              
                            case 3:
                                bool request13 = Print.RenderFarmManagement(game, 0, 2);

                                if (request13 == true)
                                {
                                    return true;
                                }
                                else
                                {
                                    break;
                                }

                            case 4:
                                break;
                        }
                         

                        break;
                    case 2:
                        bool request14 = Print.RenderFarmManagement(game, 1, 0);

                        if (request14 == true)
                        {
                            return true;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        return false;
                }
            }

            
        }

    }
}
