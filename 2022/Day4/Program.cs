namespace Day4
{
    class CampCleanup
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);
            //string[] inputs = ["2-4,6-8",
            //                   "2-3,4-5",
            //                   "5-7,7-9",
            //                   "2-8,3-7",
            //                   "6-6,4-6",
            //                   "2-6,4-8"];

            List<List<int>> allAssignments = new List<List<int>>();
            List<int> pairAssignments = new List<int>();

            foreach (var input in inputs)
            {
                string[] temp = input.Split(new char[] { ',', '-' });

                foreach (string item in temp)
                {
                    pairAssignments.Add(int.Parse(item));
                }

                allAssignments.Add(pairAssignments);

                pairAssignments = new List<int>();
            }

            // Part 1
            int fullyContainedPairs = 0;

            foreach (var a in allAssignments)
            {
                if ((a[0] <= a[2] && a[1] >= a[3]) || (a[0] >= a[2] && a[1] <= a[3]))
                {
                    fullyContainedPairs++;
                }
            }

            Console.WriteLine("Part 1: " + fullyContainedPairs);

            int overlapPairs = 0;

            foreach (var a in allAssignments)
            {
                if ((a[0] <= a[2] && a[1] >= a[2]) || (a[2] <= a[0] && a[3] >= a[0]))
                {
                    overlapPairs++;
                }
            }

            Console.WriteLine("Part 2: " + overlapPairs);
        }
    }
}
