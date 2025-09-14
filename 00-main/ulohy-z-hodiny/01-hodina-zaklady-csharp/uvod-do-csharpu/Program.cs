using System;

class Program
{
    static void Main()
    {
        // ================ 1. VÝPIS DO KONZOLE =================

        // Výpis do konzole s odřádkováním
        Console.WriteLine("Hello, world!");

        // Výpis do konzole bez odřádkování
        Console.Write("Hello, world!");

        // Výpis do konzole s odřádkováním
        Console.Write("Hello, world!\n");

        // ======================================================


        // ================ 2. DRUHY KOMENTÁŘŮ ================

        //  Jednoduchý komentář - na jeden řádek

        /* Víceřádkový komentář - na více řádků */

        /// Summary komentář
        /// <summary>
        /// Metoda pro sčítání dvou čísel
        /// </summary>
        /// <param name="a">První číslo k sečtení</param>
        /// <param name="b">Druhé číslo k sečtení</param>
        /// <returns>Součet obou čísel</returns>

        // ======================================================


        // ================ 3. DATOVÉ TYPY ================

        // Unsigned vs Signed datové typy
        //-------------------------------------------------
        // Signed: Datové typy označené jako "signed" umožňují reprezentovat jak kladná, tak záporná čísla (defaultně dané a nepíše se). 
        // Unsigned: Datové typy označené jako "unsigned" reprezentují pouze nezáporná (kladná) čísla (označuje se u před názvem datového typu - v některých případech speciální tvar). 

        // Celá čísla (signed a unsigned varianty):
        //-------------------------------------------------

        // Pro velká celá čísla (např. velké počty, indexy)
        // long: 8 bajtů (64 bitů)
        long myLong = -9223372036854775808; // Pro celá čísla od -9,223,372,036,854,775,808 do 9,223,372,036,854,775,807.
        // ulong: 8 bajtů (64 bitů)
        ulong myUlong = 18446744073709551615; // Pro nezáporná celá čísla od 0 do 18,446,744,073,709,551,615.

        // Střední celá čísla
        // int: 4 bajty (32 bitů)
        int myInt = -2147483648; // Pro celá čísla od -2,147,483,648 do 2,147,483,647.
        // uint: 4 bajty (32 bitů)
        uint myUint = 4294967295; // Pro nezáporná celá čísla od 0 do 4,294,967,295.

        // Malá celá čísla
        // short: 2 bajty (16 bitů)
        short myShort = -32768; // Pro celá čísla od -32,768 do 32,767.
        // ushort: 2 bajty (16 bitů)
        ushort myUshort = 65535; // Pro nezáporná celá čísla od 0 do 65,535.

        // Nejmenší celá čísla (např. pro malé hodnoty, jako věk)
        // sbyte: 1 bajt (8 bitů)
        sbyte mySbyte = -128; // Pro malá signed celá čísla od -128 do 127.
        // byte: 1 bajt (8 bitů)
        byte myByte = 255; // Pro nezáporná celá čísla od 0 do 255.

        // Desetinná čísla:
        //-------------------------------------------------

        // Desetinné číslo s jednoduchou přesností
        // float: 4 bajty (32 bitů)
        float myFloat = 3.14f; // Pro desetinná čísla s přesností na 7 desetinných míst.

        // Desetinné číslo s dvojitou přesností
        // double: 8 bajtů (64 bitů)
        double myDouble = 3.14159265359D; // Pro desetinná čísla s přesností na 15-16 číslic.

        // Vysoce přesná desetinná čísla (pro finanční výpočty)
        // decimal: 16 bajtů (128 bitů)
        decimal myDecimal = 79228162514264337593543950335M; // Pro přesná desetinná čísla, vhodné pro měny.

        // Ostatní datové typy:
        //-------------------------------------------------

        // Jeden znak (např. písmeno, symbol)
        // char: 2 bajty (16 bitů)
        char myChar = 'A'; // Pro reprezentaci jednoho znaku nebo symbolu.

        // Logická hodnota (ano/ne, pravda/nepravda)
        // bool: 1 bajt (8 bitů) (reprezentace závisí na konkrétní implementaci)
        bool myBool = true; // Pro hodnoty True nebo False.

        // Textový řetězec (např. slova, věty)
        // string: Proměnlivá velikost (závisí na délce řetězce, každý znak zabírá 2 bajty)
        string myString = "Hello, World!"; // Pro textové řetězce.

        // Výpis všech proměnných
        Console.WriteLine("Long: " + myLong);
        Console.WriteLine("Ulong: " + myUlong);
        Console.WriteLine("Int: " + myInt);
        Console.WriteLine("Uint: " + myUint);
        Console.WriteLine("Short: " + myShort);
        Console.WriteLine("Ushort: " + myUshort);
        Console.WriteLine("Sbyte: " + mySbyte);
        Console.WriteLine("Byte: " + myByte);
        Console.WriteLine("Float: " + myFloat);
        Console.WriteLine("Double: " + myDouble);
        Console.WriteLine("Decimal: " + myDecimal);
        Console.WriteLine("Char: " + myChar);
        Console.WriteLine("Bool: " + myBool);
        Console.WriteLine("String: " + myString);

        // ======================================================


        // ================ 4. FORMÁTOVÁNÍ ŘETĚZCŮ ================

        // 1. Konkatenace řetězců:
        //-------------------------------------------------
        // Definice: Konkatenace znamená spojování řetězců pomocí operátoru +.
        // Jak to funguje: Proměnné jmeno a vek jsou převedeny na textové hodnoty (string) a spojeny s ostatními částmi řetězce pomocí operátoru +. Výsledkem je nový řetězec, který se vypíše na konzoli.
        string name = "Adam";
        int age = 17;
        Console.WriteLine("Jméno: " + name + ", Věk: " + age);

        // 2. Interpolace řetězců:
        //-------------------------------------------------
        // Definice: Interpolace umožňuje přímo vkládat proměnné do textu pomocí speciální syntaxe $"{promenna}".
        // Jak to funguje: Pomocí $ se označí interpolovaný řetězec a následně lze vkládat proměnné nebo výrazy uvnitř složených závorek {} přímo do textu.
        string name2 = "Tomáš";
        int age2 = 25;
        Console.WriteLine($"Jméno: {name2}, Věk: {age2}");

        // 3. Formátovaní řetězců:
        //-------------------------------------------------
        // Definice: Pomocí metody string.Format (nebo ve výstupu Console.WriteLine) lze vložit proměnné do řetězce pomocí pozicových parametrů {n}, kde n je index.
        // Jak funguje: Čísla {0}, {1} atd. reprezentují pozice argumentů v metodě. Argumenty jsou pak dosazeny na tato místa.
        string name3 = "Filip";
        int age3 = 23;
        Console.WriteLine("Jméno: {0}, Věk: {1}", name3, age3);

        // ======================================================


        // ================ 5. FUNKCE PRO POUŽÍVÁNÍ DATOVÉHO TYPU STRING ================

        // 1. Kontrola obsahu řetězce
        //-------------------------------------------------

        string text = "SPSprosek";

        // Funkce StartsWith()
        // Definice: Ověřuje, zda řetězec začíná zadaným podřetězcem.
        // Jak to funguje: Funkce kontroluje, zda řetězec text začíná podřetězcem "SPS". Pokud ano, vrací hodnotu True.
        Console.WriteLine(text.StartsWith("SPS"));

        // Funkce EndsWith()
        // Definice: Ověřuje, zda řetězec končí zadaným podřetězcem.
        // Jak to funguje: Funkce kontroluje, zda řetězec text končí podřetězcem "prosek". Pokud ano, vrací hodnotu True.
        Console.WriteLine(text.EndsWith("prosek"));
        
        // Funkce Contains()
        // Definice: Ověřuje, zda řetězec obsahuje zadaný podřetězec.
        // Jak to funguje: Funkce kontroluje, zda řetězec text obsahuje podřetězec "3ITA". Pokud ano, vrací hodnotu True, jinak False.
        Console.WriteLine(text.Contains("3ITA"));

        // 2. Nastavování velikosti písmen
        //-------------------------------------------------

        // Funkce ToUpper()
        // Definice: Nastaví daný textový řetězec na velká písmena.
        // Jak to funguje: Funkce přečte řetězec a následně všechna písmena převede na velká.
        string city = "Praha";
        city = city.ToUpper();
        Console.WriteLine(city);

        // Funkce ToLower()
        // Definice: Nastaví daný textový řetězec na malá písmena.
        // Jak to funguje: Funkce přečte řetězec a následně všechna písmena převede na malá.
        string street = "NOVOBORSKÁ";
        street = street.ToLower();
        Console.WriteLine(street);

        // 3. Ošetření neviditelných znaků
        //-------------------------------------------------

        // Funkce Trim()
        // Definice: Odstraní mezery (nebo jiné zadané znaky) z obou stran řetězce, tedy jak zleva, tak zprava.
        string input = "   Hello, World!   ";
        string output = input.Trim();
        Console.WriteLine(output); // Výstup: "Hello, World!"

        // Funkce TrimStart()
        // Definice: Odstraní mezery (nebo jiné zadané znaky) pouze na začátku (levé straně) řetězce.
        string input2 = "   Hello, World!   ";
        string output2 = input2.TrimStart();
        Console.WriteLine(output2); // Výstup: "Hello, World!   "

        // Funkce TrimEnd()
        // Definice: Odstraní mezery (nebo jiné zadané znaky) pouze na konci (pravé straně) řetězce.
        string input3 = "   Hello, World!   ";
        string output3 = input3.TrimEnd();
        Console.WriteLine(output3); // Výstup: "   Hello, World!"

        // 4. Ostatní funkce
        //-------------------------------------------------

        // Vlastnost Length()
        // Definice: Vrací počet znaků v řetězci. Tato vlastnost je typu int a zahrnuje všechny znaky v řetězci, včetně mezer, čísel, speciálních znaků a symbolů.
        string user = "Karel";
        Console.WriteLine("Délka vašeho jména je: {0}", user.Length);

        // Funkce PadLeft()
        // Definice: Přidá zadaný počet znaků na levou stranu řetězce, dokud nedosáhne specifikované délky.
        // Jak to funguje: První parametr určuje požadovanou délku výsledného řetězce (včetně původního řetězce). Druhý volitelný parametr určuje znak, kterým se doplní zleva. Pokud není zadán, použije se mezera.
        string text = "123";
        string textLeft = text.PadLeft(5, ' ');
        Console.WriteLine(textLeft); // Výstup: "  123"

        // Funkce PadRight()
        // Definice: Přidá zadaný počet znaků na pravou stranu řetězce, dokud nedosáhne specifikované délky.
        // Jak to funguje: První parametr určuje požadovanou délku výsledného řetězce.Druhý volitelný parametr určuje znak, kterým se doplní zprava. Pokud není zadán, použije se mezera.
        string text2 = "123";
        string textRight = text2.PadRight(5, ' ');
        Console.WriteLine(textRight); // Výstup: "123  "

        // Funkce Replace()
        // Definice: Nahradí všechny výskyty zadaného podřetězce v řetězci jiným podřetězcem.
        // Jak to funguje: První parametr je podřetězec, který má být nahrazen. Druhý parametr je podřetězec, kterým bude nahrazen.
        string greeting = "Hello, World!";
        string greetingReplaced = greeting.Replace("World", "C#");
        Console.WriteLine(greetingReplaced); // Výstup: "Hello, C#!"

        // ======================================================


        // ================ 6. NAČÍTÁNÍ VSTUPŮ Z KONZOLE ================

        // Console.ReadLine() (vrací vždy string - nutno přeparsovat v případě čísla atd)
        // Parsování v C# je proces, při kterém se řetězce (textová data) převádí na konkrétní datové typy, jako jsou čísla, datumy, booleovské hodnoty apod.

        // 1. String bez parsování
        //-------------------------------------------------
        Console.WriteLine("Zadej své jméno:");
        string name = Console.ReadLine();   // Načte řetězec
        Console.WriteLine($"Ahoj, {name}!");

        // 2. Číslo s parsováním - klasický parse
        //-------------------------------------------------
        Console.WriteLine("Zadej svůj věk:");
        string input = Console.ReadLine();   // načte text
        int age = int.Parse(input);          // převod na celé číslo
        Console.WriteLine($"Je ti {age} let.");

        // 3. Ukázka s číslem - pokud nedám parse tak 2 + 2 nebude 4:
        //-------------------------------------------------
        // Zdvojnásobení řetězce
        Console.WriteLine("Zadejte vstup a já ho vypíšu dvakrát: ");
        string vstup = Console.ReadLine();
        string vystup = vstup + ", " + vstup + "!";
        Console.WriteLine(vystup);

        // Zdvojnásobení čísla za pomoci parsování
        Console.WriteLine("Zadejte číslo a já ho zdvojnásobím: ");
        int cislo = int.Parse(Console.ReadLine());
        cislo = cislo * 2;
        Console.WriteLine(cislo);
        
        // 4. číslo s parsováním - bezpečný TryParse
        //-------------------------------------------------
        Console.WriteLine("Zadej číslo:");
        string input = Console.ReadLine();

        // --> bool ok = Typ.TryParse(vstup, out Typ promenna); --> Typ – datový typ, do kterého převádíš (int, double, decimal, …) 
        // --> vstup – řetězec, který jsi načetl z konzole (Console.ReadLine()) 
        // --> out Typ promenna – proměnná, do které se uloží výsledek, pokud převod proběhne
        if (int.TryParse(input, out int number)) 
        {
            Console.WriteLine($"Zadal jsi číslo {number}");
        }
        else
        {
            Console.WriteLine("To není platné číslo!");
        }

        // 5. číslo s parsováním - bezpečný TryParse s opakováním
        //-------------------------------------------------
        // načtení čísel
        Console.WriteLine("Zadejte první číslo:");
        float a;
        while (!float.TryParse(Console.ReadLine(), out a)) // vrací true, pokud převod proběhl úspěšně; vrací false, pokud převod selhal (uživatel zadal nesmysl, třeba „abc“)
            Console.WriteLine("Neplatné číslo, zadejte prosím znovu:");

        // ======================================================
    }
}