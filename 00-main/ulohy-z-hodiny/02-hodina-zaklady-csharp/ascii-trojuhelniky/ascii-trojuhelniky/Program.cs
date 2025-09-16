internal class Program
{
    private static void Main(string[] args)
    {
        int size = 5; // výška a šířka obrazce (velikost)

        // --- První část obrazce ---
        for (int i = 1; i <= size; i++) // cyklus přes řádky
        {
            // 1. vnitřní cyklus – kreslí od pravé strany doleva
            for (int j = size; j >= 1; j--)
            {
                if (j <= i)
                    Console.Write("*"); // pokud je pozice v rozsahu, vypiš hvězdičku
                else
                    Console.Write(" "); // jinak vypiš mezeru
            }

            Console.Write("    "); // mezera mezi částmi obrazce

            // 2. vnitřní cyklus – kreslí od levé strany doprava
            for (int j = 1; j <= size; j++)
            {
                if (j <= i)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine(); // nový řádek
        }

        Console.WriteLine(); // oddělení mezi částmi obrazce

        // --- Druhá část obrazce ---
        for (int i = 1; i <= size; i++) // cyklus přes řádky
        {
            // 1. vnitřní cyklus – hvězdičky směrem doleva
            for (int j = 1; j <= size; j++)
            {
                if (j >= i)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }

            Console.Write("    "); // mezera mezi částmi obrazce

            // 2. vnitřní cyklus – hvězdičky směrem doprava
            for (int j = size; j >= 1; j--)
            {
                if (j >= i)
                    Console.Write("*");
                else
                    Console.Write(" ");
            }
            Console.WriteLine(); // nový řádek
        }
    }
}