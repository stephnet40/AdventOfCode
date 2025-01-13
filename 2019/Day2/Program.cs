namespace Day2
{
    class ProgramAlarm1202
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string inputs = File.ReadAllText(fileName).Trim();

            int[] inputArr = Array.ConvertAll(inputs.Split(','), int.Parse);

            int part1 = Part1(inputArr, 12, 2);
            Console.WriteLine($"Part 1: {part1}");

            int num1 = 0;
            int num2 = 0;

            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    inputArr = Array.ConvertAll(inputs.Split(','), int.Parse);

                    if (Part1(inputArr, i, j) == 19690720)
                    {
                        num1 = i;
                        num2 = j;
                        break;
                    }
                }
            }

            Console.WriteLine($"Part 2: {100 * num1 + num2}");
        }

        static int Part1(int[] inputs, int x, int y)
        {
            inputs[1] = x;
            inputs[2] = y;

            for (int i = 0; i < inputs.Length - 3; i += 4)
            {
                if (inputs[i] == 99) break;

                int input = inputs[i];
                int position1 = inputs[i + 1];
                int position2 = inputs[i + 2];
                int position3 = inputs[i + 3];
                int newNum = 0;

                switch (input)
                {
                    case 1:
                        newNum = inputs[position1] + inputs[position2];
                        inputs[position3] = newNum;
                        break;
                    case 2:
                        newNum = inputs[position1] * inputs[position2];
                        inputs[position3] = newNum;
                        break;
                    default:
                        break;
                }

            }

            return inputs[0];
        }
    }
}
