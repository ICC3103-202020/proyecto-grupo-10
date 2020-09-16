using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
                        LoadGameMenu();
                        break;
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
                        GameMenu();
                        break;
                    case 7:
                        return;
                }
            }
        }

        private static void LoadGameMenu()
        {

        }

        private static void OptionsMenu()
        {

        }

        private static void GameMenu()
        {
            string[] gameMenu = { "                                          ▄▄▄▄ ▄▄▄▄ ▄   ▄ ▄▄▄▄   ▄   ▄ ▄▄▄▄ ▄   ▄ ▄  ▄                                         ", 
                                  "                                          █ ▄▄ █  █ █▀▄▀█ █▄▄    █▀▄▀█ █▄▄  █▀▄ █ █  █                                         ", 
                                  "                                          █▄▄█ █▀▀█ █   █ █▄▄▄   █   █ █▄▄▄ █  ▀█ ▀▄▄▀                                         " };

            List<string> optionsGameMenu = new List<string>() {"Administrar granja","Ir al mercado","Pasar turno","Guardar juego","Volver al menu principal" };

            while (true)
            {
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

                        break;
                    case 2:
                        MarketMenu();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        return;
                }

                game.NextTurn();
            }
                            
        }

        private static void MarketMenu()
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

                                bool request = Print.RenderMarket( game, optionSelect, optionSelectSubMenu);

                                if(request == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            
                            case 2:

                                bool request2 = Print.RenderMarket(game, optionSelect, optionSelectSubMenu);

                                if (request2 == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return;
                                }

                            case 3:

                                bool request3 = Print.RenderMarket(game, optionSelect, optionSelectSubMenu);

                                if (request3 == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return;
                                }

                            case 4:

                                bool request4 = Print.RenderMarket(game, optionSelect, optionSelectSubMenu);

                                if (request4 == false)
                                {
                                    break;
                                }
                                else
                                {
                                    return;
                                }

                            case 5:
                                break;
                        }


                        break;







                    case 2:

                        bool request22 = Print.RenderMarket(game, optionSelect, 0);

                        if (request22 == false)
                        {
                            break;
                        }
                        else
                        {
                            return;
                        }


                        //MERCADO DE CONSUMIBLES--------------------------------------------------------------------------------------------------------------------------------------

                    case 3:

                        bool request23 = Print.RenderMarket(game, optionSelect, 0);

                        if (request23 == false)
                        {
                            break;
                        }
                        else
                        {
                            return;
                        }

                    case 4:
                        break;
                    case 5:
                        break;
                }
            }
            
        }

    }
}
