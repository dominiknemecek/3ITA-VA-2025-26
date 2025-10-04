internal class Program
{
    private static void Main(string[] args)
    {
        // === Určení typu trojuhelníku - samostatná práce č.3 ===

        // --- Zadání délek stran od uživatele ---
        Console.Write("Zadejte délku strany a: ");
        double a;
        while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
        {
            Console.WriteLine("Neplatná hodnota. Zadejte kladné číslo:");
        }

        Console.Write("Zadejte délku strany b: ");
        double b;
        while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
        {
            Console.WriteLine("Neplatná hodnota. Zadejte kladné číslo:");
        }

        Console.Write("Zadejte délku strany c: ");
        double c;
        while (!double.TryParse(Console.ReadLine(), out c) || c <= 0)
        {
            Console.WriteLine("Neplatná hodnota. Zadejte kladné číslo:");
        }

        // --- Kontrola existence trojúhelníku ---
        // Součet délek dvou stran musí být vždy větší než třetí strana
        if (a + b <= c || a + c <= b || b + c <= a)
        {
            Console.WriteLine("Zadané strany netvoří trojúhelník.");
        }
        else
        {
            // --- Určení typu trojúhelníku ---
            if (a == b && b == c)
            {
                Console.WriteLine("Trojúhelník je rovnostranný.");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Trojúhelník je rovnoramenný.");
            }
            else
            {
                Console.WriteLine("Trojúhelník je různoramenný.");
            }
        }
    }
}