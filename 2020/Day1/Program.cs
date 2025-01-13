namespace Day1
{
    class ReportRepair
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            int answer = 0;

            for (int i = 0; i < inputs.Length - 1; i++)
            {
                for (int j =  i + 1; j < inputs.Length; j++)
                {
                    if (int.Parse(inputs[i]) + int.Parse(inputs[j]) == 2020)
                    {
                        answer = int.Parse(inputs[i]) * int.Parse(inputs[j]);
                        break;
                    }
                }
            }

            Console.WriteLine($"Part 1: {answer}");

            answer = 0;

            for (int i = 0; i < inputs.Length - 2; i++)
            {
                for (int j = i + 1; j < inputs.Length - 1; j++)
                {
                    for (int k = i + 2; k < inputs.Length; k++)
                    {
                        if (int.Parse(inputs[i]) + int.Parse(inputs[j]) + int.Parse(inputs[k]) == 2020)
                        {
                            answer = int.Parse(inputs[i]) * int.Parse(inputs[j]) * int.Parse(inputs[k]);
                            break;
                        }
                    }                  
                }
            }

            Console.WriteLine($"Part 2: {answer}");
        }
    }
}
