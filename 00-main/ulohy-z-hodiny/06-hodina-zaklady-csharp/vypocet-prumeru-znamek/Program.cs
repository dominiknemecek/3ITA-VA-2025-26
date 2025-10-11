internal class Program
{
    private static void Main(string[] args)
    {
        // === Výpočet průměru známek a statistiky ===

        // Základní proměnné
        const int MIN_GRADE = 1;
        const int MAX_GRADE = 5;
        int[] occurrences = new int[MAX_GRADE - MIN_GRADE + 1]; // indexy 0–4 odpovídají známkám 1–5

        int weightedSum = 0, simpleSum = 0, sumWeights = 0;
        int best = int.MaxValue, worst = int.MinValue;

        // Začátek programu
        Console.WriteLine("= Kalkulačka pro výpočet průměru známek =");

        Console.WriteLine("Zadejte počet známek:");

        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            Console.WriteLine("Neplatný vstup, zadej prosím kladné číslo: ");

        int[] grades = new int[count];
        int[] weights = new int[count];

        for (int i = 0; i < count; i++)
        {
            // Zadání známky
            Console.Write($"Zadej {i + 1}. známku (1–5): ");
            while (!int.TryParse(Console.ReadLine(), out grades[i]) || grades[i] < MIN_GRADE || grades[i] > MAX_GRADE)
                Console.WriteLine("Neplatné číslo, zadej prosím znovu (1–5): ");

            // Zadání váhy
            Console.Write($"Zadej váhu {i + 1}. známky: ");
            while (!int.TryParse(Console.ReadLine(), out weights[i]) || weights[i] <= 0)
                Console.WriteLine("Neplatná váha, zadej kladné číslo: ");

            // Výpočty
            weightedSum += grades[i] * weights[i];
            simpleSum += grades[i];
            sumWeights += weights[i];

            if (grades[i] < best) best = grades[i];
            if (grades[i] > worst) worst = grades[i];

            // Posun indexu o -1 (známka 1 jde na index 0, známka 5 na index 4)
            occurrences[grades[i] - 1]++;
        }

        double average = (double)weightedSum / sumWeights;

        Console.WriteLine("-------------------------------------------");
        Console.WriteLine($"Počet známek: {count}");
        Console.WriteLine($"Součet známek: {simpleSum}");
        Console.WriteLine($"Vážený průměr: {average:F2}");
        Console.WriteLine($"Nejlepší známka: {best}");
        Console.WriteLine($"Nejhorší známka: {worst}");

        Console.WriteLine("\nVýskyty jednotlivých známek:");
        for (int i = 0; i < occurrences.Length; i++)
        {
            double percentage = (double)occurrences[i] / count * 100;
            Console.WriteLine($"Známka {i + 1}: {occurrences[i]}x ({percentage:F2}%)");
        }
    }
}