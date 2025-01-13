using System.Text.RegularExpressions;

namespace Day3
{
    class MullItOver
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))" };
            //string[] inputs = { "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))" };

            Part1(inputs, 1);
            Part2(inputs);
            
        }

        static void Part1(string[] inputs, int part)
        {
            List<List<string>> allSequences = new List<List<string>>();
            List<string> sequences = new List<string>();

            string reg = @"(\b|\B)mul\([\d]{1,3},[\d]{1,3}\)(\b|\B)";

            foreach (string input in inputs)
            {
                var matches = Regex.Matches(input, reg);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        sequences.Add(match.Value);
                    }

                    allSequences.Add(sequences);

                    sequences = new List<string>();
                }
            }

            int instructions = 0;
            string reg2 = @"\b[\d]{1,3},[\d]{1,3}\b";

            foreach (var seq in allSequences)
            {
                foreach (var seq2 in seq)
                {
                    var match = Regex.Match(seq2, reg2);

                    string[] nums = match.Value.Split(",");

                    int product = int.Parse(nums[0]) * int.Parse(nums[1]);

                    instructions += product;
                }
            }

            if (part == 1) 
            {
                Console.WriteLine("Part 1: " + instructions);
            }
            
            if (part == 2)
            {
                Console.WriteLine("Part 2: " + instructions);
            }

        }

        static void Part2(string[] inputs)
        {
            string inputStr = "";

            foreach (string input in inputs)
            {
                inputStr += input + " ";
            }

            List<string> sequences = new List<string>();

            string[] strs = inputStr.Split("don't()");

            foreach (string str in strs)
            {
                sequences.Add(str); 
            }

            List<string> allEnabled = new List<string>();
            allEnabled.Add(sequences[0]);

            foreach (var seq in sequences)
            {     
                string[] tempStr = seq.Split("do()");

                for (int j = 1; j < tempStr.Length; j++)
                {
                     allEnabled.Add(tempStr[j]);
                }
                
            }

            Part1(allEnabled.ToArray(), 2);
        }
    }
}
