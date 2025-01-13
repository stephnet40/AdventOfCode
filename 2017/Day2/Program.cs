using System.Text.RegularExpressions;

namespace Day2
{
    class CorruptionChecksum
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = { "5 9 2 8",
            //                    "9 4 7 3",
            //                    "3 8 6 5"};

            List<List<int>> allValues = new List<List<int>>();
            List<int> values = new List<int>();

            foreach (string input in inputs)
            {
                string[] tempArr = Regex.Split(input, @"\s+", RegexOptions.IgnorePatternWhitespace);

                foreach (string temp in tempArr)
                {
                    values.Add(int.Parse(temp));
                }

                allValues.Add(values);
                values = new List<int>();
            }

            int total1 = 0;

            foreach (var val in allValues)
            {
                int max = val.Max();
                int min = val.Min();

                total1 += max - min;
            }

            Console.WriteLine("Part 1: " + total1);

            int total2 = 0;

            foreach (var val in allValues)
            {
                val.Sort();

                for (int i = 0; i < val.Count - 1; i++)
                {
                    for (int j = i + 1; j < val.Count; j++)
                    {
                        if (val[j] % val[i] == 0)
                        { 
                            total2 += val[j] / val[i];
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Part 2: " + total2);
        }
    }
}
