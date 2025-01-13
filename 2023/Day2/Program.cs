using System;
using System.Text.RegularExpressions;

namespace Day2
{
    class CubeConundrum
    {
        static void Main(string[] args)
        {
            var fileName = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "..", "..", "..", "input.txt"));
            string[] inputs = File.ReadAllLines(fileName);
            var inputList = new List<List<string>>();
            
            // Part 1
            int gameSum = 0;

            // Part 2
            int gamePower = 0;

            foreach (var input in inputs)
            {
                char[] delimiters = { ':', ';' };
                inputList.Add(input.Split(delimiters).ToList());
            }

            foreach (var input in inputList)
            {
                int gameNumber = int.Parse(Regex.Match(input[0], @"\d+").Value); ;
                int isPossible = 0;
                List<int[]> cubeList = new List<int[]>();

                for (int i = 1; i < input.Count; i++)
                {
                    string[] cubes = input[i].Split(',');
                    int[] cubeColors;

                    // Part 1
                    isPossible += IsPossible(cubes);

                    //Part 2
                    cubeColors = GetCubes(cubes);
                    cubeList.Add(cubeColors);
                }

                //Part 1
                if (isPossible == input.Count - 1)
                {
                    gameSum += gameNumber;
                }

                gamePower += GetPowerOfCubes(cubeList);

            }

            Console.WriteLine("Part 1: " + gameSum);            
            Console.WriteLine("Part 2: " + gamePower);
        }

        public static int IsPossible(string[] cubes)
        {
            Boolean redPossible = true;
            Boolean greenPossible = true;
            Boolean bluePossible = true;

            foreach (var cube in cubes)
            {
                string color = Regex.Match(cube, @"\b(red|green|blue)\b").Value;
                int number = int.Parse(Regex.Match(cube, @"\d+").Value);
                switch(color)
                {
                    case "red":
                        redPossible = number <= 12 ? true : false; 
                        break;
                    case "green":
                        greenPossible = number <= 13 ? true : false;
                        break;
                    case "blue":
                        bluePossible = number <= 14 ? true : false;
                        break;
                }
            }

            return redPossible == true && greenPossible == true && bluePossible == true ? 1 : 0;
        }

        public static int[] GetCubes(string[] cubes)
        {
            int redCubes = 0;
            int greenCubes = 0;
            int blueCubes = 0;

            foreach (var cube in cubes)
            {
                string color = Regex.Match(cube, @"\b(red|green|blue)\b").Value;
                int number = int.Parse(Regex.Match(cube, @"\d+").Value);
                switch (color)
                {
                    case "red":
                        if (number > redCubes)
                        {
                            redCubes = number;
                        }
                        break;
                    case "green":
                        if (number > greenCubes)
                        {
                            greenCubes = number;
                        }
                        break;
                    case "blue":
                        if (number > blueCubes)
                        {
                            blueCubes = number;
                        }
                        break;
                }
            }

            return [redCubes, greenCubes, blueCubes];
        }

        public static int GetPowerOfCubes(List<int[]> cubes)
        {
            int maxRed = 0;
            int maxGreen = 0;
            int maxBlue = 0;

            foreach (var cube in cubes)
            {
                if (cube[0] > maxRed) 
                { 
                    maxRed = cube[0]; 
                }

                if (cube[1] > maxGreen)
                {
                    maxGreen = cube[1];
                }

                if (cube[2] > maxBlue)
                {
                    maxBlue = cube[2];
                }
            }

            return maxRed * maxGreen * maxBlue;
        }
    }
}

