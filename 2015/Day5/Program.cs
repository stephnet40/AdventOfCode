using System.Text.RegularExpressions;

namespace Day5
{
    class DoesntHeHaveInternElvesForThis
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            string vowels = "aeiou";
            int naughty1 = 0;

            Regex doubleReg = new Regex("\\w*(\\w)\\1{1,}\\w*");
            Regex badSubString = new Regex("\\w*(ab|cd|pq|xy)\\w*");

            foreach (string input in inputs)
            {
                string str = new string(input.Where(c => vowels.Contains(c)).ToArray());

                if (str.Length < 3 || !doubleReg.IsMatch(input) || badSubString.IsMatch(input))
                {
                    naughty1++;
                }
            }

            int nice1 = inputs.Length - naughty1;

            Console.WriteLine("Part 1: " + nice1);

            int naughty2 = 0;

            Regex doubleNoOverlap = new Regex("\\w*(\\w\\w)\\w*\\1\\w*");
            Regex repeatPattern = new Regex("\\w*(\\w)[^\\1]\\1\\w*");

            foreach (string input in inputs)
            {
                if (!doubleNoOverlap.IsMatch(input) || !repeatPattern.IsMatch(input))
                {
                    naughty2++;
                }
            }

            int nice2 = inputs.Length - naughty2;

            Console.WriteLine("Part 2: " + nice2);
;
        } 
    }
}
