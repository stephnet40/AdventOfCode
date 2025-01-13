namespace Day3
{
    class PerfectlySphericalHousesInAVacuum
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string input = File.ReadAllText(fileName).Trim();

            int horizontal = 0;
            int vertical = 0;

            Dictionary<string, int> houses = new Dictionary<string, int>();
            houses.Add("0, 0", 1);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>') horizontal++;
                if (input[i] == '<') horizontal--;
                if (input[i] == '^') vertical++;
                if (input[i] == 'v') vertical--;

                string position = horizontal + ", " + vertical;

                if (houses.ContainsKey(position))
                {
                    houses[position]++;
                } else
                {
                    houses.Add(position, 1);
                }
            }

            int totalHouses = houses.Count;

            Console.WriteLine("Part 1: " + totalHouses);

            houses = new Dictionary<string, int>();
            houses.Add("0, 0", 2);

            horizontal = 0;
            vertical = 0;

            for (int i = 0; i < input.Length; i += 2)
            {
                if (input[i] == '>') horizontal++;
                if (input[i] == '<') horizontal--;
                if (input[i] == '^') vertical++;
                if (input[i] == 'v') vertical--;

                string position = horizontal + ", " + vertical;

                if (houses.ContainsKey(position))
                {
                    houses[position]++;
                }
                else
                {
                    houses.Add(position, 1);
                }
            }

            horizontal = 0;
            vertical = 0;

            for (int i = 1;  i < input.Length; i += 2)
            {
                if (input[i] == '>') horizontal++;
                if (input[i] == '<') horizontal--;
                if (input[i] == '^') vertical++;
                if (input[i] == 'v') vertical--;

                string position = horizontal + ", " + vertical;

                if (houses.ContainsKey(position))
                {
                    houses[position]++;
                }
                else
                {
                    houses.Add(position, 1);
                }
            }

            totalHouses = houses.Count;

            Console.WriteLine("Part 2: " + totalHouses);
        }
    }
}
