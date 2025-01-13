namespace Day2
{
    class RedNosedReports
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            //string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = ["7 6 4 2 1",
            //                   "1 2 7 8 9",
            //                   "9 7 6 2 1",
            //                   "1 3 2 4 5",
            //                   "8 6 4 4 1",
            //                   "1 3 6 7 9"];

            string[] inputs = ["5 4 3 2 1 2",
                               "4 5 4 3 2 1",
                               "1 1 2 3 4",
                               "1 2 3 3 4",
                               "1 2 3 4 4",
                               "4 4 3 2 1",
                               "4 3 3 2 1",
                               "4 3 2 1 1",
                               "1 2 6 4 5",
                               "6 2 3 4 5",
                               "1 2 3 4 9",
                               "5 4 3 2 6",
                               "1 2 3 4 9",
                               "9 2 3 4 5",
                               "1 2 3 500 4",
                               "1 2 3 0 4",
                               "1 9 10 11"];

            List<List<int>> allLevels = new List<List<int>>();

            foreach (string input in inputs)
            {
                List<int> levels = new List<int>();

                string[] temp = input.Split(" ");

                foreach (string level in temp)
                {
                    levels.Add(Int32.Parse(level));
                }

                allLevels.Add(levels);
            }

            Part1(allLevels);
            Part2(allLevels);        
        }

        static void Part1(List<List<int>> allLevels)
        {
            int numSafe = 0;

            foreach (var levels in allLevels)
            {
                bool isSafe = false;
                bool incOrDec = CheckPattern(levels);

                if (incOrDec)
                {
                    isSafe = IsSafe(levels);
                }

                if (isSafe)
                {
                    numSafe++;
                }
            }

            Console.WriteLine("Part 1: " + numSafe);
        }

        static void Part2(List<List<int>> allLevels)
        {
            int numSafe = 0;

            foreach (var levels in allLevels)
            {
                bool isSafe = false;
                bool isIncreasing = false;
                bool removedLevel = false;
                int removedIndX = 0;
                int removedIndY = 0;

                for (int i = 0; i < levels.Count - 1; i++)
                {
                    int diff = Math.Abs(levels[i] - levels[i + 1]);

                    if (diff == 0 || diff > 3)
                    {
                        removedLevel = true;
                        removedIndX = i;
                        removedIndY = i + 1;
                        break;
                    }

                }

                Console.WriteLine(removedIndY);

                List<int> levelsX = levels;
                List<int> levelsY = levels;

                if (removedLevel)
                {
                    bool isXSafe = false;
                    bool isYSafe = false;

                    levelsX.RemoveAt(removedIndX);
                    levelsY.RemoveAt(removedIndY);

                    bool isXInc = CheckPattern(levelsX);
                    bool isYInc = CheckPattern(levelsY);

                    if (isXInc)
                    {
                        isXSafe = IsSafe(levelsX);
                    }

                    if (isYInc)
                    {
                        isYSafe = IsSafe(levelsY);
                    }

                    if (isXSafe || isYSafe)
                    {
                        isSafe = true;
                    }
                }
                else
                {
                    isIncreasing = CheckPattern(levels);

                    if (isIncreasing)
                    {
                        isSafe = IsSafe(levels);
                    }
                }

                if (isSafe)
                {
                    numSafe++;
                }
            }

            Console.WriteLine("Part 2: " + numSafe);
        }

        static bool CheckPattern(List<int> levels)
        {
            bool checkInc = levels[0] < levels[1] ? true : false;
            bool pattern = false;

            for (int i = 0; i < levels.Count - 1; i++)
            {
                if ((checkInc && levels[i] < levels[i + 1]) || (!checkInc && levels[i] > levels[i + 1])) 
                {
                    pattern = true;
                } else
                {
                    pattern = false;
                    break;
                }
            }

            return pattern;
        }

        static bool IsSafe(List<int> levels)
        {
            bool safe = false;

            for (int i = 1; i < levels.Count - 1; i++)
            {
                int diffLeft = Math.Abs(levels[i] - levels[i - 1]);
                int diffRight = Math.Abs(levels[i] - levels[i + 1]);

                if (diffLeft >= 1 && diffLeft <= 3 && diffRight >= 1 && diffRight <= 3)
                {
                    safe = true;
                } else
                {
                    safe = false;
                    break;
                }
            }

            return safe;
        }
    }
}
