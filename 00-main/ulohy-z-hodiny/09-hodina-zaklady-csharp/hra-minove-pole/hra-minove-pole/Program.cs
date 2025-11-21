namespace hra_minove_pole
{
    internal class Program
    {
        private static Map map;

        private static void Main()
        {
            // Načíst mapu od uživatele
            map = Input.ReadMap();

            // Herní cyklus
            bool exlploded = false;
            while (true)
            {
                Console.ResetColor();
                Console.Clear();

                // Vypsat mapu
                MapRenderer renderer = new(map, false);
                renderer.Render();

                // Načíst pozici od uživatele
                Map.IntVector position = Input.ReadCorrectInputPosition(map);
                int cell = map.RevealCellAt(position);

                // Pokud je na pozici mina, uknonči herní cyklus s explozí
                if (Map.IsMine(cell))
                {
                    exlploded = true;
                    break;
                }

                // Pokud není kolem pozice žádná mina, automaticky odhal pozice kolem
                if (Map.GetMinesAround(cell) == 0)
                {
                    void RecursiveRevealEmpty(Map.IntVector otherPosition)
                    {
                        int otherCell = map.GetCellAt(otherPosition);
                        if (Map.IsRevealed(otherCell)) return;

                        map.RevealCellAt(otherPosition);
                        if (Map.GetMinesAround(otherCell) == 0)
                            map.ProcessCellsAround(otherPosition, RecursiveRevealEmpty);
                    }
                    map.ProcessCellsAround(position, RecursiveRevealEmpty);
                }

                // Pokud jsou všechny pole bez min odhalená, ukonči herní cyklus
                if (map.AreSafeCellsRevealed())
                {
                    break;
                }
            }

            Console.Clear();

            // Odhal všechny pole a vypiš pole
            map.RevealAllCells();
            MapRenderer finalRenderer = new(map, exlploded);
            finalRenderer.Render();

            Console.WriteLine(exlploded ? "Prohráli jste! Našlápli jste na minu!" : "Vyhráli jste!");
        }
    }
}
