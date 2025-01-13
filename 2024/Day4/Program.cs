namespace Day4
{
    class CeresSearch
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = { "MMMSXXMASM",
            //                    "MSAMXMSMSA",
            //                    "AMXSXMAAMM",
            //                    "MSAMASMSMX",
            //                    "XMASAMXAMM",
            //                    "XXAMMXXAMA",
            //                    "SMSMSASXSS",
            //                    "SAXAMASAAA",
            //                    "MAMMMXMMMM",
            //                    "MXMXAXMASX" };

            int rows = inputs.Length;
            int cols = inputs[0].Length;

            int xmasTotal = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    xmasTotal += Part1(i, j);
                }
            }

            Console.WriteLine("Part 1: " + xmasTotal);

            int xmasTotal2 = 0;

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {
                    xmasTotal2 += Part2(i, j);
                }
            }

            Console.WriteLine("Part 2: " + xmasTotal2);

            int Part1(int i, int j)
            {
                if (inputs[i][j] != 'X') return 0;
                int count = 0;

                // Up
                if (i - 3 >= 0 && inputs[i - 1][j] == 'M' && inputs[i - 2][j] == 'A' && inputs[i - 3][j] == 'S')
                {
                    count++;
                }

                // Down
                if (i + 3 < rows && inputs[i + 1][j] == 'M' && inputs[i + 2][j] == 'A' && inputs[i + 3][j] == 'S')
                {
                    count++;
                }

                // Left
                if (j - 3 >= 0 && inputs[i][j - 1] == 'M' && inputs[i][j - 2] == 'A' && inputs[i][j - 3] == 'S')
                {
                    count++;
                }

                // Right
                if (j + 3 < cols && inputs[i][j + 1] == 'M' && inputs[i][j + 2] == 'A' && inputs[i][j + 3] == 'S')
                {
                    count++;
                }

                // Up Left
                if (i - 3 >= 0 && j - 3 >= 0 && inputs[i - 1][j - 1] == 'M' && inputs[i - 2][j - 2] == 'A' && inputs[i - 3][j - 3] == 'S')
                {
                    count++;
                }

                // Up Right
                if (i - 3 >= 0 && j + 3 < cols && inputs[i - 1][j + 1] == 'M' && inputs[i - 2][j + 2] == 'A' && inputs[i - 3][j + 3] == 'S')
                {
                    count++; 
                }

                // Down Left
                if (i + 3 < rows && j - 3 >= 0 && inputs[i + 1][j - 1] == 'M' && inputs[i + 2][j - 2] == 'A' && inputs[i + 3][j - 3] == 'S')
                {
                    count++;
                }

                // Down Right
                if (i + 3 < rows && j + 3 < cols && inputs[i + 1][j + 1] == 'M' && inputs[i + 2][j + 2] == 'A' && inputs[i + 3][j + 3] == 'S')
                {
                    count++;
                }

                return count;
            }

            int Part2(int i, int j)
            {
                if (inputs[i][j] != 'A') return 0;
                int count = 0;

                // Top
                if (inputs[i - 1][j - 1] == 'M' && inputs[i - 1][j + 1] == 'M' && inputs[i + 1][j - 1] == 'S' && inputs[i + 1][j + 1] == 'S')
                {
                    count++;
                }

                // Bottom
                if (inputs[i - 1][j - 1] == 'S' && inputs[i - 1][j + 1] == 'S' && inputs[i + 1][j - 1] == 'M' && inputs[i + 1][j + 1] == 'M')
                {
                    count++;
                }

                // Left
                if (inputs[i - 1][j - 1] == 'M' && inputs[i - 1][j + 1] == 'S' && inputs[i + 1][j - 1] == 'M' && inputs[i + 1][j + 1] == 'S')
                {
                    count++;
                }

                // Right
                if (inputs[i - 1][j - 1] == 'S' && inputs[i - 1][j + 1] == 'M' && inputs[i + 1][j - 1] == 'S' && inputs[i + 1][j + 1] == 'M')
                {
                    count++;
                }

                return count;
            }
        }
    }
}
