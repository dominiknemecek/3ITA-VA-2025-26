internal class Program
{
    private static void Main(string[] args)
    {
        // === Věková kategorie - samostatná práce č.4 ===

        // --- Zadání věku od uživatele ---
        Console.Write("Zadejte svůj věk: ");
        int age;

        // Ošetření vstupu - cyklus se opakuje, dokud uživatel nezadá kladné celé číslo
        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.WriteLine("Neplatný vstup. Zadejte prosím kladné číslo pro věk:");
        }

        // --- Určení kategorie pomocí switch expression ---
        string category = age switch
        {
            <= 12 => "dítě", // pokud je věk 12 nebo méně -> vrátí dítě
            <= 19 => "teenager", // pokud je věk 19 nebo méně -> vrátí teenager
            <= 64 => "dospělý", // pokud je věk 64 nebo méně -> vrátí dospělý
            _ => "senior" // pro všechny ostatní případy (65 a více) -> vrátí senior
        };

        // --- Výstup výsledku ---
        Console.WriteLine($"Jste {category}.");
    }
}