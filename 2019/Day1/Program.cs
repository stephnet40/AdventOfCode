namespace Day1
{
    class TheTyrannyOfTheRocketEquation
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            int fuel = 0;

            foreach (var input in inputs)
            {
                int fuelNum = int.Parse(input);

                fuel += fuelNum / 3 - 2;
            }

            Console.WriteLine($"Part 1: {fuel}");

            fuel = 0;

            foreach (var input in inputs)
            {
                int fuelNum = int.Parse(input);

                int temp = fuelNum / 3 - 2;
                int modFuel = temp;

                do
                {
                    temp = temp / 3 - 2;

                    if (temp > 0)
                    {
                        modFuel += temp;
                    }

                } while (temp > 0);

                fuel += modFuel;
            }

            Console.WriteLine($"Part 2: {fuel}");
        }
    }
}
