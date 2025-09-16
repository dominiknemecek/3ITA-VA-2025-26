internal class Program
{
    private static void Main(string[] args)
    {
        int size = 10; // Velikost čtvercového rámu

        for (int i = 0; i < size; i++) // Cyklus přes řádky
        {
            for (int j = 0; j < size; j++) // Cyklus přes sloupce
            {
                // Okraje čtverce (hvězdičky)
                if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                {
                    Console.Write("*");
                }
                // Diagonály kříže (/)
                else if (j == i || j == (size - 1 - i))
                {
                    Console.Write("*");
                }
                // Vnitřní mezery
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine(); // Nový řádek
        }
    }
}