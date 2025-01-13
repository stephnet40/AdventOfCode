namespace Day2
{
    class InventoryManagementSystem
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            int twoLetters = 0;
            int threeLetters = 0;

            foreach (string input in inputs)
            {
                Dictionary<char, int> letters = new Dictionary<char, int>();

                for (int i = 0; i < input.Length; i++)
                {
                    if (letters.ContainsKey(input[i]))
                    {
                        letters[input[i]]++;
                    } else
                    {
                        letters.Add(input[i], 1);
                    }
                }

                if (letters.ContainsValue(2))
                {
                    twoLetters++;
                }

                if (letters.ContainsValue(3))
                {
                    threeLetters++;
                }
            }

            int checkSum = twoLetters * threeLetters;

            Console.WriteLine($"Part 1: {checkSum}");

            string id1 = "";

            for (int i = 0; i < inputs.Length - 1; i++)
            {
                for (int j = i + 1; j < inputs.Length; j++)
                {
                    int diffCharNum = 0;
                    int diff = 0;
                    for (int k = 0; k < inputs[i].Length; k++)
                    {
                        if (inputs[i][k] != inputs[j][k]) 
                        {
                            diffCharNum++;
                            diff = k;
                        }
                    }

                    if (diffCharNum == 1)
                    {
                        id1 = inputs[i].Remove(diff, 1);
                        break;
                    }             
                }
            }

            Console.WriteLine($"Part 2: {id1}");
        }
    }
}
