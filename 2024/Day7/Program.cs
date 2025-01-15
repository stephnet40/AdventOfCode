namespace Day7
{
    class BridgeRepair
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = [ "190: 10 19",
            //                    "3267: 81 40 27",
            //                    "83: 17 5",
            //                    "156: 15 6",
            //                    "7290: 6 8 6 15",
            //                    "161011: 16 10 13",
            //                    "192: 17 8 14",
            //                    "21037: 9 7 18 13",
            //                    "292: 11 6 16 20" ];

            List<long> finalCalibrations = new List<long>();
            List<int[]> calculations = new List<int[]>();

            foreach (string input in inputs)
            {
                string[] temp = input.Split(':', StringSplitOptions.TrimEntries);
                long finalCal = Int64.Parse(temp[0]);
                finalCalibrations.Add(finalCal);

                int[] calVals = temp[1].Split(" ").Select(int.Parse).ToArray();
                calculations.Add(calVals);
            }

            long total1 = 0;
            long total2 = 0;

            for (int i = 0; i < calculations.Count; i++)
            {
                long finalCal = finalCalibrations[i];
                int[] calVals = calculations[i];

                total1 += Part1(finalCal, calVals) ? finalCal : 0;
                total2 += Part2(finalCal, calVals) ? finalCal : 0;
            }

            Console.WriteLine($"Part 1: {total1}");
            Console.WriteLine($"Part 2: {total2}");
        }

        static bool Part1(long finalCal, int[] calVals)
        {
            bool CheckCalculation(int index, long currVal)
            {
                if (index == calVals.Length)
                {
                    return currVal == finalCal;
                }

                if (CheckCalculation(index + 1, currVal + calVals[index])) return true;

                if (CheckCalculation(index + 1, currVal * calVals[index])) return true;

                return false;
                
            }
            
            return CheckCalculation(1, calVals[0]);
        }

        static bool Part2(long finalCal, int[] calVals)
        {
            bool CheckCalculation(int index, long currVal)
            {
                if (index == calVals.Length)
                {
                    return currVal == finalCal;
                }

                if (CheckCalculation(index + 1, currVal + calVals[index])) return true;

                if (CheckCalculation(index + 1, currVal * calVals[index])) return true;

                long concat = Int64.Parse(currVal.ToString() + calVals[index].ToString());
                if (CheckCalculation(index + 1, concat)) return true; 
               
                return false;
            }

            return CheckCalculation(1, calVals[0]);
        }
    }
}
