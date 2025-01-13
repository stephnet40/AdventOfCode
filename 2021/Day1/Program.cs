namespace Day1
{
    class SonarSweep
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            int numInc = 0;

            for (int i = 1; i < inputs.Length; i++)
            {
                int curr = int.Parse(inputs[i]);
                int prev = int.Parse(inputs[i - 1]);

                if (curr > prev)
                {
                    numInc++;
                }
            }

            Console.WriteLine($"Part 1: {numInc}");

            numInc = 0;

            List<int> newMeasurements = new List<int>();

            for (int i = 0; i < inputs.Length - 2; i++)
            {
                int x = int.Parse(inputs[i]);
                int y = int.Parse(inputs[i + 1]);
                int z = int.Parse(inputs[i + 2]);

                newMeasurements.Add(x + y + z);
            }

            for (int i = 1; i < newMeasurements.Count; i++)
            {
                int curr = newMeasurements[i];
                int prev = newMeasurements[i - 1];

                if (curr > prev)
                {
                    numInc++;
                }
            }

            Console.WriteLine($"Part 2: {numInc}");
        }
    }
}
