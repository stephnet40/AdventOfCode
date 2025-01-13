namespace Day3
{
    class RucksackReorganization
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = ["vJrwpWtwJgWrhcsFMMfFFhFp",
            //                   "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            //                   "PmmdzqPrVvPwwTWBwg",
            //                   "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            //                   "ttgJtRGJQctTZtZT",
            //                   "CrZsJsPPZsGzwwsLwLmpwMDw"];

            char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
   
            // Part 1
            List<string> firstCompartments = new List<string>();
            List<string> secondCompartments = new List<string>();

            foreach (string input in inputs)
            {
                int mid = input.Length / 2;

                string firstHalf = input.Substring(0, mid);
                string secondHalf = input.Substring(mid);

                firstCompartments.Add(firstHalf);
                secondCompartments.Add(secondHalf);
            }

            List<char> matching = new List<char>();

            for (int i = 0; i < firstCompartments.Count; i++)
            {
                string compartment1 = firstCompartments[i];
                string compartment2 = secondCompartments[i];

                List<char> temp = new List<char>();

                for (int j = 0; j < compartment1.Length; j++)
                {                   
                    if (compartment2.Contains(compartment1[j]) && !temp.Contains(compartment1[j]) )
                    {
                        temp.Add(compartment1[j]);
                    }               
                }

                matching.AddRange(temp);

                temp = new List<char>();
            }

            int priority = 0;

            foreach(char match in matching)
            {
                int priorityNum = Array.IndexOf(alphabet, match) + 1;
                priority += priorityNum;
            }

            Console.WriteLine("Part 1: " + priority);

            // Part 2

            Dictionary<int, List<string>> elfGroups = new Dictionary<int, List<string>>();
            List<string> packs = new List<string>();

            int count = 0;
            int group = 1;

            foreach (string input in inputs)
            {
                packs.Add(input);
                count++;

                if (count == 3)
                {
                    elfGroups.Add(group, packs);
                    packs = new List<string>();
                    count = 0;
                    group++;
                }
            }

            List<char> badge = new List<char>();

            foreach (var elfGroup in elfGroups)
            {
                string string1 = elfGroup.Value[0];
                string string2 = elfGroup.Value[1];
                string string3 = elfGroup.Value[2];

                List<char> temp = new List<char>();

                for (int i = 0; i < string1.Length; i++)
                {                   
                    if (string2.Contains(string1[i]) && string3.Contains(string1[i]) && !temp.Contains(string1[i]))
                    {
                        temp.Add(string1[i]);
                    }
                }

                badge.AddRange(temp);

                temp = new List<char>();
            }

            int sum = 0;

            foreach (char a in badge)
            {
                int currNum = Array.IndexOf(alphabet, a) + 1;
                sum += currNum;
            }

            Console.WriteLine("Part 2: " + sum);
        }
    }
}
