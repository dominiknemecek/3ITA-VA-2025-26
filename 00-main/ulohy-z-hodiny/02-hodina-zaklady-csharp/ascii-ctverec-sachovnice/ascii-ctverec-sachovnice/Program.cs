internal class Program
{
    private static void Main(string[] args)
    {
        int size = 10; // Velikost čtverce (10x10)

        // Vnější for cyklus – určuje řádky (výšku "čtverce")
        for (int i = 0; i < size; i++)
        {
            // Vnitřní for cyklus – určuje sloupce (šířku "čtverce")
            for (int j = 0; j < size; j++)
            {
                // Podmínka pro okraj – první/poslední řádek nebo první/poslední sloupec
                if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                    Console.Write("X");   // Na okrajích se vykreslí písmeno "X"
                else
                {
                    // Vnitřek čtverce – střídání znaků podle součtu indexů (i + j)
                    if ((i + j) % 2 == 0)
                        Console.Write("/");   // Pokud je součet sudý, vykreslí se "/"
                    else
                        Console.Write("o");   // Pokud je součet lichý, vykreslí se "o"
                }
            }
            // Po vykreslení jednoho řádku skočíme na nový řádek
            Console.WriteLine();
        }
    }
}