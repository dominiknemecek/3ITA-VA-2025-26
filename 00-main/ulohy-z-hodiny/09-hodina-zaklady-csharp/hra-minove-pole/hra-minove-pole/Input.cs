using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra_minove_pole
{
    internal class Input
    {
        /*
     * Načte mapu podle uživatelových parametrů
     */
        public static Map ReadMap()
        {
            (int left, int top) = Console.GetCursorPosition();
            while (true)
            {
                Console.SetCursorPosition(left, top);
                try
                {
                    Exception wrongInputException = new ArgumentException("Špatný vstup, očekávaný formát: 'A B C D?' kde A B C D jsou čísla, D je nepovinné");

                    Console.Write("Zadejte šířku výšku počet min a seed (nepovinný): ");
                    string input = Console.ReadLine() ?? throw wrongInputException;
                    string[] values = input.Split(" ");

                    if (values.Length < 3 || values.Length > 4) throw wrongInputException;

                    if (!int.TryParse(values[0], out int width)) throw new ArgumentException("Parametr 'šířka' musí být číslo");
                    if (!int.TryParse(values[1], out int height)) throw new ArgumentException("Parametr 'výška' musí být číslo");
                    if (!int.TryParse(values[2], out int mineCount)) throw new ArgumentException("Parametr 'počet min' musí být číslo");

                    int? seed = null;
                    if (values.Length == 4)
                    {
                        if (!int.TryParse(values[3], out int seedValue)) throw new ArgumentException("Parametr 'seed' musí být číslo");
                        seed = seedValue;
                    }

                    if (width < 1) throw new ArgumentException("Šířka musí být větší než 1");
                    if (height < 1) throw new ArgumentException("Výška musí být větší než 1");
                    if (mineCount < 0) throw new ArgumentException("Počet min musí být větší než 0");
                    if (mineCount > width * height) throw new ArgumentException($"Počet min nesmí být větší než velikost pole ({width * height})");

                    return new(width, height, mineCount, seed.HasValue ? new Random(seed.Value) : new Random());
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /*
         * Načte pozici podle uživatelových parametrů
         * Automaticky chytá errory
         */
        public static Map.IntVector ReadCorrectInputPosition(Map map)
        {
            (int left, int top) = Console.GetCursorPosition();
            while (true)
            {
                Console.SetCursorPosition(left, top);
                try
                {
                    Map.IntVector position = ReadInputPosition(map);
                    Console.WriteLine(new string(' ', Console.WindowWidth));
                    return position;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /*
         * Načte pozici podle uživatelových parametrů
         */
        public static Map.IntVector ReadInputPosition(Map map)
        {
            Exception wrongInputException = new ArgumentException("Špatný vstup, očekávaný formát: 'X Y' kde X a Y jsou čísla");

            Console.Write("Zadejte řádek a sloupec: ");
            string input = Console.ReadLine() ?? throw wrongInputException;
            string[] values = input.Split(" ");

            if (values.Length != 2) throw wrongInputException;

            if (!int.TryParse(values[0], out int x)) throw new ArgumentException("Parametr X musí být číslo");
            if (!int.TryParse(values[1], out int y)) throw new ArgumentException("Parametr Y musí být číslo");

            Map.IntVector position = new(x, y);

            if (map.OutsideBounds(position)) throw new ArgumentException($"Pozice není v rozmení 0-{map.Width} a 0-{map.Height}");

            return position;
        }
    }
}
