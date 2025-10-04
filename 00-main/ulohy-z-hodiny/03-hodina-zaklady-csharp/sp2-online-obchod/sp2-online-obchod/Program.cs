internal class Program
{
    private static void Main(string[] args)
    {
        // === Obchod s množstevní slevou - samostatná práce č.3 ===

        // --- Nabídka produktů ---
        Console.WriteLine("Vyberte si produkt:");
        Console.WriteLine("=====================");
        Console.WriteLine("1. Banány  – 30 Kč/kg");
        Console.WriteLine("2. Rohlíky – 5 Kč/kus");
        Console.WriteLine("3. Rajčata – 40 Kč/kg");
        Console.WriteLine("4. Cibule  – 25 Kč/kg");
        Console.WriteLine("5. Česnek  – 100 Kč/kg");
        Console.WriteLine("=====================");

        // --- Zadání výběru produktu ---
        int choice; // výběr produktu
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("Neplatná volba. Zadejte číslo od 1 do 5:");
        }

        // --- Určení názvu a ceny podle výběru ---
        string product; // název produktu
        decimal pricePerUnit; // cena za jednotku (kus nebo kg)

        switch (choice)
        {
            case 1:
                product = "Banány";
                pricePerUnit = 30m;
                break;
            case 2:
                product = "Rohlíky";
                pricePerUnit = 5m;
                break;
            case 3:
                product = "Rajčata";
                pricePerUnit = 40m;
                break;
            case 4:
                product = "Cibule";
                pricePerUnit = 25m;
                break;
            case 5:
                product = "Česnek";
                pricePerUnit = 100m;
                break;
            default:
                // Teoreticky se sem nedostaneme, protože vstup je ošetřen
                product = "Neznámý produkt";
                pricePerUnit = 0m;
                break;
        }

        // --- Zadání počtu kusů/kg ---
        Console.Write($"Zadejte počet kusů/kg ({product}): ");
        int amount;
        while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Neplatné množství. Zadejte kladné číslo:");
        }

        // --- Výpočet základní ceny ---
        decimal totalPrice = pricePerUnit * amount;

        // --- Určení slevy podle množství ---
        decimal discount = amount switch
        {
            <= 10 => 0m,
            <= 50 => 5m,
            <= 100 => 10m,
            _ => 15m
        };

        // --- Výpočet ceny po slevě ---
        decimal priceAfterDiscount = totalPrice - (totalPrice * discount / 100m);

        // --- Výstup výsledků ---
        Console.WriteLine($"Celková cena před slevou: {totalPrice} Kč");
        Console.WriteLine($"Sleva: {discount} %");
        Console.WriteLine($"Cena po slevě: {priceAfterDiscount} Kč");
    }
}