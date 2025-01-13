namespace Day2
{
    class IWasToldThereWouldBeNoMath
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            // SA for box = 2*l*w + 2*w*h + 2*h*l
            // Dimensions: l = [0], w = [1], h = [2]

            List<List<int>> allDims = new List<List<int>>();
            List<int> dimensions = new List<int>();
             
            foreach (var input in inputs)
            {
                string[] dimArr = input.Split('x');

                foreach (var dim in dimArr)
                {
                    dimensions.Add(int.Parse(dim));
                }

                allDims.Add(dimensions);
                dimensions = new List<int>();
            }

            int paper = 0;

            foreach (var dims in allDims)
            {
                int area1 = 2 * dims[0] * dims[1];
                int area2 = 2 * dims[1] * dims[2];
                int area3 = 2 * dims[0] * dims[2];

                int min = Math.Min(area1 / 2, Math.Min(area2 / 2, area3 / 2));

                paper += area1 + area2 + area3 + min;
            }

            Console.WriteLine("Part 1: " + paper);

            int ribbon = 0;

            foreach (var dims in allDims)
            {
                int bow = dims[0] * dims[1] * dims[2];

                dims.Sort();
                dims.RemoveAt(2);

                int len = 2 * dims[0] + 2 * dims[1];

                ribbon += len + bow;
            }

            Console.WriteLine("Part 2: " + ribbon);

        }
    }
}
