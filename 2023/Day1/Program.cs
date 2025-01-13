namespace Day1
{
    class Trebuchet
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);
            List<int> allNums = new List<int>();

            int sum = 0;

            foreach (string input in inputs)
            {
                string cleanInput = input
                    .Replace("one", "o1e")
                    .Replace("two", "t2o")
                    .Replace("three", "t3e")
                    .Replace("four", "f4r")
                    .Replace("five", "f5e")
                    .Replace("six", "s6x")
                    .Replace("seven", "s7n")
                    .Replace("eight", "e8t")
                    .Replace("nine", "n9e");

                string onlyDigitsString = string.Concat(cleanInput.Where(Char.IsDigit));

                char firstDigit = onlyDigitsString[0];
                char secondDigit = onlyDigitsString[onlyDigitsString.Length - 1];
                string firstAndLastDigit = firstDigit.ToString() + secondDigit.ToString();

                sum += int.Parse(firstAndLastDigit);

            }

            Console.WriteLine(sum);
        }
    }
}


