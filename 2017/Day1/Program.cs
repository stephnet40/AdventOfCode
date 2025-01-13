namespace Day1
{
    class InverseCaptcha
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string input = File.ReadAllText(fileName);
          
            string input1 = input.Trim() + input.Substring(0, 1);
            int total1 = 0;

            for (int i = 0; i < input1.Length - 1; i++)
            {
                if (input1[i] == input1[i + 1])
                {
                    total1 += int.Parse(input1[i].ToString());
                }
            }

            Console.WriteLine("Part 1: " + total1);

            int mid = input.Length / 2;
            string input2 = input.Trim() + input.Substring(0, mid);
            int total2 = 0;

            for (int i = 0; i < input2.Length - mid; i++)
            {
                if (input2[i] == input2[i + mid])
                {
                    total2 += int.Parse(input2[i].ToString());
                }
            }

            Console.WriteLine("Part 2: " + total2);

        }
    }
}
