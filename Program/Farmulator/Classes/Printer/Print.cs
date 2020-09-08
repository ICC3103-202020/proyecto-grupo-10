using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmulator.Classes.Printer
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
    }
}
