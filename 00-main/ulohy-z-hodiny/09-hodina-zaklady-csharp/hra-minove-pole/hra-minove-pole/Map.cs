using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hra_minove_pole
{
    internal class Map
    {
        // Základní verze hry má 8 offsetů
        private static readonly int[][] CellsAround =
        [
            [-1, -1],
        [ 0, -1],
        [1, -1],
        [-1, 0],
        [1, 0],
        [-1, 1],
        [0, 1],
        [1, 1]
        ];

        public struct IntVector(int x, int y)
        {
            public int X = x;
            public int Y = y;
        }

        // Každý int v cells[]
        // 1 2 4 8  16 32
        // |=====|> |  |  4 bity - počet min (max: 15)
        //          |> |  1 bit  - zda je mina
        //             |> 1 bit  - zda je odhalená

        private const int MinesAroundCountMask = 1 | 2 | 4 | 8;
        private const int IsMineMask = 16;
        private const int IsMineRevealedMask = 32;
        public static bool IsMine(int cell) => (cell & IsMineMask) != 0;
        public static bool IsRevealed(int cell) => (cell & IsMineRevealedMask) != 0;
        public static int GetMinesAround(int cell) => cell & MinesAroundCountMask;

        private readonly int[,] cells;
        public int Width => cells.GetLength(0);
        public int Height => cells.GetLength(1);

        public readonly int MineCount;

        public Map(int width, int height, int mineCount, Random random)
        {
            cells = new int[width, height];

            MineCount = Math.Clamp(mineCount, 0, width * height);

            /*
             * Načti všechny pozice a zamíchej
             * Na první X pozic polož miny 
             */
            List<IntVector> allPositions = new();
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    allPositions.Add(new(x, y));
            IntVector[] shuffledPositions = allPositions.ToArray();
            random.Shuffle(shuffledPositions);

            for (int n = 0; n < MineCount; n++)
            {
                IntVector position = shuffledPositions[n];
                cells[position.X, position.Y] |= IsMineMask;
            }

            /*
             * Do každé neminové pozice ulož počet min
             */
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (!IsMine(cells[x, y])) continue;

                    ProcessCellsAround(new IntVector(x, y), position =>
                    {
                        if (IsMine(cells[position.X, position.Y])) return;
                        cells[position.X, position.Y]++;
                    });
                }
            }
        }

        /*
         * Zda jsou všechny pole bez min odhaleny
         */
        public bool AreSafeCellsRevealed()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int cell = cells[x, y];
                    if (IsMine(cell)) continue;

                    if (!IsRevealed(cell)) return false;
                }
            }
            return true;
        }

        /*
         * Zavolá processCall pro každou pozici kolem pozice
         */
        public void ProcessCellsAround(IntVector position, Action<IntVector> processCell)
        {
            if (OutsideBounds(position)) return;

            foreach (int[] offset in CellsAround)
            {
                IntVector otherPosition = new(position.X + offset[0], position.Y + offset[1]);
                if (OutsideBounds(otherPosition)) continue;

                processCell(otherPosition);
            }
        }

        /*
         * Zda je pozice za hranicemi mapy
         */
        public bool OutsideBounds(IntVector position)
        {
            return position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height;
        }

        /*
         * Vrátí pole na pozici 
         */
        public int GetCellAt(IntVector position)
        {
            if (OutsideBounds(position)) throw new ArgumentException($"Position {position} is out of bounds");
            return cells[position.X, position.Y];
        }

        /*
         * Odhalí pole na pozici
         */
        public int RevealCellAt(IntVector position)
        {
            if (OutsideBounds(position)) throw new ArgumentException($"Position {position} is out of bounds");
            cells[position.X, position.Y] |= IsMineRevealedMask;
            return cells[position.X, position.Y];
        }

        /*
         * Odhalí všechny pole
         */
        public void RevealAllCells()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    cells[x, y] |= IsMineRevealedMask;
                }
            }
        }
    }
}
