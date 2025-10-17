internal class Program
{
    private static void Main(string[] args)
    {
        // ============ Dictionary<TKey, TValue> ============
        // K čemu je: ukládání dat v párech klíč–hodnota.
        // Výhody: velmi rychlé vyhledávání podle klíče, flexibilní typy klíčů i hodnot.
        // Nevýhody: klíče musí být jedinečné, slovník nezaručuje pořadí prvků.
        // Představ si to jako tabulku se dvěma sloupci: „klíč“ a „hodnota“.
        // Příklady použití:
        // - Telefonní seznam: klíč = jméno, hodnota = telefonní číslo.
        // - Slovník cizích slov: klíč = slovo, hodnota = definice.
        // - Sklad: klíč = kód produktu, hodnota = počet kusů.

        // ---------------- Ukázka č.1 ----------------
        // Jednoduchý slovník s dvojicí <string, int>
        Dictionary<string, int> dictionaryExample = new Dictionary<string, int>();

        // Přidání hodnot – klíč „Petr“ má hodnotu 1
        dictionaryExample["Petr"] = 1;
        dictionaryExample["Eva"] = 2;

        // Přístup k hodnotě přes klíč
        Console.WriteLine(dictionaryExample["Eva"]); // vypíše 2


        // ---------------- Ukázka č.2 ----------------
        // Vytvoření slovníku (klíč = string, hodnota = int)
        Dictionary<string, int> ages = new Dictionary<string, int>();

        // Přidání prvků do slovníku
        ages.Add("Petr", 25);
        ages.Add("Jana", 30);
        ages["Karel"] = 40; // alternativní zápis (jako u pole, ale pro klíč)

        // Přístup k hodnotě pomocí klíče
        Console.WriteLine("Petr má věk: " + ages["Petr"]);

        // Kontrola, zda klíč existuje
        if (ages.ContainsKey("Jana"))
            Console.WriteLine("Jana existuje ve slovníku.");

        // Iterace (průchod) přes všechny záznamy ve slovníku
        Console.WriteLine("\nVýpis všech záznamů:");
        foreach (var pair in ages)
        {
            // Každý prvek má dvě části: Key (klíč) a Value (hodnota)
            Console.WriteLine($"Klíč: {pair.Key}, Hodnota: {pair.Value}");
        }

        // Změna hodnoty – přepíše stávající hodnotu pro daný klíč
        ages["Petr"] = 26;

        // Odebrání záznamu podle klíče
        ages.Remove("Karel");

        // Bezpečné získání hodnoty (pokud klíč existuje)
        if (ages.TryGetValue("Karel", out int value))
            Console.WriteLine("Karel má věk: " + value);
        else
            Console.WriteLine("Karel není ve slovníku.");
    }
}