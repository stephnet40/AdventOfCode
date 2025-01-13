namespace Day3
{
    class SquaresWithThreeSides
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            Part1(inputs);
            Part2(inputs);
        }

        static void Part1(string[] inputs)
        {
            List<int[]> allNumbers = new List<int[]>();

            foreach (string input in inputs)
            {
                List<int> temp = new List<int>();
                string[] numbers = input.Split("  ", StringSplitOptions.RemoveEmptyEntries);

                foreach (string number in numbers)
                {
                    temp.Add(int.Parse(number.Trim()));
                }

                allNumbers.Add(temp.ToArray());
            }

            int possible = 0;

            foreach (int[] numbers in allNumbers)
            {
                Array.Sort(numbers);

                if (numbers[0] + numbers[1] > numbers[2])
                {
                    possible++;
                }
            }

            Console.WriteLine("Part 1: " + possible);
        }

        static void Part2(string[] inputs)
        {
            List<int[]> allNumbers = new List<int[]>();

            string inputStr = "";

            foreach (string input in inputs)
            {
                inputStr += input + "  ";
            }
     
            string[] numbers = inputStr.Split("  ", StringSplitOptions.RemoveEmptyEntries);

            int possible = 0;

            for (int i = 0; i < numbers.Length - 6; i++)
            {
                if (i % 3 == 0 && i > 0)
                {
                    i += 6;
                }

                int x = int.Parse(numbers[i]);
                int y = int.Parse(numbers[i + 3]);
                int z = int.Parse(numbers[i + 6]);

                int[] list = { x, y, z };

                Array.Sort(list);

                if (list[0] + list[1] > list[2])
                {
                    possible++;
                }
            }

            Console.WriteLine("Part 2: " + possible);
        }
    }
}
