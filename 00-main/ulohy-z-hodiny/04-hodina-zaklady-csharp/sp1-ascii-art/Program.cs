using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // === Program ASCII art ===

        // --- Načtení až tří čísel ze vstupu (1–3 řádky) ---
        string? line = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(line))
        {
            Console.Error.WriteLine("Error: Chybny vstup!");
            Environment.Exit(100);
        }

        string all = line.Trim();
        while (true)
        {
            string? next = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(next)) break;
            all += " " + next.Trim();
            // Zastav, pokud máme již tři čísla
            if (all.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length >= 3) break;
        }

        // Rozdělení vstupu podle mezer nebo tabulátorů
        string[] parts = all.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0 || parts.Length > 3)
        {
            Console.Error.WriteLine("Error: Chybny vstup!");
            Environment.Exit(100);
        }

        // --- Deklarace proměnných ---
        int houseWidth, houseHeight = 0, fenceSize = 0;

        // --- Zpracování a kontrola šířky domu ---
        if (!int.TryParse(parts[0], out houseWidth))
        {
            Console.Error.WriteLine("Error: Chybny vstup!");
            Environment.Exit(100);
        }
        if (houseWidth < 3 || houseWidth > 69)
        {
            Console.Error.WriteLine("Error: Vstup mimo interval!");
            Environment.Exit(101);
        }

        bool hasB = parts.Length >= 2;
        bool hasC = parts.Length == 3;

        // --- Zpracování výšky domu ---
        if (hasB)
        {
            if (!int.TryParse(parts[1], out houseHeight))
            {
                Console.Error.WriteLine("Error: Chybny vstup!");
                Environment.Exit(100);
            }
            if (houseHeight < 3 || houseHeight > 69)
            {
                Console.Error.WriteLine("Error: Vstup mimo interval!");
                Environment.Exit(101);
            }
            if (houseWidth % 2 == 0)
            {
                Console.Error.WriteLine("Error: Sirka neni liche cislo!");
                Environment.Exit(102);
            }
        }

        // --- Zpracování velikosti plotu ---
        if (hasC)
        {
            if (!int.TryParse(parts[2], out fenceSize))
            {
                Console.Error.WriteLine("Error: Chybny vstup!");
                Environment.Exit(100);
            }
            if (fenceSize < 3 || fenceSize > 69)
            {
                Console.Error.WriteLine("Error: Vstup mimo interval!");
                Environment.Exit(101);
            }
            if (fenceSize >= houseHeight) // 0 < c < b
            {
                Console.Error.WriteLine("Error: Neplatna velikost plotu!");
                Environment.Exit(103);
            }
        }

        // ===== A) Pokud je zadáno pouze jedno číslo -> vykresli čtverec =====
        if (!hasB)
        {
            // Horní hrana
            for (int j = 0; j < houseWidth; j++) Console.Write('X');
            Console.Write('\n');

            // Vnitřek
            for (int r = 0; r < houseWidth - 2; r++)
            {
                Console.Write('X');
                for (int j = 0; j < houseWidth - 2; j++) Console.Write(' ');
                Console.Write('X');
                Console.Write('\n');
            }

            // Spodní hrana
            for (int j = 0; j < houseWidth; j++) Console.Write('X');
            Console.Write('\n');
            return;
        }

        // ===== B/C) Dům (dva nebo tři vstupy) =====

        // --- Střecha bez podstřeší ---
        int roofHeight = (houseWidth + 1) / 2;
        for (int r = 0; r < roofHeight - 1; r++)
        {
            for (int s = 0; s < roofHeight - 1 - r; s++) Console.Write(' ');
            Console.Write('X');
            int inner = 2 * r - 1;
            if (inner >= 0)
            {
                for (int s = 0; s < inner; s++) Console.Write(' ');
                Console.Write('X');
            }
            Console.Write('\n');
        }

        // --- Podstřeší + horní část plotu ---
        for (int j = 0; j < houseWidth; j++) Console.Write('X');
        if (hasC)
        {
            bool startDash = (fenceSize % 2 == 0); // pokud je c sudé, začínáme '-'
            for (int i = 0; i < fenceSize; i++)
            {
                bool isDash = ((i % 2 == 0) == startDash);
                Console.Write(isDash ? '-' : '|');
            }
        }
        Console.Write('\n');

        // --- Tělo domu ---
        for (int r = 0; r < houseHeight - 2; r++)
        {
            Console.Write('X');

            // Pokud má dům tvar čtverce (šířka == výška), vyplní se vzorem o/* 
            if (houseWidth == houseHeight)
            {
                for (int c = 0; c < houseWidth - 2; c++)
                    Console.Write(((r + c) % 2 == 0) ? 'o' : '*');
            }
            else
            {
                for (int c = 0; c < houseWidth - 2; c++) Console.Write(' ');
            }

            Console.Write('X');

            // Plot – svislé části na každém řádku těla (plot sahá až dolů)
            if (hasC)
            {
                for (int i = 0; i < fenceSize; i++)
                {
                    // Zarovnání svislých prken pod horními/dolními '|'
                    bool isBar = (fenceSize % 2 == 0) ? (i % 2 == 1) : (i % 2 == 0);
                    Console.Write(isBar ? '|' : ' ');
                }
            }

            Console.Write('\n');
        }

        // --- Spodní hrana domu + spodní část plotu ---
        for (int j = 0; j < houseWidth; j++) Console.Write('X');
        if (hasC)
        {
            bool startDash = (fenceSize % 2 == 0);
            for (int i = 0; i < fenceSize; i++)
            {
                bool isDash = ((i % 2 == 0) == startDash);
                Console.Write(isDash ? '-' : '|');
            }
        }
        Console.Write('\n');
    }
}
