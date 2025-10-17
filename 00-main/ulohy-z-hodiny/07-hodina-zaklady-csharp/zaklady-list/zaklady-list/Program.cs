internal class Program
{
    private static void Main(string[] args)
    {
        // ============ List<T> ============
        // K čemu je: dynamické pole, které se umí samo zvětšovat i zmenšovat.
        // Výhody: jednoduché přidávání, mazání i třídění prvků.
        // Nevýhody: pomalejší mazání uprostřed než LinkedList, větší paměťová náročnost než klasické pole.
        //
        // Důležité: Interně je List postavený na poli, ale když je "plné",
        // vytvoří automaticky nové (větší) pole a data překopíruje.
        // Proto se o to programátor nemusí starat.
        //
        // List = "pole, které se umí nafukovat".
        //
        // Má spoustu metod (Add, Remove, Insert, Sort, ...), které klasické pole nemá.
        // Používá se tam, kde neznám dopředu počet prvků
        // nebo často měním obsah (přidávám/mažu prvky).

        // ---------------- Ukázka č.1 ----------------
        // Vytvoření prázdného listu řetězců
        List<string> listExample = new List<string>();

        // Přidání dvou jmen
        listExample.Add("Jan");
        listExample.Add("Petr");

        // Přístup k prvnímu prvku pomocí indexu 0
        Console.WriteLine(listExample[0]); // vypíše "Jan"


        // ---------------- Ukázka č.2 ----------------
        // Vytvoření listu čísel s předdefinovanými hodnotami
        List<int> numbers = new List<int>() { 5, 2, 8, 5, 1 };

        Console.WriteLine("List: " + string.Join(", ", numbers));

        // Přidávání a mazání v listu
        numbers.Add(10);              // přidá 10 na konec
        numbers.Insert(2, 99);        // vloží 99 na pozici s indexem 2
        Console.WriteLine("Po přidání: " + string.Join(", ", numbers));

        numbers.Remove(5);            // odstraní první výskyt čísla 5
        numbers.RemoveAt(0);          // odstraní prvek na indexu 0
        Console.WriteLine("Po odebrání: " + string.Join(", ", numbers));

        // Hledání v listu
        Console.WriteLine("Obsahuje 99? " + numbers.Contains(99)); // true/false
        Console.WriteLine("Index čísla 8: " + numbers.IndexOf(8)); // vrátí index prvku 8

        // Zajímavé funkce – řazení a otočení
        numbers.Sort();               // seřadí vzestupně
        Console.WriteLine("Seřazeno: " + string.Join(", ", numbers));

        numbers.Reverse();            // otočí pořadí prvků
        Console.WriteLine("Otočeno: " + string.Join(", ", numbers));

        // ForEach – elegantní výpis všech prvků
        Console.WriteLine("Výpis přes ForEach:");
        numbers.ForEach(n => Console.WriteLine($"Prvek: {n}"));

        // EnsureCapacity() – umožňuje Listu dopředu rezervovat místo
        // "Ujisti se, že máš místo alespoň pro X prvků, jinak si zvětši kapacitu dopředu."
        // Např. numbers.EnsureCapacity(100);

        // ---------------- Rozsahy ----------------
        // AddRange() → přidá více prvků na konec listu.
        // InsertRange(index, kolekce) → vloží více prvků na určitou pozici.
        // RemoveRange(index, count) → smaže určitý počet prvků od pozice.

        numbers.AddRange(new[] { 7, 8, 9 });     // přidání více prvků
        numbers.RemoveRange(0, 2);               // odstranění dvou prvků od indexu 0
        Console.WriteLine("Po AddRange/RemoveRange: " + string.Join(", ", numbers));

        // Převod listu na pole
        Console.WriteLine("Počet prvků (pole): " + numbers.ToArray().Length);

        // ---------------- Další ukázka s AddRange/InsertRange ----------------
        List<int> nums = new List<int>() { 1, 2, 3 };

        nums.AddRange(new[] { 7, 8, 9 });
        Console.WriteLine("Po AddRange: " + string.Join(", ", nums));
        // ➜ Výstup: 1, 2, 3, 7, 8, 9

        nums.InsertRange(1, new[] { 111, 112 });
        Console.WriteLine("Po InsertRange(1, {111,112}): " + string.Join(", ", nums));
        // ➜ Výstup: 1, 111, 112, 2, 3, 7, 8, 9

        // Odstranění duplicit – např. všech čísel 20
        nums.RemoveAll(x => x == 20);
    }
}