namespace Day2
{
    class Dive
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            int horizontal = 0;
            int depth = 0;

            foreach (string input in inputs)
            {
                string[] str = input.Split(' ');

                string dir = str[0];
                int units = int.Parse(str[1]);

                switch (dir)
                {
                    case "forward":
                        horizontal += units;
                        break;
                    case "up":
                        depth -= units;
                        break;
                    case "down":
                        depth += units;
                        break;
                }
            }

            Console.WriteLine($"Part 1: {horizontal * depth}");

            horizontal = 0;
            depth = 0;
            int aim = 0;

            foreach (string input in inputs)
            {
                string[] str = input.Split(' ');

                string dir = str[0];
                int units = int.Parse(str[1]);

                switch (dir)
                {
                    case "forward":
                        horizontal += units;
                        depth += aim * units;
                        break;
                    case "up":
                        aim -= units;
                        break;
                    case "down":
                        aim += units;
                        break;
                }
            }

            Console.WriteLine($"Part 2: {horizontal * depth}");
        }
    }
}
