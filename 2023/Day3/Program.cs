using System.Text.RegularExpressions;

namespace Day3
{
    class GearRatios
    {
        static void Main(string[] args)
        {
            const string numberMatch = @"\d+";

            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            int sum1 = 0;

            // Part 1
            for (int i = 0; i < inputs.Length; i++)
            {
                Dictionary<int, char>? symbolMatchesPrevRow = null;
                Dictionary<int, char>? symbolMatchesNextRow = null;

                var numMatches = Regex.Matches(inputs[i], numberMatch);
                var symbolMatchesCurrRow = GetAllSymbolMatches(inputs[i]);

                if (i > 0)
                {
                    symbolMatchesPrevRow = GetAllSymbolMatches(inputs[i - 1]);
                }

                if (i < inputs.Length - 1)
                {
                    symbolMatchesNextRow = GetAllSymbolMatches(inputs[i + 1]);
                }

                foreach (var numMatch in numMatches.ToList())
                {
                    var indexMin = numMatch.Index;
                    var indexMax = numMatch.Index + numMatch.Length - 1;

                    if ((symbolMatchesPrevRow != null && symbolMatchesPrevRow.Keys.Any(x => indexMin - 1 <= x && indexMax + 1 >= x))
                        || (symbolMatchesCurrRow.Keys.Any(x => indexMin - 1 <= x && indexMax + 1 >= x))
                        || (symbolMatchesNextRow != null && symbolMatchesNextRow.Keys.Any(x => indexMin - 1 <= x && indexMax + 1 >= x))) 
                    {
                        sum1 += int.Parse(numMatch.Value);
                    }
                }
            }

            Console.WriteLine("Part 1: " + sum1);

            // Part 2
            int sum2 = 0;

            for (int i = 0; i < inputs.Length; i++)
            {
                var symbolMatchesCurrRow = GetAsteriskMatches(inputs[i]);

                foreach (var symbolMatch in symbolMatchesCurrRow)
                {
                    string? prevRow = null;
                    string? nextRow = null;

                    if (i > 0)
                    {
                        prevRow = inputs[i - 1];
                    }

                    if (i < inputs.Length - 1)
                    {
                        nextRow = inputs[i + 1];
                    }

                    var numMatches = GetAdjacentNumberMatches(inputs[i], symbolMatch.Key, prevRow, nextRow);

                    if (numMatches.Count == 2)
                    {
                        sum2 += numMatches[0] * numMatches[1];
                    }
                }
            }

            Console.WriteLine("Part 2: " + sum2);
        }

        public static Dictionary<int, char> GetAllSymbolMatches(string line)
        {
            Dictionary<int, char> matches = new Dictionary<int, char>();

            for (int i = 0; i < line.Length; i++)
            {
                if (!char.IsNumber(line[i]) && !char.Equals(line[i], '.'))
                {
                    matches.Add(i, line[i]);
                }
            }

            return matches;
        }

        public static Dictionary<int, char> GetAsteriskMatches(string line)
        {
            Dictionary<int, char> matches = new Dictionary<int, char>();

            for (int i = 0; i < line.Length; i++ )
            {
                if (Regex.IsMatch(line[i].ToString(), @"\*"))
                {
                    matches.Add(i, line[i]);
                }
            }

            return matches;
        }

        public static List<int> GetAdjacentNumberMatches(string line, int symbolIndex, string? prevLine, string? nextLine)
        {
            const string numberMatch = @"\d+";
            List<int> adjacentNumbers = new List<int>();

            var lineNumMatches = Regex.Matches(line, numberMatch).ToList();

            if (prevLine != null)
            {
                lineNumMatches.AddRange(Regex.Matches(prevLine, numberMatch));
            }

            if (nextLine != null)
            {
                lineNumMatches.AddRange(Regex.Matches(nextLine, numberMatch));
            }

            adjacentNumbers.AddRange(lineNumMatches.Where(ln =>
                (symbolIndex >= ln.Index - 1 && symbolIndex <= (ln.Index + ln.Length))
                ).Select(x => int.Parse(x.Value)));

            return adjacentNumbers;
        }
    }
}
