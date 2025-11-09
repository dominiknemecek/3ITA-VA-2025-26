namespace maticove_pocty
{
    using System;
    using System.Text;

    class Program
    {
        // == FUNKCE (v C# se jim říká "Metody") ==

        /// <summary>
        /// Metoda pro naplnění matice daty od uživatele.
        /// V C# je běžné, že metoda data "vytvoří" a "vrátí" (pomocí return).
        /// </summary>
        /// <param name="rowCount">Počet řádků matice.</param>
        /// <param name="columnCount">Počet sloupců matice.</param>
        /// <returns>Nové 2D pole (matici) naplněné hodnotami.</returns>
        static int[,] FillMatrix(int rowCount, int columnCount)
        {
            // V C# deklarujeme 2D obdélníkové pole (matici) tímto způsobem:
            // typ[,] název = new typ[počet_řádků, počet_sloupců];
            int[,] matrix = new int[rowCount, columnCount];

            // Procházíme řádek po řádku
            for (int i = 0; i < rowCount; i++)
            {
                /*
                 * 1. Console.ReadLine() načte celý řádek textu (např. "1 2 3").
                 * 2. .Split(' ') tento text "rozseká" podle mezer na pole textů (stringů): ["1", "2", "3"].
                 * (StringSplitOptions.RemoveEmptyEntries je pojistka, kdyby uživatel zadal více mezer za sebou).
                 */
                string[] numbersInRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // Procházíme sloupce v daném řádku
                for (int j = 0; j < columnCount; j++)
                {
                    /*
                     * 3. Musíme převést text (string) na číslo (int).
                     * K tomu slouží int.Parse().
                     * Uložíme převedené číslo do naší matice na pozici [i, j].
                     */
                    matrix[i, j] = int.Parse(numbersInRow[j]);
                }
            }

            // Metoda vrací celou naplněnou matici.
            return matrix;
        }

        /// <summary>
        /// Metoda pro vypsání matice do konzole.
        /// Nepotřebuje znát rozměry, ty si umí zjistit přímo z matice.
        /// </summary>
        /// <param name="matrix">Matice, kterou chceme vypsat.</param>
        static void PrintMatrix(int[,] matrix)
        {
            // Rozměry matice můžeme v C# zjistit pomocí .GetLength()
            // 0 je první rozměr (řádky), 1 je druhý rozměr (sloupce).
            int rowCount = matrix.GetLength(0);
            int columnCount = matrix.GetLength(1);

            /*
             * StringBuilder je pomocník pro efektivní skládání textu.
             * Spojovat texty pomocí 'string + string' ve smyčce je pomalé,
             * protože pokaždé vzniká v paměti nový řetězec.
             * StringBuilder funguje jako "kontejner", do kterého postupně
             * přidáváme kousky textu.
             */
            StringBuilder rowBuilder = new StringBuilder();

            // Procházíme řádky
            for (int i = 0; i < rowCount; i++)
            {
                // Před začátkem nového řádku "vysypeme" obsah builderu.
                rowBuilder.Clear();

                // Procházíme sloupce
                for (int j = 0; j < columnCount; j++)
                {
                    // Přidáme číslo do builderu
                    rowBuilder.Append(matrix[i, j]);

                    // Ošetření mezer na konci - stejná logika jako v C.
                    // Přidáme mezeru, jen pokud to není poslední číslo v řádku.
                    if (j < columnCount - 1)
                    {
                        rowBuilder.Append(" ");
                    }
                }

                // Až když máme sestavený celý řádek, vypíšeme ho najednou
                // a přejdeme na nový řádek (díky WriteLine).
                Console.WriteLine(rowBuilder.ToString());
            }
        }

        /// <summary>
        /// Hlavní metoda programu - zde program začíná.
        /// V C# je zvykem, že Main vrací 'int' (0 pro úspěch, jiné číslo pro chybu)
        /// nebo 'void' (nic), pokud nás návratový kód nezajímá.
        /// </summary>
        static int Main()
        {
            /*
             * Blok try-catch slouží k "odchycení" chyb za běhu programu.
             * Pokud by uživatel zadal místo čísla písmeno, int.Parse()
             * by "spadlo" (vyhodilo výjimku).
             * Blok 'try' říká: "Zkus provést tento kód."
             * Blok 'catch' říká: "Pokud se něco pokazí, skoč sem a proveď tento kód."
             */
            try
            {
                // --- První matice ---

                // Načteme řádek s rozměry (např. "3 3")
                string[] dimensionsM1 = Console.ReadLine().Split();
                // Převedeme první rozměr (index 0) na počet řádků
                int rowCountM1 = int.Parse(dimensionsM1[0]);
                // Převedeme druhý rozměr (index 1) na počet sloupců
                int columnCountM1 = int.Parse(dimensionsM1[1]);

                // Zavoláme naši metodu, která nám vrátí naplněnou matici
                int[,] firstMatrix = FillMatrix(rowCountM1, columnCountM1);

                // --- Druh operace ---

                // Načteme řádek s operací (např. "+")
                // a vezmeme si z něj jen první znak (na indexu 0).
                char operationType = Console.ReadLine()[0];

                // --- Druhá matice ---

                // Stejný postup jako u první matice
                string[] dimensionsM2 = Console.ReadLine().Split();
                int rowCountM2 = int.Parse(dimensionsM2[0]);
                int columnCountM2 = int.Parse(dimensionsM2[1]);
                int[,] secondMatrix = FillMatrix(rowCountM2, columnCountM2);

                // --- VÝPOČTY ---

                // Podmínka pro SČÍTÁNÍ a ODČÍTÁNÍ
                // (Matice musí mít stejné rozměry)
                if ((operationType == '+' || operationType == '-') &&
                    rowCountM1 == rowCountM2 &&
                    columnCountM1 == columnCountM2)
                {
                    // Vytvoříme novou matici pro výsledek
                    int[,] resultMatrix = new int[rowCountM1, columnCountM1];

                    if (operationType == '+')
                    {
                        // Sčítání (dva jednoduché cykly)
                        for (int i = 0; i < rowCountM1; i++)
                        {
                            for (int j = 0; j < columnCountM1; j++)
                            {
                                resultMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                            }
                        }
                    }
                    else // operationType == '-'
                    {
                        // Odčítání (dva jednoduché cykly)
                        for (int i = 0; i < rowCountM1; i++)
                        {
                            for (int j = 0; j < columnCountM1; j++)
                            {
                                resultMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                            }
                        }
                    }

                    // Vypíšeme rozměry výsledné matice
                    // Znak $ před řetězcem umožňuje "interpolaci" - můžeme
                    // vkládat proměnné přímo do textu pomocí {}.
                    Console.WriteLine($"{rowCountM1} {columnCountM1}");

                    // Vypíšeme samotnou výslednou matici
                    PrintMatrix(resultMatrix);
                }
                // Podmínka pro NÁSOBENÍ
                // (Počet sloupců první matice se musí rovnat počtu řádků druhé)
                else if (operationType == '*' && columnCountM1 == rowCountM2)
                {
                    // Výsledná matice bude mít rozměry [řádky 1. matice, sloupce 2. matice]
                    int[,] resultMatrix = new int[rowCountM1, columnCountM2];

                    /*
                     * Toto je standardní algoritmus pro násobení matic.
                     * Potřebujeme 3 vnořené cykly:
                     * i - prochází řádky výsledné matice (a 1. matice)
                     * j - prochází sloupce výsledné matice (a 2. matice)
                     * k - prochází "společný" rozměr (sloupce 1. a řádky 2.)
                     */
                    for (int i = 0; i < rowCountM1; i++) // Řádky výsledku
                    {
                        for (int j = 0; j < columnCountM2; j++) // Sloupce výsledku
                        {
                            int sum = 0; // Vynulujeme součet pro každou buňku

                            // "Skalární součin" řádku z 1. matice a sloupce z 2. matice
                            for (int k = 0; k < columnCountM1; k++) // Společný rozměr
                            {
                                sum += firstMatrix[i, k] * secondMatrix[k, j];
                            }
                            resultMatrix[i, j] = sum; // Uložíme výsledek
                        }
                    }

                    // Vypíšeme rozměry výsledné matice
                    Console.WriteLine($"{rowCountM1} {columnCountM2}");
                    // Vypíšeme samotnou výslednou matici
                    PrintMatrix(resultMatrix);
                }
                // Pokud neplatí ani jedna podmínka, jde o chybu
                else
                {
                    // Ekvivalent fprintf(stderr, ...) je Console.Error.WriteLine()
                    // Vypíše text do speciálního chybového výstupu.
                    Console.Error.WriteLine("Error: Chybny vstup!");
                    return 100; // Ukončíme program s chybovým kódem 100
                }
            }
            // Zde "chytáme" případné chyby (např. špatný formát čísla)
            catch (Exception ex)
            {
                // Vypíšeme obecnou chybu, pokud by se něco pokazilo při čtení
                Console.Error.WriteLine($"Error: Neocekavana chyba vstupu! ({ex.Message})");
                return 1; // Ukončíme program s obecným chybovým kódem
            }

            // Pokud vše proběhlo v pořádku, vrátíme 0 (úspěch)
            return 0;
        }
    }
}
