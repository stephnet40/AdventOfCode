using System.Text.RegularExpressions;

namespace Day6
{
    class ProbablyAFireHazard
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);

            //string[] inputs = { "turn on 0,0 through 999,999",
            //                    "toggle 0,0 through 999,0",
            //                    "turn off 499,499 through 500,500" };

            List<string> instructions = new List<string>();
            List<string[]> coordinates = new List<string[]>();

            string pattern = "(turn on|turn off|toggle)";

            foreach (string input in inputs)
            {
                var match = Regex.Match(input, pattern);

                instructions.Add(match.Value);

                string replaceStr = Regex.Replace(input, pattern, "").Trim();
                string newInput = replaceStr.Replace(" through ", ",");

                string[] list = newInput.Split(',');
                
                coordinates.Add(list);               
            }

            Part1(instructions, coordinates);
            Part2(instructions, coordinates);
        }

        static void Part1(List<string> instructions, List<string[]> coordinates)
        {
            int[,] allLights = new int[1000, 1000];
            int lightsOn = 0;

            for (int i = 0; i < instructions.Count; i++)
            {
                int x1 = int.Parse(coordinates[i][0]);
                int y1 = int.Parse(coordinates[i][1]);
                int x2 = int.Parse(coordinates[i][2]);
                int y2 = int.Parse(coordinates[i][3]);

                for (int y = y1; y <= y2; y++)
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        switch (instructions[i])
                        {
                            case "turn on":
                                allLights[y, x] = 1;
                                break;
                            case "turn off":
                                allLights[y, x] = 0;
                                break;
                            case "toggle":
                                if (allLights[y, x] == 0)
                                {
                                    allLights[y, x] = 1;
                                }
                                else
                                {
                                    allLights[y, x] = 0;
                                }
                                break;
                        }
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    lightsOn += allLights[i, j];
                }
            }

            Console.WriteLine("Part 1: " + lightsOn);
        }

        static void Part2(List<string> instructions, List<string[]> coordinates)
        {
            int[,] allLights = new int[1000, 1000];
            int brightness = 0;

            for (int i = 0; i < instructions.Count; i++)
            {
                int x1 = int.Parse(coordinates[i][0]);
                int y1 = int.Parse(coordinates[i][1]);
                int x2 = int.Parse(coordinates[i][2]);
                int y2 = int.Parse(coordinates[i][3]);

                for (int y = y1; y <= y2; y++)
                {
                    for (int x = x1; x <= x2; x++)
                    {
                        switch (instructions[i])
                        {
                            case "turn on":
                                allLights[y, x]++;
                                break;
                            case "turn off":
                                if (allLights[y, x] != 0) allLights[y, x]--;
                                break;
                            case "toggle":
                                allLights[y, x] += 2;
                                break;
                        }
                    }
                }
            }

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    brightness += allLights[i, j];
                }
            }

            Console.WriteLine("Part 2: " + brightness);
        }
    }
}
