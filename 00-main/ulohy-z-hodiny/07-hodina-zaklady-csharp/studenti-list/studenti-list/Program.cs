internal class Program
{
    private static void Main(string[] args)
    {
        // Vytvoření seznamu (List), který bude uchovávat jména studentů
        List<string> students = new List<string>();

        // Proměnná pro volbu uživatele v menu
        int choice;

        // Cyklus do-while – opakuje se, dokud uživatel nezadá 0 (konec)
        do
        {
            // Vypíše hlavní menu programu
            Console.WriteLine("\n=== Evidence studentů ===");
            Console.WriteLine("1 - Přidat studenta");
            Console.WriteLine("2 - Vypsat všechny");
            Console.WriteLine("3 - Odebrat studenta");
            Console.WriteLine("4 - Vyhledat studenta");
            Console.WriteLine("5 - Seřadit seznam");
            Console.WriteLine("6 - Vymazat seznam");
            Console.WriteLine("0 - Konec programu");
            Console.Write("Zadejte volbu: ");

            // Převede vstup od uživatele na celé číslo (pokud to nejde, choice = 0)
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Zadejte správný vstup!");

            // Podle zadané volby se provede konkrétní akce
            switch (choice)
            {
                case 1:
                    // Přidání nového studenta
                    Console.Write("Zadejte jméno: ");
                    string name = Console.ReadLine();
                    students.Add(name); // přidá jméno do seznamu
                    Console.WriteLine("Po přidání: " + string.Join(", ", students)); // vypíše aktuální seznam
                    break;

                case 2:
                    // Výpis všech studentů
                    Console.WriteLine("Seznam studentů: " + string.Join(", ", students));
                    break;

                case 3:
                    // Odebrání konkrétního studenta podle jména
                    Console.Write("Koho chcete odebrat: ");
                    string removeName = Console.ReadLine();

                    // Metoda Remove vrací true, pokud byl student nalezen a odebrán
                    if (students.Remove(removeName))
                        Console.WriteLine($"Student {removeName} byl odebrán.");
                    else
                        Console.WriteLine("Student nebyl nalezen.");
                    break;

                case 4:
                    // Vyhledání studenta podle jména
                    Console.Write("Koho hledáte: ");
                    string searchName = Console.ReadLine();

                    // Metoda Contains zjišťuje, jestli seznam obsahuje dané jméno
                    if (students.Contains(searchName))
                        Console.WriteLine($"Student {searchName} byl nalezen.");
                    else
                        Console.WriteLine("Student nebyl nalezen.");
                    break;

                case 5:
                    // Seřazení seznamu studentů podle abecedy
                    students.Sort();
                    Console.WriteLine("Seřazeno: " + string.Join(", ", students));
                    break;

                case 6:
                    // Vymazání celého seznamu (všichni studenti odstraněni)
                    students.Clear();
                    Console.WriteLine("Seznam byl vymazán.");
                    break;
            }

        } while (choice != 0); // cyklus pokračuje, dokud není zadána 0

        // Po ukončení cyklu se program ukončí
        Console.WriteLine("Program ukončen.");
    }
}