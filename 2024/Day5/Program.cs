namespace Day5
{
    class PrintQueue
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = { "47|53",
            //                    "97|13",
            //                    "97|61",
            //                    "97|47",
            //                    "75|29",
            //                    "61|13",
            //                    "75|53",
            //                    "29|13",
            //                    "97|29",
            //                    "53|29",
            //                    "61|53",
            //                    "97|53",
            //                    "61|29",
            //                    "47|13",
            //                    "75|47",
            //                    "97|75",
            //                    "47|61",
            //                    "75|61",
            //                    "47|29",
            //                    "75|13",
            //                    "53|13",

            //                    "75,47,61,53,29",
            //                    "97,61,53,29,13",
            //                    "75,29,13",
            //                    "75,97,47,61,53",
            //                    "61,13,29",
            //                    "97,13,75,29,47" };

            List<string[]> orderingRules = new List<string[]>();
            List<string[]> updates = new List<string[]>();

            foreach (string input in inputs)
            {
                if (input.Contains('|'))
                {
                    string[] temp = input.Split('|');
                    orderingRules.Add(temp);
                } else if (input != "")
                {
                    string[] temp = input.Split(',');
                    updates.Add(temp);
                }
            }

            int midSum = 0;

            foreach (string[] update in updates)
            {
                bool correctOrder = true;
                foreach (string[] rule in orderingRules)
                {
                    if (update.Contains(rule[0]) && update.Contains(rule[1]))
                    {
                        int ind1 = Array.FindIndex(update, x => x == rule[0]);
                        int ind2 = Array.FindIndex(update, x => x == rule[1]);

                        if (ind1 > ind2)
                        {
                            correctOrder = false;
                            break;
                        }
                    } else
                    {
                        continue;
                    }
                }

                if (correctOrder)
                {
                    midSum += int.Parse(update[update.Length / 2]);
                }
            }

            Console.WriteLine($"Part 1: {midSum}");

            Part2(orderingRules, updates);
        }

        static void Part2(List<string[]> orderingRules, List<string[]> updates)
        {
            int midSum = 0;

            HashSet<(int, int)> rules = [];
            ComparePages compare = new(rules);

            foreach (string[] rule in orderingRules)
            {
                int rule1 = int.Parse(rule[0]);
                int rule2 = int.Parse(rule[1]);

                (int, int) value = (rule1, rule2);
                rules.Add(value);
            }

            List<int[]> updateInt = new List<int[]>();

            foreach (string[] update in updates)
            {
                List<int> temp = new List<int>();
                foreach (string a in update)
                {
                    temp.Add(int.Parse(a));
                }

                updateInt.Add(temp.ToArray());
            }

            midSum = updateInt
                .Where(x => !SortedCorrectly(x, compare))
                .Sum(x => x.Order(compare).ElementAt(x.Length / 2));

            Console.WriteLine($"Part 2: {midSum}");
        }

        static bool SortedCorrectly(int[] update, ComparePages comparer)
        {
            return update.SequenceEqual(update.Order(comparer));
        }

        class ComparePages(HashSet<(int, int)> rules) : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (rules.Contains((x, y))) return -1;
                if (rules.Contains((y, x))) return 1;
                return 0;
            }
        }

    }
}
