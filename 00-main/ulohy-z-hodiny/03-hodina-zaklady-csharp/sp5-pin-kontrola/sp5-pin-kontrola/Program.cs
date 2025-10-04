internal class Program
{
    private static void Main(string[] args)
    {
        // === Kontrola PIN kódu - samostatná práce č.5 ===

        const int CORRECT_PIN = 1234; // správný PIN
        int attempt = 0;                // počítadlo pokusů
        int pin;                      // proměnná pro zadávaný PIN

        // --- Cyklus s maximálně 3 pokusy ---
        while (attempt < 3)
        {
            Console.Write("Zadejte PIN: ");

            // Kontrola vstupu - zda uživatel zadal celé číslo
            while (!int.TryParse(Console.ReadLine(), out pin))
            {
                Console.WriteLine("Neplatný vstup! Zadejte čtyřmístné číslo:");
            }

            // --- Porovnání se správným PINem ---
            if (pin == CORRECT_PIN)
            {
                Console.WriteLine("Přístup povolen.");
                return; // ukončí program při správném PINu
            }
            else
            {
                Console.WriteLine("Špatný PIN.");
                attempt++; // přidá pokus
            }
        }

        // --- Pokud uživatel vyčerpal všechny pokusy ---
        Console.WriteLine("Přístup odepřen.");
    }
}