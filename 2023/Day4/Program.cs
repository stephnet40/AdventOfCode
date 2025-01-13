using System.Text.RegularExpressions;

namespace Day4
{
    class Scratchcards
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);
            var inputList = new List<List<string>>();

            //string[] inputs = ["Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            //                   "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            //                   "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            //                   "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            //                   "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            //                   "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"];

            // Part 1
            int totalPoints = 0;

            foreach (var input in inputs)
            {
                char[] delimiters = { ':', '|' };
                inputList.Add(input.Split(delimiters).ToList());
            }

            foreach (var input in inputList)
            {
                List<int> list1 = GetNumList(input[1]);
                List<int> list2 = GetNumList(input[2]);
                int numMatches = 0;
                int points = 0;

                foreach (int num in list2)
                {
                    if (list1.Contains(num))
                    {
                        numMatches++;
                    }
                }

                if (numMatches > 0)
                {
                    points = 1 * (int)Math.Pow(2, numMatches - 1); 
                }

                totalPoints += points;
            }

            Console.WriteLine("Part 1: " + totalPoints);

            // Part 2
            int totalCards = 0;
            Dictionary<int, int> numCopies = new Dictionary<int, int>();

            for (int i = 0; i < inputList.Count; i++)
            {
                numCopies.Add(i + 1, 1);
            }


            foreach (var input in inputList)
            {
                
                List<int> list1 = GetNumList(input[1]);
                List<int> list2 = GetNumList(input[2]);
                int cardNum = int.Parse(Regex.Match(input[0], @"\d+").Value);
                int numMatches = 0;           

                foreach (int num in list2)
                {
                    if (list1.Contains(num))
                    {
                        numMatches++;
                    }
                }

                for (int i = 1; i <= numMatches; i++)
                {
                    if (cardNum + i <= inputList.Count)
                    {                    
                        numCopies[cardNum + i] += numCopies[cardNum];
                    }  
                }            

            }

            foreach (var num in numCopies)
            {
                totalCards += num.Value;
            }

            Console.WriteLine("Part 2: " + totalCards);
        }

        public static List<int> GetNumList(string numString)
        {
            List<int> list = new List<int>();
            List<string> numStringList = numString.Split(" ").ToList();
            numStringList.RemoveAll(x => string.IsNullOrWhiteSpace(x));
            
            foreach (var num in numStringList)
            {
                list.Add(int.Parse(num));
            }

            return list;
        }
    }
}
