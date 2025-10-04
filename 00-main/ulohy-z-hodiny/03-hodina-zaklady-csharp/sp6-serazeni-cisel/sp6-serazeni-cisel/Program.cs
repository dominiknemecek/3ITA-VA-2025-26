internal class Program
{
    private static void Main(string[] args)
    {
        // --- Načtení prvního čísla ---
        Console.Write("Zadejte první číslo: ");
        int x;
        // Ošetření neplatného vstupu – opakuj, dokud uživatel nezadá celé číslo
        while (!int.TryParse(Console.ReadLine(), out x))
        {
            Console.WriteLine("Neplatná volba. Zadejte číslo znovu!");
        }

        // --- Načtení druhého čísla ---
        Console.Write("Zadejte druhé číslo: ");
        int y;
        // Opět kontrola vstupu pomocí TryParse
        while (!int.TryParse(Console.ReadLine(), out y))
        {
            Console.WriteLine("Neplatná volba. Zadejte číslo znovu!");
        }

        // --- Načtení třetího čísla ---
        Console.Write("Zadejte třetí číslo: ");
        int z;
        while (!int.TryParse(Console.ReadLine(), out z))
        {
            Console.WriteLine("Neplatná volba. Zadejte číslo znovu!");
        }

        // --- Hledání nejmenšího, prostředního a největšího čísla ---
        // Nejmenší číslo (min) – porovnání všech tří pomocí ternárních operátorů
        int min = (x < y && x < z) ? x : (y < x && y < z ? y : z);

        // Největší číslo (max) – obdobně porovnáme všechna tři čísla
        int max = (x > y && x > z) ? x : (y > x && y > z ? y : z);

        // Prostřední číslo (mid) zjistíme jednoduše:
        // součet všech tří čísel minus nejmenší a největší
        int mid = (x + y + z) - min - max;

        // --- Výstup výsledků ---
        Console.WriteLine($"Seřazená čísla: x = {min}, y = {mid}, z = {max}");
    }
}