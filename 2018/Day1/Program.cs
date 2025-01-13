using System.Text.RegularExpressions;

namespace Day1
{
    class ChronalCalibration
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            int frequency = 0;

            foreach (string input in inputs)
            {
                char addOrSub = input[0];

                string numStr = Regex.Match(input, @"\d+").Value;

                if (addOrSub == '+')
                {
                    frequency += int.Parse(numStr);
                } else
                {
                    frequency -= int.Parse(numStr);
                }
            }

            Console.WriteLine($"Part 1: {frequency}");

            List<int> frequencies = new List<int>();
            frequency = 0;
            bool freqTwice = false;

            while (!freqTwice)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    char addOrSub = inputs[i][0];

                    int numStr = int.Parse(Regex.Match(inputs[i], @"\d+").Value);

                    if (addOrSub == '+')
                    {
                        frequency += numStr;

                        if (frequencies.Contains(frequency))
                        {
                            freqTwice = true;
                            break;
                        }
                        else
                        {
                            frequencies.Add(frequency);
                        }
                    }
                    else
                    {
                        frequency -= numStr;

                        if (frequencies.Contains(frequency))
                        {
                            freqTwice = true;
                            break;
                        }
                        else
                        {
                            frequencies.Add(frequency);
                        }
                    }
                }
            }
            

            Console.WriteLine($"Part 2: {frequency}");
        }
    }
}
