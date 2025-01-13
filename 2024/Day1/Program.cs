namespace Day1
{
    class HistorianHysteria
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            List<int> leftCol = new List<int>();
            List<int> rightCol = new List<int>();

            foreach (string input in inputs)
            {
                string[] ids = input.Split("   ");

                leftCol.Add(Int32.Parse(ids[0]));
                rightCol.Add(Int32.Parse(ids[1]));
            }

            Part1(leftCol, rightCol);
            Part2(leftCol, rightCol);
        }

        static void Part1(List<int> leftCol, List<int> rightCol)
        {
            leftCol.Sort();
            rightCol.Sort();

            int totalDistance = 0;

            for (int i = 0; i < leftCol.Count; i++)
            {
                int dist = Math.Abs(leftCol[i] - rightCol[i]);
                totalDistance += dist;
            }

            Console.WriteLine("Part 1: " + totalDistance);
        }

        static void Part2(List<int> leftCol, List<int> rightCol)
        {
            int similarityScore = 0;

            for (int i = 0; i < leftCol.Count; i++)
            {
                int count = 0;

                for (int j = 0; j < rightCol.Count; j++)
                {
                    if (leftCol[i] == rightCol[j])
                    {
                        count++;
                    }
                }

                similarityScore += leftCol[i] * count;
            }

            Console.WriteLine("Part 2: " + similarityScore);
        }
    }
}
