internal class Program
{
    private static void Main(string[] args)
    {
        // ===============================================
        // (1️) POLE (Array) – základní přehled
        // ===============================================
        // K čemu je: Ukládání více hodnot stejného typu s pevnou velikostí.
        // Výhody: Rychlý přístup přes index, jednoduchá struktura.
        // Nevýhody: Nelze měnit velikost, složité vkládání a mazání.

        // --- Typy zápisu ---
        int[] a;                         // jen deklarace (zatím null)
        int[] b = new int[3];            // [0,0,0] – výchozí hodnoty
        int[] c = new int[] { 1, 2, 3 }; // klasický zápis
        int[] d = { 1, 2, 3 };           // zkrácený zápis
        int[] e = new[] { 1, 2, 3 };     // typ odvozen z literálů


        // ===============================================
        // Ukázka pole č.1 – základní výpis
        // ===============================================
        int[] arrayExample = { 5, 10, 15 };
        for (int i = 0; i < arrayExample.Length; i++)
        {
            Console.WriteLine(arrayExample[i]); // vypíše 5, 10, 15
        }


        // ===============================================
        // Ukázka pole č.2 – naplnění pomocí cyklu
        // ===============================================
        int[] arrayExample2 = new int[10];
        for (int i = 0; i < 10; i++)
        {
            arrayExample2[i] = i + 1;
            Console.Write("{0} ", arrayExample2[i]);
        }

        // foreach cyklus projede všechny prvky automaticky
        foreach (int i in arrayExample2)
        {
            Console.Write("{0} ", i);
        }


        // ===============================================
        // Ukázka pole č.3 – funkce Sort() a Reverse()
        // ===============================================
        string[] names = { "Jan", "Anna", "Tomáš", "Pavel", "Daniel" };

        Array.Sort(names); // seřadí pole vzestupně
        Console.WriteLine("\nSeřazeno:");
        foreach (string n in names)
            Console.Write("{0} ", n);

        Array.Reverse(names); // otočí pořadí prvků
        Console.WriteLine("\nOtočeno:");
        foreach (string n in names)
            Console.Write("{0} ", n);


        // ===============================================
        // Ukázka pole č.4 – IndexOf() a LastIndexOf()
        // ===============================================
        string[] seasons = { "Jaro", "Léto", "Podzim", "Zima" };

        Console.WriteLine("\n\nAhoj, zadej své oblíbené roční období:");
        string season = Console.ReadLine();

        int position = Array.IndexOf(seasons, season);

        if (position >= 0)
            Console.WriteLine($"Super, tvoje oblíbené období je na {position + 1}. místě!");
        else
            Console.WriteLine("Takové roční období neznám!");


        // ===============================================
        // Ukázka pole č.5 – Copy()
        // ===============================================
        // Vytvoříme nové pole stejné velikosti
        string[] copySeasons = new string[seasons.Length];

        // Zkopírujeme obsah
        Array.Copy(seasons, copySeasons, seasons.Length);

        // Výpis obou polí
        Console.WriteLine("\nPůvodní pole:");
        foreach (string s in seasons)
            Console.WriteLine(s);

        Console.WriteLine("\nKopie pole:");
        foreach (string s in copySeasons)
            Console.WriteLine(s);


        // ===============================================
        // Ukázka pole č.6 – Min(), Max(), Average(), Sum()
        // ===============================================

        int[] numbers = { 5, 10, 3, 8, 6 };

        int min = numbers.Min();
        int max = numbers.Max();
        int sum = numbers.Sum();
        double average = numbers.Average();

        Console.WriteLine("\nPole: " + string.Join(", ", numbers));
        Console.WriteLine($"Minimum: {min}");
        Console.WriteLine($"Maximum: {max}");
        Console.WriteLine($"Součet: {sum}");
        Console.WriteLine($"Průměr: {average:F2}");


        // ===============================================
        // Ukázka pole č.7 – Concat(), Intersect(), Union()
        // ===============================================
        int[] numbers1 = { 1, 2, 3, 4, 5 };
        int[] numbers2 = { 4, 5, 6, 7, 8 };

        // var používáme kvůli stručnosti (vrací IEnumerable<int>)
        var concatResult = numbers1.Concat(numbers2);    // spojení
        var intersectResult = numbers1.Intersect(numbers2); // průnik
        var unionResult = numbers1.Union(numbers2);         // sjednocení

        Console.WriteLine("\nPrvní pole: " + string.Join(", ", numbers1));
        Console.WriteLine("Druhé pole: " + string.Join(", ", numbers2));

        Console.WriteLine("\nConcat (spojení): " + string.Join(", ", concatResult));
        Console.WriteLine("Intersect (průnik): " + string.Join(", ", intersectResult));
        Console.WriteLine("Union (sjednocení): " + string.Join(", ", unionResult));


        // ===============================================
        // Ukázka pole č.8 – First(), Last(), ElementAt()
        // ===============================================
        int[] numArray = { 10, 20, 30, 40, 50 };

        Console.WriteLine("\nPole: " + string.Join(", ", numArray));

        int firstNumber = numArray.First();
        int lastNumber = numArray.Last();

        Console.WriteLine($"\nFirst: {firstNumber}");
        Console.WriteLine($"Last: {lastNumber}");

        int elementAt1 = numArray.ElementAt(1);  // index 1 = druhý prvek
        int elementAt3 = numArray.ElementAt(3);  // index 3 = čtvrtý prvek

        Console.WriteLine($"\nElementAt(1): {elementAt1}");
        Console.WriteLine($"ElementAt(3): {elementAt3}");

        // Bezpečné varianty (pokud je index mimo rozsah)
        int firstOrDefault = numArray.FirstOrDefault();
        int lastOrDefault = numArray.LastOrDefault();
        int elementAtOrDefault = numArray.ElementAtOrDefault(10); // mimo rozsah → 0

        Console.WriteLine($"\nFirstOrDefault: {firstOrDefault}");
        Console.WriteLine($"LastOrDefault: {lastOrDefault}");
        Console.WriteLine($"ElementAtOrDefault(10): {elementAtOrDefault}");


        // ===============================================
        // Ukázka pole č.9 – Take(), Skip(), Contains(), Reverse(), Distinct()
        // ===============================================
        int[] numbersArray2 = { 1, 2, 3, 4, 5, 2, 3 };

        Console.WriteLine("\nPole: " + string.Join(", ", numbersArray2));

        var takeResult = numbersArray2.Take(3); // prvních 3
        var skipResult = numbersArray2.Skip(3); // přeskočí 3
        bool contains3 = numbersArray2.Contains(3);
        bool contains9 = numbersArray2.Contains(9);
        var reverseResult = numbersArray2.Reverse();
        var distinctResult = numbersArray2.Distinct();

        Console.WriteLine("\nTake(3): " + string.Join(", ", takeResult));
        Console.WriteLine("Skip(3): " + string.Join(", ", skipResult));
        Console.WriteLine($"Contains(3): {contains3}");
        Console.WriteLine($"Contains(9): {contains9}");
        Console.WriteLine("Reverse(): " + string.Join(", ", reverseResult));
        Console.WriteLine("Distinct(): " + string.Join(", ", distinctResult));


        // ===============================================
        // Ukázka č.10 – Proměnná délka pole
        // ===============================================
        Console.WriteLine("\nAhoj, spočítám ti průměr známek. Kolik známek zadáš?");
        int count = int.Parse(Console.ReadLine());

        int[] nums = new int[count];
        for (int i = 0; i < count; i++)
        {
            Console.Write($"Zadejte {i + 1}. číslo: ");
            nums[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"Průměr tvých známek je: {nums.Average():F2}");
        Console.ReadKey();


        // ===============================================
        // Ukázka č.11 – Vícedimenzionální pole (matice)
        // ===============================================
        int[,] matrix = new int[3, 3]
        {
            { 1, 2, 3 },   // řádek 0
            { 4, 5, 6 },   // řádek 1
            { 7, 8, 9 }    // řádek 2
        };

        // Výpis dvojitým cyklem
        Console.WriteLine("\nObsah dvourozměrného pole:");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }

        // Přístup k jednomu prvku
        Console.WriteLine($"\nPrvek na pozici [1,2] je: {matrix[1, 2]}"); // výstup 6
    }
}