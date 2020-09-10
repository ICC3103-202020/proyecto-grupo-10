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
        private static Game game;
        public static void StartMenu()
        {
            Console.Clear();

            string titleGame = "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
            "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" +
            "░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░BIENVENIDO░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n" ; 



            List<string> optionsStartMenu = new List<string>() { "New Game", "Load Game", "Options" };

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
            }
        }

        private static void NewGameMenu()
        {
            game = new Game();

            while (true)
            {
                Print.RenderMap(game.GetMap());

                string titleNewGame = "";

                List<string> optionsNewGame = new List<string>() { "Generar Lago", "Generar Rio", "Generar Granja", "Eliminar Lago", "Eliminar Rio", "Seleccionar Mapa" };

                int optionSelect = Print.RenderMenu(optionsNewGame, titleNewGame);

                switch (optionSelect)
                {
                    case 1:
                        game.GetMap().GenerateMap( 1, 2, 2);
                        break;
                    case 2:
                        game.GetMap().GenerateMap( 2, 1, 2);
                        break;
                    case 3:
                        game.GetMap().GenerateMap( 2, 2, 1);
                        break;
                    case 4:
                        game.GetMap().GenerateMap( 0, 2, 2);
                        break;
                    case 5:
                        game.GetMap().GenerateMap( 2, 0, 2);
                        break;
                    case 6:
                        GameMenu();
                        break;
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

        }

    }
}
