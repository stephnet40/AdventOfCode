namespace Day1
{
    class CalorieCounting
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            Dictionary<int, List<int>> caloriesPerElf = new Dictionary<int, List<int>>();
            List<int> calories = new List<int>();

            int elf = 1;

            foreach (string input in inputs)
            {

                if (input != "")
                {
                    int num = Int32.Parse(input);
                    calories.Add(num);
                } else
                {
                    caloriesPerElf.Add(elf, calories);
                    calories = new List<int>();
                    elf++;
                }
            }

            List<int> totalCalories = new List<int>();

            foreach (var a in caloriesPerElf)
            {
                int currCal = 0;

                foreach (var b in a.Value)
                {
                    currCal += b;   
                }

                totalCalories.Add(currCal);
            }

            // Part 1

            int maxCal = totalCalories.Max();

            Console.WriteLine("Part 1: " + maxCal);

            // Part 2

            totalCalories.Sort();
            totalCalories.Reverse();

            int top3Cal = totalCalories[0] + totalCalories[1] + totalCalories[2]; 

            Console.WriteLine("Part 2: " + top3Cal);
            
        }
    }
}
