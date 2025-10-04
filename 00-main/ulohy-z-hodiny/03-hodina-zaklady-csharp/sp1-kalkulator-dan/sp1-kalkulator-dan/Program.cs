internal class Program
{
    private static void Main(string[] args)
    {
        // === Kalkulátor daně podle příjmu - samostatná práce č.1 ===

        // --- Definice hranic jednotlivých daňových pásem (v Kč) ---
        const decimal LIMIT1 = 50_000m;     // do 50 000 Kč – 0 %
        const decimal LIMIT2 = 700_000m;    // do 700 000 Kč – 15 %
        const decimal LIMIT3 = 1_400_000m;  // do 1 400 000 Kč – 20 %, nad tuto hranici 25 %

        // --- Vstupní proměnné ---
        decimal grossIncome; // hrubý roční příjem zadaný uživatelem

        // --- Načtení a kontrola vstupu ---
        Console.Write("Zadejte roční příjem: ");
        // Smyčka se opakuje, dokud uživatel nezadá platné kladné číslo
        while (!decimal.TryParse(Console.ReadLine(), out grossIncome) || grossIncome < 0)
            Console.Write("Neplatný vstup. Zadejte kladné číslo: ");

        // --- Určení sazby daně podle výše příjmu ---
        decimal taxRatePercent; // sazba daně v procentech

        if (grossIncome <= LIMIT1)
            taxRatePercent = 0m;    // žádná daň
        else if (grossIncome <= LIMIT2)
            taxRatePercent = 15m;   // 15 %
        else if (grossIncome <= LIMIT3)
            taxRatePercent = 20m;   // 20 %
        else
            taxRatePercent = 25m;   // 25 %

        // --- Výpočet daně a čistého příjmu ---
        decimal taxAmount = grossIncome * taxRatePercent / 100m; // částka daně v Kč
        decimal netIncome = grossIncome - taxAmount;              // čistý příjem po zdanění

        // --- Výstup výsledků ---
        Console.WriteLine($"Daň: {taxAmount} Kč");
        Console.WriteLine($"Sazba daně: {taxRatePercent} %");
        Console.WriteLine($"Čistý příjem: {netIncome} Kč");
    }
}