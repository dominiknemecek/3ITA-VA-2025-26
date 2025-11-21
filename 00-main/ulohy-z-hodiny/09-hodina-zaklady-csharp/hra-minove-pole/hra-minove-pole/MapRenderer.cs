using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra_minove_pole
{
    internal class MapRenderer
    {
        private const string Space = " ";
        private const string FullCell = ".";
        private const string EmptyCell = " ";
        private const string Mine = "*";

        private const ConsoleColor IndexColor = ConsoleColor.Cyan;
        private const ConsoleColor CellColor = ConsoleColor.White;
        private const ConsoleColor MineColor = ConsoleColor.Red;
        private static readonly ConsoleColor[] MinesAroundColors = {
        ConsoleColor.Blue,
        ConsoleColor.Green,
        ConsoleColor.Magenta,
        ConsoleColor.Yellow,
        ConsoleColor.DarkBlue,
        ConsoleColor.DarkGreen,
        ConsoleColor.DarkMagenta,
        ConsoleColor.DarkYellow
    };

        private readonly Map map;
        private readonly bool onlyRenderMines;

        public MapRenderer(Map map, bool onlyRenderMines)
        {
            this.map = map;
            this.onlyRenderMines = onlyRenderMines;
        }

        public void Render()
        {
            // Indexy sloupců
            StringBuilder columnIndexes = new();

            columnIndexes.Append(Space);
            for (int x = 0; x < map.Width; x++)
                columnIndexes.Append(Space).Append(x);
            columnIndexes.AppendLine();

            Console.ForegroundColor = IndexColor;
            Console.Write(columnIndexes);

            for (int y = 0; y < map.Height; y++)
            {
                // Index řádků
                Console.ForegroundColor = IndexColor;
                Console.Write(y);

                // Mapa min
                for (int x = 0; x < map.Width; x++)
                {
                    Console.ForegroundColor = CellColor;
                    Console.Write(Space);

                    int cell = map.GetCellAt(new(x, y));

                    // Pokud pole není odhaleno
                    if (!Map.IsRevealed(cell))
                    {
                        Console.Write(FullCell);
                        continue;
                    }

                    // Pokud je pole mina
                    if (Map.IsMine(cell))
                    {
                        Console.ForegroundColor = MineColor;
                        Console.Write(Mine);
                        continue;
                    }

                    /*
                     * Vypiš:
                     *  Pokud je pole prázdné, mezera
                     *  Pokud jsou kolem pole miny, počet min
                     */
                    int cellsAround = Map.GetMinesAround(cell);
                    if (onlyRenderMines || cellsAround == 0)
                    {
                        Console.ForegroundColor = CellColor;
                        Console.Write(EmptyCell);
                    }
                    else
                    {
                        Console.ForegroundColor = MinesAroundColors[(cellsAround - 1) % MinesAroundColors.Length];
                        Console.Write(cellsAround);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
