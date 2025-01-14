namespace Day6
{
    class GuardGallivant
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = [ "....#.....",
            //                    ".........#",
            //                    "..........",
            //                    "..#.......",
            //                    ".......#..",
            //                    "..........",
            //                    ".#..^.....",
            //                    "........#.",
            //                    "#.........",
            //                    "......#..." ];

            string startRow = inputs.Where(x => x.Contains('^')).First();
            int startColIndex = startRow.IndexOf('^');
            int startRowIndex = Array.IndexOf(inputs, startRow);

            // Initialize Start Position
            var (currRow, currCol) = (startRowIndex, startColIndex);

            // Exit points at ends
            int rowCount = inputs.Length;
            int colCount = inputs[0].Length;

            // Set initial direction
            int nextRow = -1;
            int nextCol = 0;

            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            while (true)
            {
                visited.Add((currRow, currCol));

                if (currRow + nextRow < 0 || currCol + nextCol < 0 ||
                    currRow + nextRow >= rowCount || currCol + nextCol >= colCount)
                {
                    break;
                }

                if (inputs[currRow + nextRow][currCol + nextCol] == '#')
                {
                    (nextRow, nextCol) = (nextCol, -nextRow);
                } 
                else
                {
                    currRow += nextRow;
                    currCol += nextCol;
                }
            }

            Console.WriteLine($"Part 1: {visited.Count}");

            int obstacles = Part2(visited, (startRowIndex, startColIndex), inputs, rowCount, colCount);

            Console.WriteLine($"Part 2: {obstacles}");
        }

        static int Part2(HashSet<(int, int)> visited, (int, int) start, string[] inputs, int rowCount, int colCount)
        {
            int obstacles = 0;

            foreach (var (row, col) in visited)
            {
                if (inputs[row][col] != '.') continue;

                inputs[row] = inputs[row].Remove(col, 1).Insert(col, "#");

                if (CheckForLoop(start, inputs, rowCount, colCount)) obstacles++;

                inputs[row] = inputs[row].Remove(col, 1).Insert(col, ".");
            }

            return obstacles;
        }

        static bool CheckForLoop((int, int) start, string[] inputs, int rowCount, int colCount)
        {
            var (currRow, currCol) = start;
            int nextRow = -1;
            int nextCol = 0;

            HashSet<(int, int, int, int)> visited = new HashSet<(int, int, int, int)>();

            while (true)
            {
                visited.Add((currRow, currCol, nextRow, nextCol));

                if (currRow + nextRow < 0 || currCol + nextCol < 0 ||
                    currRow + nextRow >= rowCount || currCol + nextCol >= colCount)
                {
                    break;
                }

                if (inputs[currRow + nextRow][currCol + nextCol] == '#')
                {
                    (nextRow, nextCol) = (nextCol, -nextRow);
                }
                else
                {
                    currRow += nextRow;
                    currCol += nextCol;
                }

                if (visited.Contains((currRow, currCol, nextRow, nextCol)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
